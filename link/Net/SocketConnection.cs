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
    private Socket BaseSocket { get; }

    private IPool<SocketAsyncEventArgs> ReceivePool { get; }
    private IPool<SocketAsyncEventArgs> SendPool { get; }
    private CancellationTokenSource? _receiveCts;

    public SocketConnection(Socket socket, IPool<SocketAsyncEventArgs> receivePool,
        IPool<SocketAsyncEventArgs> sendPool)
    {
        BaseSocket = socket;

        SendPool = sendPool;
        ReceivePool = receivePool;
    }

    public SocketConnection(Socket socket) : this(
        socket,
        SocketAsyncEventArgsPool.ReceiveInstance,
        SocketAsyncEventArgsPool.SendInstance)
    {
    }

    public SocketConnection(SocketType socketType, ProtocolType protocolType) : this(new Socket(socketType,
        protocolType))
    {
    }

    public SocketConnection(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) : this(
        new Socket(addressFamily, socketType, protocolType))
    {
    }

    private readonly ManualResetEventSlim _stateChanging = new(true);

    private Pipe? _receivePipe;
    private Task? _fillPipeTask;
    private Task? _processPipeTask;

    public override async Task Start()
    {
        _stateChanging.Wait(); // Ждем завершения любых предыдущих операций изменения состояния
        _stateChanging.Reset(); // Блокируем новые операции

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
            _stateChanging.Set(); // Разрешаем новые операции
        }
    }

    public override async Task Stop()
    {
        _stateChanging.Wait();
        _stateChanging.Reset();
        
        try
        {
            await _receiveCts?.CancelAsync();
            
            State = ConnectionState.NotWorking;
        }
        finally
        {
            _stateChanging.Set();
        }
    }

    public override async Task Close()
    {
        _stateChanging.Wait();
        _stateChanging.Reset();
        
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
                // ignored
            }

            try
            {
                BaseSocket.Dispose();
            }
            catch
            {
                // ignored
            }

            State = ConnectionState.Closed;
        }
        finally
        {
            _stateChanging.Set();
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
    public override async ValueTask<bool> SendAsync(byte[] buffer, int offset, int length,
        CancellationToken cancellationToken = default)
    {
        if (State != ConnectionState.Working)
        {
            return false;
        }

        try
        {
            var sent = await BaseSocket
                .SendAsync(new ReadOnlyMemory<byte>(buffer, offset, length), SocketFlags.None, cancellationToken)
                .ConfigureAwait(false);
            
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

                int bytesRead;
                try
                {
                    bytesRead = await BaseSocket.ReceiveAsync(memory, SocketFlags.None, cancellationToken).ConfigureAwait(false);
                    
                    // DEBUG: Remove after testing
                    Console.WriteLine($"[FillPipe] Received {bytesRead} bytes. State: {State}");

                    if (bytesRead == 0)
                    {
                        Console.WriteLine($"[FillPipe] Connection closed gracefully (0 bytes received)");
                        break; // Connection closed
                    }

                    // Tell the PipeWriter how much was written
                    writer.Advance(bytesRead);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine($"[FillPipe] Operation canceled");
                    break; // Normal shutdown
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[FillPipe] Exception: {ex.GetType().Name}: {ex.Message}");
                    break; // Error - exit loop
                }

                // Make the data available to the PipeReader
                var result = await writer.FlushAsync(cancellationToken).ConfigureAwait(false);

                if (result.IsCompleted)
                {
                    Console.WriteLine($"[FillPipe] PipeReader completed");
                    break; // Reader completed
                }
            }
            
            Console.WriteLine($"[FillPipe] Exiting loop. State: {State}, Canceled: {cancellationToken.IsCancellationRequested}");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"[FillPipe] Outer OperationCanceledException");
            // Normal cancellation
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[FillPipe] Outer Exception: {ex.GetType().Name}: {ex.Message}");
            // Error occurred
        }
        finally
        {
            // Complete the PipeWriter to signal the reader
            await writer.CompleteAsync().ConfigureAwait(false);
            Console.WriteLine($"[FillPipe] PipeWriter completed");

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

                Console.WriteLine($"[ProcessPipe] Read buffer: {buffer.Length} bytes, IsCompleted: {result.IsCompleted}, IsCanceled: {result.IsCanceled}");

                try
                {
                    // Process the data
                    if (buffer.Length > 0)
                    {
                        Console.WriteLine($"[ProcessPipe] Processing {buffer.Length} bytes");
                        await ProcessPipeBufferAsync(buffer, cancellationToken);
                    }

                    // Tell the PipeReader how much was consumed
                    reader.AdvanceTo(buffer.End);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ProcessPipe] Processing exception: {ex.GetType().Name}: {ex.Message}");
                    // Error processing - still need to advance
                    reader.AdvanceTo(buffer.End);
                    throw;
                }

                if (result.IsCompleted)
                {
                    Console.WriteLine($"[ProcessPipe] PipeWriter completed, exiting");
                    break;
                }
            }
            
            Console.WriteLine($"[ProcessPipe] Exiting loop. State: {State}, Canceled: {cancellationToken.IsCancellationRequested}");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"[ProcessPipe] OperationCanceledException");
            // Normal cancellation
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ProcessPipe] Exception: {ex.GetType().Name}: {ex.Message}");
            // Error occurred
        }
        finally
        {
            await reader.CompleteAsync().ConfigureAwait(false);
            Console.WriteLine($"[ProcessPipe] PipeReader completed");
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
                await ProcessReceiveAsync(new ReadOnlyMemory<byte>(rented, 0, length), cancellationToken)
                    .ConfigureAwait(false);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(rented);
            }
        }
    }
}
