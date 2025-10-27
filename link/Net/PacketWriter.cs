using System;
using System.Runtime.CompilerServices;
using Link.IO;
using Link.Pools;

namespace Link.Net
{
    public class PacketWriter
    {
        private DataStream networkStream;
        private DataStream packetStream;

        public DataStream NetworkStream
        {
            get
            {
                return networkStream;
            }
        }
        public DataStream PacketStream
        {
            get
            {
                return packetStream;
            }
        }

        public PacketWriter(DataStream? networkStream = null, DataStream? packetStream = null)
        {
            if (networkStream == null)
            {
                networkStream = DataStreamPool.Instance.Take();
            }
            if (packetStream == null)
            {
                packetStream = DataStreamPool.Instance.Take();
            }

            this.networkStream = networkStream;
            this.packetStream = packetStream;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
            networkStream.Clear();
        }

        public void Write(uint packetId, IDataSerializer packet)
        {
            packetStream.Clear();
            packetStream.Write(packet);
            Write(packetId, packetStream);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(Packet packet)
        {
            Write(packet.Id, packet.Stream);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(uint packetId, DataStream packetStream)
        {
            networkStream.WriteCompactUInt32(packetId);
            networkStream.WriteCompactUInt32(packetStream.Count);
            networkStream.PushBack(packetStream.AsReadOnlySpan());
        }

        /// <summary>
        /// Modern Span-based write method for better performance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(uint packetId, ReadOnlySpan<byte> packetData)
        {
            networkStream.WriteCompactUInt32(packetId);
            networkStream.WriteCompactUInt32((uint)packetData.Length);
            networkStream.PushBack(packetData);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ArraySegment<byte> GetBuffer()
        {
            return new ArraySegment<byte>(networkStream.Buffer, 0, networkStream.Count);
        }

        /// <summary>
        /// Modern Span-based accessor for network buffer.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlySpan<byte> GetBufferSpan()
        {
            return networkStream.AsReadOnlySpan();
        }

        /// <summary>
        /// Modern Memory-based accessor for network buffer.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyMemory<byte> GetBufferMemory()
        {
            return networkStream.AsMemory();
        }
    }
}

