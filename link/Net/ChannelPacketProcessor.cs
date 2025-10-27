using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Link.IO;

namespace Link.Net;

/// <summary>
/// Modern async packet processor using System.Threading.Channels.
/// Provides high-performance, backpressure-aware packet processing pipeline.
/// </summary>
public class ChannelPacketProcessor : IDisposable
{
    private readonly Channel<Packet> _packetChannel;
    private readonly PacketReader _reader;
    private bool _disposed;

    /// <summary>
    /// Channel reader for consuming processed packets asynchronously.
    /// </summary>
    public ChannelReader<Packet> Packets => _packetChannel.Reader;

    /// <summary>
    /// Creates a new packet processor with unbounded channel (no backpressure).
    /// </summary>
    public ChannelPacketProcessor()
        : this(Channel.CreateUnbounded<Packet>(new UnboundedChannelOptions
        {
            SingleReader = false,
            SingleWriter = true,
            AllowSynchronousContinuations = false
        }))
    {
    }

    /// <summary>
    /// Creates a new packet processor with bounded channel (automatic backpressure).
    /// </summary>
    /// <param name="capacity">Maximum number of packets to buffer</param>
    /// <param name="fullMode">Behavior when channel is full</param>
    public ChannelPacketProcessor(int capacity, BoundedChannelFullMode fullMode = BoundedChannelFullMode.Wait)
        : this(Channel.CreateBounded<Packet>(new BoundedChannelOptions(capacity)
        {
            SingleReader = false,
            SingleWriter = true,
            AllowSynchronousContinuations = false,
            FullMode = fullMode
        }))
    {
    }

    /// <summary>
    /// Creates a new packet processor with custom channel.
    /// </summary>
    private ChannelPacketProcessor(Channel<Packet> channel)
    {
        _packetChannel = channel;
        _reader = new PacketReader();
    }

    /// <summary>
    /// Process incoming network data and publish complete packets to the channel.
    /// This method is async-ready and supports cancellation.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public async ValueTask ProcessDataAsync(ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        _reader.PushBack(data.Span);

        while (_reader.ReadNext())
        {
            if (_reader.State == PacketReaderState.Complete)
            {
                // Create packet from reader state
                var packet = new Packet(_reader.PacketId, _reader.PacketStream);
                
                // Write to channel (async with backpressure support)
                await _packetChannel.Writer.WriteAsync(packet, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// Synchronous version for backward compatibility.
    /// For best performance, use ProcessDataAsync.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ProcessData(ReadOnlySpan<byte> data)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        _reader.PushBack(data);

        while (_reader.ReadNext())
        {
            if (_reader.State == PacketReaderState.Complete)
            {
                var packet = new Packet(_reader.PacketId, _reader.PacketStream);
                
                // Use TryWrite for sync (non-blocking)
                if (!_packetChannel.Writer.TryWrite(packet))
                {
                    // Channel is full (only possible with bounded channels)
                    // In sync context, we drop the packet or block
                    // For production, consider using ProcessDataAsync instead
                    throw new InvalidOperationException("Channel is full. Use ProcessDataAsync for backpressure support.");
                }
            }
        }
    }

    /// <summary>
    /// Complete the channel writer (no more packets will be written).
    /// Call this when the connection is closed.
    /// </summary>
    public void Complete(Exception? error = null)
    {
        _packetChannel.Writer.Complete(error);
    }

    /// <summary>
    /// Consume packets from the channel asynchronously.
    /// </summary>
    /// <example>
    /// await foreach (var packet in processor.ReadPacketsAsync(ct))
    /// {
    ///     Console.WriteLine($"Received packet {packet.Id}");
    ///     await HandlePacketAsync(packet);
    /// }
    /// </example>
    public async IAsyncEnumerable<Packet> ReadPacketsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (var packet in _packetChannel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
        {
            yield return packet;
        }
    }

    /// <summary>
    /// Try to read a packet synchronously (non-blocking).
    /// </summary>
    /// <returns>True if a packet was read, false if channel is empty</returns>
    public bool TryReadPacket(out Packet? packet)
    {
        return _packetChannel.Reader.TryRead(out packet);
    }

    /// <summary>
    /// Wait for packet availability (async).
    /// </summary>
    public ValueTask<bool> WaitToReadAsync(CancellationToken cancellationToken = default)
    {
        return _packetChannel.Reader.WaitToReadAsync(cancellationToken);
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        _disposed = true;
        Complete();
        GC.SuppressFinalize(this);
    }
}
