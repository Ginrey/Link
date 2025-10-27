using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Link.Pools;

namespace Link.Net;

public class SocketConnection : Connection
{
    public Socket BaseSocket { get; private set; }
    public SocketAsyncEventArgs? SocketReceiveArgs { get; private set; }
    public SocketAsyncEventArgs? SocketSendArgs { get; private set; }

    private IPool<SocketAsyncEventArgs> ReceivePool { get; }
    private IPool<SocketAsyncEventArgs> SendPool { get; }
    private CancellationTokenSource? _receiveCts;
    private readonly SemaphoreSlim _stateSemaphore = new(1, 1);

    public SocketConnection(Socket socket, IPool<SocketAsyncEventArgs> receivePool, IPool<SocketAsyncEventArgs> sendPool)
    {
        BaseSocket = socket;

        SendPool = sendPool;
        ReceivePool = receivePool;

        SocketReceiveArgs = receivePool.Take();
        SocketSendArgs = sendPool.Take();

        SocketReceiveArgs.Completed += socketArgsRecv_Completed;
        SocketSendArgs.Completed += socketArgsSend_Completed;
    }
    public SocketConnection(Socket socket) : this(
        socket,
        SocketAsyncEventArgsPool.ReceiveInstance,
        SocketAsyncEventArgsPool.SendInstance)
    {
    }
    public SocketConnection(SocketType socketType, ProtocolType protocolType) : this(new Socket(socketType, protocolType))
    {
    }
    public SocketConnection(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) : this(new Socket(addressFamily, socketType, protocolType))
    {
    }

    private readonly object lckObject = new();
    
    // Modern Pipe-based receive (zero-copy, high performance)
    private Pipe? _receivePipe;
    private Task? _fillPipeTask;
    private Task? _processPipeTask;
    private bool _usePipelineMode = true; // По умолчанию используем Pipes

    /// <summary>
    /// Включить/выключить режим System.IO.Pipelines для приема данных.
    /// true = PipeReader (zero-copy, высокая производительность)
    /// false = традиционный byte[] буфер (обратная совместимость)
    /// </summary>
    public bool UsePipelineMode
    {
        get => _usePipelineMode;
        set => _usePipelineMode = value;
    }

    public override async void Start()
    {
        await _stateSemaphore.WaitAsync().ConfigureAwait(false);
        try
        {
            if (State == ConnectionState.Working)
            {
                return;
            }
            State = ConnectionState.Working;
            _receiveCts = new CancellationTokenSource();

            if (_usePipelineMode)
            {
                // Modern Pipe-based receive (recommended)
                _receivePipe = new Pipe(new PipeOptions(
                    pool: MemoryPool<byte>.Shared,
                    pauseWriterThreshold: 1024 * 1024,  // 1MB backpressure
                    resumeWriterThreshold: 512 * 1024,   // 512KB resume
                    useSynchronizationContext: false
                ));

                _fillPipeTask = FillPipeAsync(_receivePipe.Writer, _receiveCts.Token);
                _processPipeTask = ProcessPipeAsync(_receivePipe.Reader, _receiveCts.Token);
            }
            else
            {
                // Legacy receive loop (backward compatibility)
                _ = ReceiveLoopAsync(_receiveCts.Token);
            }
        }
        finally
        {
            _stateSemaphore.Release();
        }
    }

    public override async void Stop()
    {
        await _stateSemaphore.WaitAsync().ConfigureAwait(false);
        try
        {
            _receiveCts?.Cancel();
            State = ConnectionState.NotWorking;
        }
        finally
        {
            _stateSemaphore.Release();
        }
    }

    public override async void Close()
    {
        await _stateSemaphore.WaitAsync().ConfigureAwait(false);
        try
        {
            _receiveCts?.Cancel();
            _receiveCts?.Dispose();
            _receiveCts = null;

            try
            {
                BaseSocket.Shutdown(SocketShutdown.Both);
            }
            catch
            {
            }
            try
            {
                BaseSocket.Dispose();
            }
            catch
            {
            }
            State = ConnectionState.Closed;
            if (SocketReceiveArgs != null)
            {
                SocketReceiveArgs.Completed -= socketArgsRecv_Completed;
                ReceivePool.Return(SocketReceiveArgs);
            }
            if (SocketSendArgs != null)
            {
                SocketSendArgs.Completed -= socketArgsSend_Completed;
                SendPool.Return(SocketSendArgs);
            }
        }
        finally
        {
            _stateSemaphore.Release();
        }
    }

    [Obsolete("Use ProcessSendAsync instead")]
    protected override bool ProcessSend(byte[] buffer, int offset, int length)
    {
        return StartSend(buffer, offset, length);
    }

    /// <summary>
    /// Современная асинхронная реализация отправки данных через ReadOnlyMemory.
    /// </summary>
    protected override async ValueTask<bool> ProcessSendAsync(ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default)
    {
        if (State != ConnectionState.Working)
        {
            return false;
        }

        try
        {
            var sent = await BaseSocket.SendAsync(data, SocketFlags.None, cancellationToken).ConfigureAwait(false);
            if (sent == 0)
            {
                Close();
                return false;
            }
            return State != ConnectionState.Closed;
        }
        catch
        {
            Close();
            return false;
        }
    }

    /// <summary>
    /// Асинхронная отправка данных с использованием ValueTask.
    /// </summary>
    public override async ValueTask<bool> SendAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken = default)
    {
        if (State != ConnectionState.Working)
        {
            return false;
        }

        try
        {
            var sent = await BaseSocket.SendAsync(new ReadOnlyMemory<byte>(buffer, offset, length), SocketFlags.None, cancellationToken).ConfigureAwait(false);
            if (sent == 0)
            {
                Close();
                return false;
            }
            return State != ConnectionState.Closed;
        }
        catch
        {
            Close();
            return false;
        }
    }

    /// <summary>
    /// Асинхронная отправка данных с использованием ReadOnlyMemory.
    /// </summary>
    public override async ValueTask<bool> SendAsync(ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default)
    {
        if (State != ConnectionState.Working)
        {
            return false;
        }

        try
        {
            var sent = await BaseSocket.SendAsync(data, SocketFlags.None, cancellationToken).ConfigureAwait(false);
            if (sent == 0)
            {
                Close();
                return false;
            }
            return State != ConnectionState.Closed;
        }
        catch
        {
            Close();
            return false;
        }
    }

    /// <summary>
    /// Modern Pipe-based receive: fills the pipe from the socket (zero-copy).
    /// Provides automatic backpressure and buffer pooling.
    /// </summary>
    private async Task FillPipeAsync(PipeWriter writer, CancellationToken cancellationToken)
    {
        const int minimumBufferSize = 8192;

        try
        {
            while (State == ConnectionState.Working && !cancellationToken.IsCancellationRequested)
            {
                // Get memory from pipe's buffer (zero allocation, uses MemoryPool)
                Memory<byte> memory = writer.GetMemory(minimumBufferSize);

                try
                {
                    int bytesRead = await BaseSocket.ReceiveAsync(memory, SocketFlags.None, cancellationToken).ConfigureAwait(false);

                    if (bytesRead == 0)
                    {
                        break; // Connection closed
                    }

                    // Tell the PipeWriter how much was written
                    writer.Advance(bytesRead);
                }
                catch (OperationCanceledException)
                {
                    break; // Normal shutdown
                }
                catch
                {
                    break; // Error - exit loop
                }

                // Make the data available to the PipeReader
                FlushResult result = await writer.FlushAsync(cancellationToken).ConfigureAwait(false);

                if (result.IsCompleted)
                {
                    break; // Reader completed
                }
            }
        }
        catch (OperationCanceledException)
        {
            // Normal cancellation
        }
        catch
        {
            // Error occurred
        }
        finally
        {
            // Complete the PipeWriter to signal the reader
            await writer.CompleteAsync().ConfigureAwait(false);
            
            if (State == ConnectionState.Working)
            {
                Close();
            }
        }
    }

    /// <summary>
    /// Modern Pipe-based receive: processes data from the pipe.
    /// Provides zero-copy data access via ReadOnlySequence.
    /// </summary>
    private async Task ProcessPipeAsync(PipeReader reader, CancellationToken cancellationToken)
    {
        try
        {
            while (State == ConnectionState.Working && !cancellationToken.IsCancellationRequested)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
                ReadOnlySequence<byte> buffer = result.Buffer;

                try
                {
                    // Process the data
                    if (buffer.Length > 0)
                    {
                        ProcessPipeBuffer(buffer);
                    }

                    // Tell the PipeReader how much was consumed
                    reader.AdvanceTo(buffer.End);
                }
                catch
                {
                    // Error processing - still need to advance
                    reader.AdvanceTo(buffer.End);
                    throw;
                }

                if (result.IsCompleted)
                {
                    break;
                }
            }
        }
        catch (OperationCanceledException)
        {
            // Normal cancellation
        }
        catch
        {
            // Error occurred
        }
        finally
        {
            await reader.CompleteAsync().ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Process data from ReadOnlySequence (handles both single and multi-segment buffers).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ProcessPipeBuffer(ReadOnlySequence<byte> buffer)
    {
        if (buffer.IsSingleSegment)
        {
            // Fast path: single contiguous buffer
            ProcessReceive(buffer.FirstSpan);
        }
        else
        {
            // Multi-segment buffer: process each segment or copy to array
            // For simplicity, copy to array. For max performance, could process segments individually.
            if (buffer.Length <= 81920) // 80KB threshold for stackalloc
            {
                Span<byte> tempBuffer = stackalloc byte[(int)buffer.Length];
                buffer.CopyTo(tempBuffer);
                ProcessReceive(tempBuffer);
            }
            else
            {
                // Large buffer: use array
                byte[] tempArray = buffer.ToArray();
                ProcessReceive(tempArray.AsSpan());
            }
        }
    }

    /// <summary>
    /// Устаревший асинхронный цикл приема данных.
    /// Используется только если UsePipelineMode = false.
    /// Для максимальной производительности используйте режим Pipes (по умолчанию).
    /// </summary>
    [Obsolete("Use Pipe-based receive (UsePipelineMode = true) for better performance")]
    private async Task ReceiveLoopAsync(CancellationToken cancellationToken)
    {
        var buffer = new byte[SocketReceiveArgs?.Buffer?.Length ?? 8192];
        
        while (State == ConnectionState.Working && !cancellationToken.IsCancellationRequested)
        {
            try
            {
                var received = await BaseSocket.ReceiveAsync(buffer, SocketFlags.None, cancellationToken).ConfigureAwait(false);
                
                if (received <= 0)
                {
                    Close();
                    return;
                }

#if !DEBUG
                try
                {
#endif
                    if (State != ConnectionState.Closed)
                    {
                        ProcessReceive(buffer.AsSpan(0, received));
                    }
#if !DEBUG
                }
                catch
                {
                    Close();
                    return;
                }
#endif
            }
            catch (OperationCanceledException)
            {
                // Normal shutdown
                return;
            }
            catch
            {
                Close();
                return;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool StartSend(byte[] buffer, int offset, int count)
    {
        if (State != ConnectionState.Working)
        {
            return false;
        }
        try
        {
            var len = BaseSocket.Send(buffer.AsSpan(offset, count), SocketFlags.None, out SocketError errorCode);
            if (len == 0 || errorCode != SocketError.Success)
            {
                Close();
            }
            return State != ConnectionState.Closed;
        }
        catch
        {
            Close();
            return false;
        }
    }

    // Keep event-based methods for backward compatibility with SocketAsyncEventArgs
    private void socketArgsRecv_Completed(object? sender, SocketAsyncEventArgs e)
    {
        ReceiveProcess(e);
    }
    private void socketArgsSend_Completed(object? sender, SocketAsyncEventArgs e)
    {
        SendProcess(e);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ReceiveProcess(SocketAsyncEventArgs socketArgs)
    {
        try
        {
            if (socketArgs.SocketError != SocketError.Success ||
                socketArgs.BytesTransferred <= 0)
            {
                Close();
                return;
            }
        }
        catch
        {
            Close();
            return;
        }
#if !DEBUG
            try
            {
#endif
        if (State != ConnectionState.Closed && socketArgs.Buffer != null)
        {
            // Используем Span для оптимизации
            ProcessReceive(socketArgs.Buffer.AsSpan(socketArgs.Offset, socketArgs.BytesTransferred));
        }
#if !DEBUG
            }
            catch
            {
                Close();
                return;
            }
#endif
    }
    private void SendProcess(SocketAsyncEventArgs socketArgs)
    {
        try
        {
            if (socketArgs.SocketError != SocketError.Success ||
                socketArgs.BytesTransferred <= 0)
            {
                Close();
                return;
            }
        }
        catch
        {
            Close();
        }
    }
}