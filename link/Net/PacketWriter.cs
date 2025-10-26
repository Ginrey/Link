using System;
using Link.IO;

namespace Link.Net
{
    public class PacketWriter : IDisposable
    {
        private readonly DataStream _networkStream;
        private readonly DataStream _packetStream;
        private bool _disposed;

        public DataStream NetworkStream => _networkStream;
        public DataStream PacketStream => _packetStream;

        public PacketWriter()
        {
            _networkStream = new DataStream();
            _packetStream = new DataStream();
        }

        public void Clear()
        {
            _networkStream.Clear();
        }

        public void Write(uint packetId, IDataSerializer packet)
        {
            _packetStream.Clear();
            packet.Serialize(_packetStream);
            Write(packetId, _packetStream.Span);
        }

        public void Write(Packet packet)
        {
            Write(packet.Id, packet.Stream.Span);
        }

        public void Write(uint packetId, ReadOnlySpan<byte> packetContent)
        {
            _networkStream.WriteCompactUInt32(packetId);
            _networkStream.WriteCompactUInt32((uint)packetContent.Length);
            _networkStream.Write(packetContent);
        }

        public ReadOnlySpan<byte> GetBuffer()
        {
            return _networkStream.Span;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _networkStream.Dispose();
            _packetStream.Dispose();
            _disposed = true;
        }
    }
}
