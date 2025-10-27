using Link.IO;
using Link.Net;

namespace Link.Modules;

public class ContainerModule : ProtoModuleBase
{
    public override void RegisterHandlers()
    {
        Register(0x00, ReceivedContainer, PacketHandlerPriority.System);
    }

    private void ReceivedContainer(object sender, PacketEventArgs e)
    {
        if (e.IsComplete) return;
        
        e.Packet.Stream.IsLittleEndian = true;
        
        while (e.Packet.Stream.CanReadBytes(1))
        {
            var packetId = e.Packet.Stream.ReadCompactUInt32();
            var packetLength = (int) e.Packet.Stream.ReadCompactUInt32();

            if (packetId == 0x22)
            {
                var containerStream = e.Packet.Stream.ReadDataStream();
                var containerId = containerStream.ReadUInt16();
                containerStream.Flush();
                Session.InputChain?.Send(Session.GetPacket((uint) containerId, containerStream));
            }
            else
            {
                var packetStream = new DataStream(e.Packet.Stream.ReadBytes(packetLength)) {IsLittleEndian = false};
                Session.InputChain?.Send(Session.GetPacket(packetId, packetStream));
            }
        }
    }
}
