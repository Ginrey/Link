using System;
using System.Net.Sockets;

namespace Link.Pools;

using SocketAsyncEventArgsPoolInstance = PoolInstance<SocketAsyncEventArgsPool, SocketAsyncEventArgs>;

public sealed class SocketAsyncEventArgsPool : StackPool<SocketAsyncEventArgs>
{
    public const int DefaultBufferSize = 4096;

    public static readonly SocketAsyncEventArgsPoolInstance SendInstance = new(new SocketAsyncEventArgsPool());
    public static readonly SocketAsyncEventArgsPoolInstance ReceiveInstance = new(new SocketAsyncEventArgsPool());

    public BufferPool BufferPool { get; }

    public SocketAsyncEventArgsPool(BufferPool? bufferPool = null, int bufferSize = DefaultBufferSize, bool fixedBufferSize = false)
    {
        BufferPool = bufferPool ?? new BufferPool(bufferSize, fixedBufferSize);
    }

    public override bool Return(SocketAsyncEventArgs item, bool force)
    {
        if (item?.Buffer is { Length: > 0 } && item.Count > 0)
        {
            BufferPool.Return(item.Buffer, item.Offset, item.Count);
        }
        Reset(item);
        Cleanup(item);
        return false;
    }

    public override SocketAsyncEventArgs Take()
    {
        var result = new SocketAsyncEventArgs();
        if (BufferPool.DefaultSize > 0)
        {
            var buffer = BufferPool.Take();
            result.SetBuffer(buffer.Array, buffer.Offset, buffer.Count);
        }

        return result;
    }

    public override SocketAsyncEventArgs Create()
    {
        var result = new SocketAsyncEventArgs();
        if (BufferPool.DefaultSize > 0)
        {
            var buffer = BufferPool.Create();
            result.SetBuffer(buffer.Array, buffer.Offset, buffer.Count);
        }
        return result;
    }

    public override void Reset(SocketAsyncEventArgs item)
    {
        if (item == null)
            return;

        item.BufferList?.Clear();
        var socket = item.AcceptSocket;
        if (socket != null)
        {
            item.AcceptSocket = null;

            try
            {
                socket.Dispose();
            }
            catch
            {
            }
        }
    }

    public override void Cleanup(SocketAsyncEventArgs item)
    {
        item.Dispose();
    }
}