using System.Collections.Generic;

namespace Link.Net;

using HandlersList = PacketHandlerList;
public class PacketHandlerTable : PacketTable<HandlersList, PacketEventHandler>
{
    public override void Clear()
    {
        Items.Clear();
        ItemsTable.Clear();
    }
    public override void Clear(uint packetId)
    {
        ItemsTable.Remove(packetId);
    }

    public override IEnumerable<PacketEventHandler> Enumerate(uint packetId)
    {
        foreach (var handler in Items.Handlers)
        {
            yield return handler;
        }
        HandlersList list;
        if (ItemsTable.TryGetValue(packetId, out list))
        {
            foreach (var handler in list.Handlers)
            {
                yield return handler;
            }
        }
    }

    public void ProcessPacket(PacketEventArgs args)
    {
        foreach (var handler in Enumerate(args.Packet.Id))
        {
            handler?.Invoke(this, args);
        }
    }
}