using System;
using System.Runtime.CompilerServices;
using Link.IO;
using Link.Pools;

namespace Link.Net;

public class PacketReader
{
    private Func<bool>[] dataReaders;

    public PacketReaderState State { get; private set; }
    public uint PacketId { get; private set; }
    public uint PacketLength { get; private set; }
    public DataStream PacketStream { get; private set; }
    public PacketPolicyState PolicyState { get; set; }

    public DataStream NetworkStream { get; }

    public PacketReader(DataStream? networkStream = null, DataStream? packetStream = null)
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
        dataReaders = new Func<bool>[]
        {
            ReadId, ReadLength, ReadContent, ReadComplete
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void UpdatePolicy(PacketPolicyState newPolicy)
    {
        if (newPolicy > PolicyState)
        {
            PolicyState = newPolicy;
        }
    }
        
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset()
    {
        PolicyState = PacketPolicyState.Accept;
        State = PacketReaderState.WaitingId;
        PacketId = 0;
        PacketLength = 0;
        PacketStream.Clear();

        if ((NetworkStream.Count >> 1) <= NetworkStream.Position)
        {
            NetworkStream.Flush();
        }

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear()
    {
        Reset();
        NetworkStream.Clear();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool ReadNext()
    {
        var id = (int)State;
        return dataReaders[id].Invoke();
    }

    private bool ReadId()
    {
        uint packetId;
        var result = NetworkStream.TryReadCompactUInt32(out packetId);
        PacketId = packetId;

        if (result)
        {
            State = PacketReaderState.WaitingLength;
        }
        return result;
    }

    private bool ReadLength()
    {
        uint packetLength;
        var result = NetworkStream.TryReadCompactUInt32(out packetLength);
        PacketLength = packetLength;

        if (result)
        {
            State = PacketReaderState.WaitingContent;
        }
        return result;
    }

    private bool ReadContent()
    {
        if (!NetworkStream.CanReadBytes((int)PacketLength))
        {
            return false;
        }
        PacketStream.Resize((int)PacketLength);
            
        // Use Span-based read for better performance
        var result = NetworkStream.TryReadBytes(PacketStream.Buffer.AsSpan(0, (int)PacketLength));
        if (result)
        {
            State = PacketReaderState.Complete;
        }
        return result;
    }

    private bool ReadComplete()
    {
        Reset();
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushBack(byte[] buffer, int offset, int length)
    {
        NetworkStream.PushBack(buffer, offset, length);
    }

    /// <summary>
    /// Modern Span-based PushBack for better performance.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushBack(ReadOnlySpan<byte> data)
    {
        NetworkStream.PushBack(data);
    }
}