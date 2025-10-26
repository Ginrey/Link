using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Link.Net
{
    public class TcpSocketListner : IActiveConnectionFactory
    {
        public event ConnectionEventHandler ConnectionAccept;

        private readonly Socket _listenSocket;
        private CancellationTokenSource _cts;

        public IPEndPoint LocalEndPoint { get; }
        public bool IsListening { get; private set; }

        public TcpSocketListner(IPEndPoint endPoint, int backLog = 128)
        {
            LocalEndPoint = endPoint ?? throw new ArgumentNullException(nameof(endPoint));
            _listenSocket = new Socket(LocalEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _listenSocket.Bind(LocalEndPoint);
            _listenSocket.Listen(backLog);
        }

        public TcpSocketListner(IPAddress ipAddress, int port = 29000, int backLog = 128)
            : this(new IPEndPoint(ipAddress ?? IPAddress.Any, port), backLog)
        {
        }

        public void Start()
        {
            if (IsListening) return;

            IsListening = true;
            _cts = new CancellationTokenSource();
            Task.Run(() => AcceptLoopAsync(_cts.Token));
        }

        public void Stop()
        {
            if (!IsListening) return;

            IsListening = false;
            _cts?.Cancel();
            _listenSocket.Dispose();
        }

        private async Task AcceptLoopAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    Socket clientSocket = await _listenSocket.AcceptAsync(token);
                    var socketConnection = new SocketConnection(clientSocket);

                    // The event is synchronous, but the handler might do async work.
                    // To avoid blocking the accept loop, we can run the handler in the background.
                    // This is a design choice that depends on the expected behavior of the event handlers.
                    _ = Task.Run(() => ConnectionAccept?.Invoke(this, new ConnectionEventArgs(socketConnection)), token);
                }
            }
            catch (OperationCanceledException)
            {
                // Expected when stopping.
            }
            catch (SocketException)
            {
                // Can happen if the socket is closed while AcceptAsync is pending.
                // Add logging here if needed.
            }
            finally
            {
                IsListening = false;
            }
        }

        public void Free(Connection connection)
        {
            connection?.Close();
        }
    }
}
