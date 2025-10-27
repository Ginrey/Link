using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Link.Pools;

namespace Link.Net
{
    public class TcpSocketListner : IActiveConnectionFactory
    {
        public event ConnectionEventHandler? ConnectionAccept;

        protected readonly object startLock = new object();

        public int BackLog { get; set; }

        public IPool<SocketAsyncEventArgs> SocketAsyncEventArgsReceivePool { get; set; }
        public IPool<SocketAsyncEventArgs> SocketAsyncEventArgsSendPool { get; set; }

        public IPEndPoint LocalEndPoint { get; private set; }

        public bool Started { get; private set; }
        public Socket? BaseSocket { get; private set; }
        public TcpSocketListner(IPEndPoint endPoint, int backLog = 32)
        {
            BackLog = backLog;
            LocalEndPoint = endPoint;

            SocketAsyncEventArgsReceivePool = SocketAsyncEventArgsPool.ReceiveInstance;
            SocketAsyncEventArgsSendPool = SocketAsyncEventArgsPool.SendInstance;
        }
        public TcpSocketListner(IPAddress ipAddress, int backLog = 32, int port = 29000) : this(new IPEndPoint(ipAddress, port), backLog)
        {

        }
        public TcpSocketListner(int backLog = 32, int port = 29000) : this(new IPEndPoint(IPAddress.Any, port), backLog)
        {
        }

        public virtual void Start()
        {
            lock (startLock)
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
        }
        public virtual void Stop()
        {
            lock (startLock)
            {
                if (!Started)
                {
                    return;
                }
                DisposeSocket(BaseSocket);
                Started = false;
            }
        }

        protected virtual void BeginAccept(Socket skt)
        {
            if (!Started || !object.ReferenceEquals(skt, BaseSocket))
            {
                DisposeSocket(skt);
                return;
            }
            try
            {
                // Используем более современный асинхронный подход
                _ = AcceptLoopAsync(skt);
            }
            catch
            {
                if (!Started || !object.ReferenceEquals(skt, BaseSocket))
                {
                    DisposeSocket(skt);
                    return;
                }
                Stop();
            }
        }

        /// <summary>
        /// Асинхронный цикл принятия соединений (современный подход).
        /// </summary>
        protected virtual async Task AcceptLoopAsync(Socket skt)
        {
            while (Started && object.ReferenceEquals(skt, BaseSocket))
            {
                try
                {
                    var client = await skt.AcceptAsync().ConfigureAwait(false);
                    
                    if (!Started || !object.ReferenceEquals(skt, BaseSocket))
                    {
                        DisposeSocket(client);
                        break;
                    }

                    var socketConnection = new SocketConnection(
                        client,
                        SocketAsyncEventArgsReceivePool,
                        SocketAsyncEventArgsSendPool);
                    ConnectionAccept?.Invoke(this, new ConnectionEventArgs(socketConnection));
                }
                catch
                {
                    if (!Started || !object.ReferenceEquals(skt, BaseSocket))
                    {
                        DisposeSocket(skt);
                        break;
                    }
                }
            }
        }

        [Obsolete("Use AcceptLoopAsync instead")]
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
            if (!Started || !object.ReferenceEquals(skt, BaseSocket))
            {
                DisposeSocket(client);
                DisposeSocket(skt);
                return;
            }
            if (skt != null)
                BeginAccept(skt);

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
        public virtual void Free(Connection connection)
        {
            connection?.Close();
        }
    }
}
