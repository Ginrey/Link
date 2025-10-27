using System;
using System.Threading;

namespace Link.Pools;

public sealed class BufferPool : StackPool<ArraySegment<byte>>
{
    private const int HeaderSize = 8;
    private static int s_idCounter = 1;
    private readonly int _id;

    public int DefaultSize { get; }
    public bool FixedSize { get; }

    public BufferPool(int defaultSize, bool fixedSize = false, int maxFreeCount = 1024, int allocateDefaultCount = 16)
        : base(maxFreeCount, allocateDefaultCount)
    {
        DefaultSize = defaultSize;
        FixedSize = fixedSize;
        _id = Interlocked.Increment(ref s_idCounter);
    }

    public override ArraySegment<byte> Create()
    {
        if (DefaultSize <= 0)
        {
            return ArraySegment<byte>.Empty;
        }
        return new ArraySegment<byte>(new byte[DefaultSize]);
    }

    private unsafe bool Validate(byte[] buffer)
    {
        if (buffer.Length <= HeaderSize)
            return false;

        fixed (byte* bytePtr = buffer)
        {
            int* ptr = (int*)bytePtr;
            int id = ptr[1];

            if (id != _id)
            {
                int count = ptr[0];
                if (count == 0)
                {
                    ptr[1] = id = _id;
                }
            }
            return id == _id;
        }
    }

    private unsafe int Change(byte[] buffer, int value)
    {
        fixed (byte* bytePtr = buffer)
        {
            int* ptr = (int*)bytePtr;
            ptr[0] += value;
            return ptr[0];
        }
    }

    public override ArraySegment<byte> Take()
    {
        var result = base.Take();
        if (result.Array != null)
        {
            Change(result.Array, -1);
        }
        return result;
    }

    public bool Return(ArraySegment<byte> element) =>
        Return(element.Array!, element.Offset, element.Count);

    public bool Return(byte[] buffer, int offset, int count)
    {
        if (DefaultSize <= 0)
            return false;

        if (buffer.Length <= HeaderSize)
            return false;

        if (offset < HeaderSize)
        {
            count = count - HeaderSize + offset;
            offset = HeaderSize;
        }

        if (count < DefaultSize)
            return false;

        if (!Validate(buffer))
            return false;

        bool ok = false;

        var needReturn = Count < MaxFreeCount;
        if (!needReturn)
        {
            int cnt = Change(buffer, 0);
            if (cnt > 0)
            {
                needReturn = true;
            }
        }

        if (needReturn)
        {
            int resCount = 0;
            for (var i = 0; i < count; i += DefaultSize)
            {
                var curOffset = offset + i;
                var curCount = DefaultSize;
                if (!FixedSize && i + (DefaultSize << 1) > count)
                {
                    curCount = count - i;
                }
                if (curCount > count - i)
                {
                    break;
                }
                if (base.Return(new ArraySegment<byte>(buffer, curOffset, curCount), true))
                {
                    resCount++;
                    ok = true;
                }
            }
            Change(buffer, resCount);
        }

        return ok;
    }

    public override void Allocate(int count)
    {
        var buffer = new byte[HeaderSize + count * DefaultSize];
        Return(buffer, 0, buffer.Length);
    }
}

