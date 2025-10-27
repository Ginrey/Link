using System;
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
            // Start async receive loop
            _ = ReceiveLoopAsync(_receiveCts.Token);
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
    /// Современный асинхронный цикл приема данных.
    /// Заменяет старый подход на основе событий на современный async/await.
    /// </summary>
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