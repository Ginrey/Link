using System.IO.Pipelines;
using Link.Pools;
using Link.IO;
using Link.Modules;

namespace Link.Net
{
    public class ClientSession : Session
    {
        public Connector Connector { get; private set; }

        public ClientSession(string server,
            PipeReader pipeReader,
            IPool<DataStream> dataStreamPool = null, 
            PacketWriter packetWriter = null,
            PacketPolicy packetPolicy = null) : base(pipeReader, dataStreamPool, packetWriter, packetPolicy)
        {
            Initialize(new TcpSocketOpener(server));
        }

        public ClientSession(IPassiveConnectionFactory factory,
            PipeReader pipeReader,
            IPool<DataStream> dataStreamPool = null, 
            PacketWriter packetWriter = null,
            PacketPolicy packetPolicy = null) : base(pipeReader, dataStreamPool, packetWriter, packetPolicy)
        {
            Initialize(factory);
        }

        private void Initialize(IPassiveConnectionFactory factory)
        {
            Connector = Modules.Register<Connector>();
            Connector.ConnectionFactory = factory;
        }

        public void Connect()
        {
            Connector.Connect();
        }

        public override void Close()
        {
            Connector.Close();
        }
    }
}
