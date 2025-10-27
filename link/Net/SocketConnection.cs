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
    // public SocketAsyncEventArgs? SocketReceiveArgs { get; private set; }
    // public SocketAsyncEventArgs? SocketSendArgs { get; private set; }

    private IPool<SocketAsyncEventArgs> ReceivePool { get; }
    private IPool<SocketAsyncEventArgs> SendPool { get; }
    private CancellationTokenSource? _receiveCts;
    private readonly SemaphoreSlim _stateSemaphore = new(1, 1);

    public SocketConnection(Socket socket, IPool<SocketAsyncEventArgs> receivePool, IPool<SocketAsyncEventArgs> sendPool)
    {
        BaseSocket = socket;

        SendPool = sendPool;
        ReceivePool = receivePool;

        // SocketReceiveArgs = receivePool.Take();
        // SocketSendArgs = sendPool.Take();
        //
        // SocketReceiveArgs.Completed += socketArgsRecv_Completed;
        // SocketSendArgs.Completed += socketArgsSend_Completed;
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

    public override async Task Start()
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

            _receivePipe = new Pipe(new PipeOptions(
                pool: MemoryPool<byte>.Shared,
                pauseWriterThreshold: 1024 * 1024, // 1MB backpressure
                resumeWriterThreshold: 512 * 1024, // 512KB resume
                useSynchronizationContext: false
            ));

            _fillPipeTask = FillPipeAsync(_receivePipe.Writer, _receiveCts.Token);
            _processPipeTask = ProcessPipeAsync(_receivePipe.Reader, _receiveCts.Token);
        }
        finally
        {
            _stateSemaphore.Release();
        }
    }

    public override async Task Stop()
    {
        await _stateSemaphore.WaitAsync().ConfigureAwait(false);
        try
        {
            await _receiveCts?.CancelAsync();
            State = ConnectionState.NotWorking;
        }
        finally
        {
            _stateSemaphore.Release();
        }
    }

    public override async Task Close()
    {
        await _stateSemaphore.WaitAsync().ConfigureAwait(false);
        try
        {
            await _receiveCts?.CancelAsync();
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
            // if (SocketReceiveArgs != null)
            // {
            //     SocketReceiveArgs.Completed -= socketArgsRecv_Completed;
            //     ReceivePool.Return(SocketReceiveArgs);
            // }
            // if (SocketSendArgs != null)
            // {
            //     SocketSendArgs.Completed -= socketArgsSend_Completed;
            //     SendPool.Return(SocketSendArgs);
            // }
        }
        finally
        {
            _stateSemaphore.Release();
        }
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
                await Close();
                return false;
            }
            
            return State != ConnectionState.Closed;
        }
        catch
        {
            await Close();
            
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
                await Close();
                return false;
            }
            return State != ConnectionState.Closed;
        }
        catch
        {
            await Close();
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
                await Close();
                return false;
            }
            return State != ConnectionState.Closed;
        }
        catch
        {
            await Close();
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
                var memory = writer.GetMemory(minimumBufferSize);

                try
                {
                    var bytesRead = await BaseSocket.ReceiveAsync(memory, SocketFlags.None, cancellationToken).ConfigureAwait(false);

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
                var result = await writer.FlushAsync(cancellationToken).ConfigureAwait(false);

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
                await Close();
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
                var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
                var buffer = result.Buffer;

                try
                {
                    // Process the data
                    if (buffer.Length > 0)
                    {
                        await ProcessPipeBufferAsync(buffer, cancellationToken);
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
    private async Task ProcessPipeBufferAsync(ReadOnlySequence<byte> buffer, CancellationToken cancellationToken = default)
    {
        if (buffer.IsSingleSegment)
        {
            await ProcessReceiveAsync(buffer.First, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            var length = (int)buffer.Length;
            var rented = ArrayPool<byte>.Shared.Rent(length);
            try
            {
                buffer.CopyTo(rented);
                await ProcessReceiveAsync(new ReadOnlyMemory<byte>(rented, 0, length), cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(rented);
            }
        }
    }
  
}
