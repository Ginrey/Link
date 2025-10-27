using System;
using System.Runtime.CompilerServices;
using Link.IO;
using Link.Pools;

namespace Link.Net;

public class PacketWriter
{
    public DataStream NetworkStream { get; }

    public DataStream PacketStream { get; }

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

        NetworkStream = networkStream;
        PacketStream = packetStream;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear()
    {
        NetworkStream.Clear();
    }

    public void Write(uint packetId, IDataSerializer packet)
    {
        PacketStream.Clear();
        PacketStream.Write(packet);
        Write(packetId, PacketStream);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(Packet packet)
    {
        Write(packet.Id, packet.Stream);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(uint packetId, DataStream packetStream)
    {
        NetworkStream.WriteCompactUInt32(packetId);
        NetworkStream.WriteCompactUInt32(packetStream.Count);
        NetworkStream.PushBack(packetStream.AsReadOnlySpan());
    }

    /// <summary>
    /// Modern Span-based write method for better performance.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(uint packetId, ReadOnlySpan<byte> packetData)
    {
        NetworkStream.WriteCompactUInt32(packetId);
        NetworkStream.WriteCompactUInt32((uint)packetData.Length);
        NetworkStream.PushBack(packetData);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ArraySegment<byte> GetBuffer()
    {
        return new ArraySegment<byte>(NetworkStream.Buffer, 0, NetworkStream.Count);
    }

    /// <summary>
    /// Modern Span-based accessor for network buffer.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<byte> GetBufferSpan()
    {
        return NetworkStream.AsReadOnlySpan();
    }

    /// <summary>
    /// Modern Memory-based accessor for network buffer.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyMemory<byte> GetBufferMemory()
    {
        return NetworkStream.AsMemory();
    }
}