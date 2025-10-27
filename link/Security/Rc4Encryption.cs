using System;
using Link.IO;

namespace Link.Security;

public sealed class Rc4Encryption : StreamEncoder
{
    private readonly byte[] _table;
    private byte _shift1;
    private byte _shift2;

    public Rc4Encryption(byte[] key)
    {
        ArgumentNullException.ThrowIfNull(key);

        _table = new byte[256];

        for (int i = 0; i < 256; i++)
        {
            _table[i] = (byte)i;
        }

        byte shift = 0;

        for (uint i = 0; i < 256; i++)
        {
            var a = key[i % key.Length];
            shift += (byte)((a + _table[i]) & 255);

            (_table[shift], _table[i]) = (_table[i], _table[shift]);
        }
    }

    public override void Encode(byte[] buffer, int offset, int length, DataStream outputStream)
    {
        ArgumentNullException.ThrowIfNull(buffer);
        ArgumentNullException.ThrowIfNull(outputStream);

        outputStream.Resize(outputStream.Count + length);
        var dstBuffer = outputStream.Buffer.AsSpan();
        var srcBuffer = buffer.AsSpan(offset, length);
        var dstOffset = outputStream.Position;

        for (var i = 0; i < length; i++)
        {
            _shift1++;
            var a = _table[_shift1];

            _shift2 += a;
            var b = _table[_shift2];

            _table[_shift2] = a;
            _table[_shift1] = b;

            var c = (byte)((a + b) & 255);
            var d = _table[c];

            dstBuffer[dstOffset + i] = (byte)(srcBuffer[i] ^ d);
        }
    }
}
