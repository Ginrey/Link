using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Link.Pools;

namespace Link.Net;

public class TcpSocketListner : IActiveConnectionFactory
{
    private readonly SemaphoreSlim _startLock = new(1, 1);

    public event ConnectionEventHandler? ConnectionAccept;

    public int BackLog { get; set; }

    public IPool<SocketAsyncEventArgs> SocketAsyncEventArgsReceivePool { get; set; }
    public IPool<SocketAsyncEventArgs> SocketAsyncEventArgsSendPool { get; set; }

    public IPEndPoint LocalEndPoint { get; }

    public bool Started { get; private set; }
    public Socket? BaseSocket { get; private set; }

    public TcpSocketListner(IPEndPoint endPoint, int backLog = 32)
    {
        BackLog = backLog;
        LocalEndPoint = endPoint ?? throw new ArgumentNullException(nameof(endPoint));

        SocketAsyncEventArgsReceivePool = SocketAsyncEventArgsPool.ReceiveInstance;
        SocketAsyncEventArgsSendPool = SocketAsyncEventArgsPool.SendInstance;
    }

    public TcpSocketListner(IPAddress ipAddress, int backLog = 32, int port = 29000)
        : this(new IPEndPoint(ipAddress, port), backLog)
    {
    }

    public TcpSocketListner(int backLog = 32, int port = 29000)
        : this(new IPEndPoint(IPAddress.Any, port), backLog)
    {
    }

    public virtual void Start()
    {
        _startLock.Wait();
        try
        {
            if (Started)
            {
                return;
            }
            BaseSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            BaseSocket.Bind(LocalEndPoint);
            BaseSocket.Listen(BackLog);

            Started = true;
            BeginAccept(BaseSocket);
        }
        finally
        {
            _startLock.Release();
        }
    }

    public virtual async Task StartAsync(CancellationToken cancellationToken = default)
    {
        await _startLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (Started)
            {
                return;
            }
            BaseSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            BaseSocket.Bind(LocalEndPoint);
            BaseSocket.Listen(BackLog);

            Started = true;
            BeginAccept(BaseSocket);
        }
        finally
        {
            _startLock.Release();
        }
    }

    public virtual void Stop()
    {
        _startLock.Wait();
        try
        {
            if (!Started)
            {
                return;
            }
            DisposeSocket(BaseSocket);
            Started = false;
        }
        finally
        {
            _startLock.Release();
        }
    }

    public virtual async Task StopAsync(CancellationToken cancellationToken = default)
    {
        await _startLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (!Started)
            {
                return;
            }
            DisposeSocket(BaseSocket);
            Started = false;
        }
        finally
        {
            _startLock.Release();
        }
    }

    protected virtual void BeginAccept(Socket skt)
    {
        if (!Started || !ReferenceEquals(skt, BaseSocket))
        {
            DisposeSocket(skt);
            return;
        }
        try
        {
            skt.AcceptAsync().ContinueWith(EndAccept, skt);
        }
        catch
        {
            if (!Started || !ReferenceEquals(skt, BaseSocket))
            {
                DisposeSocket(skt);
                return;
            }
            Stop();
        }
    }

    protected virtual void EndAccept(Task<Socket> task, object? state)
    {
        var skt = state as Socket;
        Socket? client = null;
        try
        {
            if (task.IsCompleted && !task.IsCanceled && !task.IsFaulted)
            {
                client = task.Result;
            }
        }
        catch
        {
            DisposeSocket(client);
            DisposeSocket(skt);
            return;
        }
        if (!Started || !ReferenceEquals(skt, BaseSocket))
        {
            DisposeSocket(client);
            DisposeSocket(skt);
            return;
        }
        BeginAccept(skt!);

        if (client != null)
        {
            var socketConnection = new SocketConnection(
                client,
                SocketAsyncEventArgsReceivePool,
                SocketAsyncEventArgsSendPool);
            ConnectionAccept?.Invoke(this, new ConnectionEventArgs(socketConnection));
        }
    }

    protected static void DisposeSocket(Socket? skt)
    {
        if (skt == null) return;
        try
        {
            skt.Shutdown(SocketShutdown.Both);
        }
        catch
        {
        }
        try
        {
            skt.Dispose();
        }
        catch
        {
        }
    }

    public virtual void Free(Connection? connection)
    {
        connection?.Close();
    }
}
