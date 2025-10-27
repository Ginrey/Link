using System;
using Link.IO;

namespace Link.Security;

public sealed class MppcPacker : StreamEncoder
{
    private static readonly byte[] s_reversedBits;
    private int _historyLength;

    static MppcPacker()
    {
        s_reversedBits = new byte[256];
        for (var i = 0; i < 256; i++)
        {
            byte x = (byte)i;
            byte y = 0;
            for (var j = 0; j < 8; j++)
            {
                y <<= 1;
                y |= (byte)(x & 1);
                x >>= 1;
            }
            s_reversedBits[i] = y;
        }
    }

    public static void PackBlock(ReadOnlySpan<byte> src, DataStream ds)
    {
        int histLength = 0;
        PackBlock(src, ds, ref histLength);
    }

    public static void PackBlock(ReadOnlySpan<byte> src, DataStream ds, ref int histLength)
    {
        ArgumentNullException.ThrowIfNull(ds);

        ulong x = 0;
        int pos = 0;

        for (var i = 0; i < src.Length; ++i)
        {
            if (histLength >= 8192)
            {
                histLength = 0;
                x = x | (15U << pos);
                pos += 10;
                pos += -(pos & 7) & 7;
            }
            ulong v = s_reversedBits[src[i]];
            if ((v & 1) > 0)
            {
                v ^= 1;
                x |= (1U << pos);
                ++pos;
            }
            x |= (v << pos);
            pos += 8;
            ++histLength;
            while (pos >= 8)
            {
                ds.PushBack(s_reversedBits[(int)(x & 255)]);
                x >>= 8;
                pos -= 8;
            }
        }
        x = x | (15U << pos);
        pos += 10;
        pos += -(pos & 7) & 7;
        while (pos >= 8)
        {
            ds.PushBack(s_reversedBits[(x & 255)]);
            x >>= 8;
            pos -= 8;
        }
    }

    public override void Encode(byte[] src, int offset, int length, DataStream ds)
    {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(ds);

        PackBlock(src.AsSpan(offset, length), ds, ref _historyLength);
    }

    public void Reset()
    {
        _historyLength = 0;
    }
}