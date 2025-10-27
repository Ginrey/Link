using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Link.IO;
using Link.Pools;

namespace Link.Net;

public class SocketConnection : Connection
{
    private readonly SemaphoreSlim _sendLock = new(1, 1);
    private readonly SemaphoreSlim _lock = new(1, 1);

    public Socket BaseSocket { get; }
    public SocketAsyncEventArgs SocketReceiveArgs { get; private set; }
    public SocketAsyncEventArgs SocketSendArgs { get; private set; }

    private IPool<SocketAsyncEventArgs> ReceivePool { get; }
    private IPool<SocketAsyncEventArgs> SendPool { get; }

    public SocketConnection(Socket socket, IPool<SocketAsyncEventArgs> receivePool, IPool<SocketAsyncEventArgs> sendPool)
    {
        BaseSocket = socket;

        SendPool = sendPool;
        ReceivePool = receivePool;

        SocketReceiveArgs = receivePool.Take();
        SocketSendArgs = sendPool.Take();

        SocketReceiveArgs.Completed += SocketArgsRecv_Completed;
        SocketSendArgs.Completed += SocketArgsSend_Completed;
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

    public override void Start()
    {
        _lock.Wait();
        try
        {
            if (State == ConnectionState.Working)
            {
                return;
            }
            State = ConnectionState.Working;
            StartReceive();
        }
        finally
        {
            _lock.Release();
        }
    }

    public override void Stop()
    {
        _lock.Wait();
        try
        {
            State = ConnectionState.NotWorking;
        }
        finally
        {
            _lock.Release();
        }
    }

    public override void Close()
    {
        _lock.Wait();
        try
        {
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
            SocketReceiveArgs.Completed -= SocketArgsRecv_Completed;
            SocketSendArgs.Completed -= SocketArgsSend_Completed;
            ReceivePool.Return(SocketReceiveArgs);
            SendPool.Return(SocketSendArgs);
        }
        finally
        {
            _lock.Release();
        }
    }

    protected override bool ProcessSend(byte[] buffer, int offset, int length)
    {
        return StartSend(buffer, offset, length);
    }

    protected override async ValueTask<bool> ProcessSendAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken)
    {
        if (State != ConnectionState.Working)
        {
            return false;
        }

        await _sendLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            int sent = await BaseSocket.SendAsync(new ArraySegment<byte>(buffer, offset, length), SocketFlags.None, cancellationToken).ConfigureAwait(false);
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
        finally
        {
            _sendLock.Release();
        }
    }

    private void StartReceive()
    {
        if (State != ConnectionState.Working)
        {
            return;
        }
        try
        {
            if (!BaseSocket.ReceiveAsync(SocketReceiveArgs))
            {
                ReceiveProcess(SocketReceiveArgs);
            }
        }
        catch
        {
            Close();
        }
    }

    private bool StartSend(byte[] buffer, int offset, int count)
    {
        if (State != ConnectionState.Working)
        {
            return false;
        }
        try
        {
            var len = BaseSocket.Send(buffer, offset, count, SocketFlags.None, out SocketError errorCode);
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

    private void SocketArgsRecv_Completed(object? sender, SocketAsyncEventArgs e)
    {
        ReceiveProcess(e);
    }

    private void SocketArgsSend_Completed(object? sender, SocketAsyncEventArgs e)
    {
        SendProcess(e);
    }

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

        try
        {
            if (State != ConnectionState.Closed)
            {
                ProcessReceive(socketArgs.Buffer!, socketArgs.Offset, socketArgs.BytesTransferred);
            }
            StartReceive();
        }
        catch
        {
            Close();
        }
    }

    private void SendProcess(SocketAsyncEventArgs socketArgs)
    {
        try
        {
            if (socketArgs.SocketError != SocketError.Success)
            {
                Close();
            }
        }
        catch
        {
            Close();
        }
    }
}
