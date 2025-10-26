using System.Net.Sockets;
using System.Threading.Tasks;

namespace Link.Net
{
    public class TcpSocketOpener : IPassiveConnectionFactory
    {
        public ServerInfo ServerInfo { get; set; }

        public TcpSocketOpener() : this(ServerInfo.Local)
        {
        }
        public TcpSocketOpener(string server) : this(ServerInfo.Parse(server))
        {
        }
        public TcpSocketOpener(string host, int port) : this(new ServerInfo(host, port))
        {
        }
        public TcpSocketOpener(string name, string host, int port) : this(new ServerInfo(name, host, port))
        {
        }
        public TcpSocketOpener(ServerInfo serverInfo)
        {
            ServerInfo = serverInfo;
        }

        public async Task<Connection> TakeAsync()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await socket.ConnectAsync(ServerInfo.Host, ServerInfo.Port);
            return new SocketConnection(socket);
        }

        // The interface requires a synchronous Take method. This is a compromise.
        // The ideal solution would be to make the interface async.
        public Connection Take()
        {
            // This is a blocking call and should be avoided.
            // It's implemented to satisfy the interface requirement.
            return TakeAsync().GetAwaiter().GetResult();
        }

        public void Free(Connection connection)
        {
            connection?.Close();
        }
    }
}
