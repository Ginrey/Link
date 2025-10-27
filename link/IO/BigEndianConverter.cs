using System;

namespace Link.IO;

/// <summary>
/// Implementation of EndianBitConverter which converts to/from big-endian byte arrays.
/// </summary>
public sealed class BigEndianBitConverter : EndianBitConverter
{
    /// <summary>
    /// Indicates the byte order ("endianess") in which data is converted using this class.
    /// </summary>
    public override bool IsLittleEndian() => false;

    /// <summary>
    /// Indicates the byte order ("endianess") in which data is converted using this class.
    /// </summary>
    public override Endianness Endianness => Endianness.BigEndian;

    /// <summary>
    /// Copies the specified number of bytes from value to buffer, starting at index.
    /// </summary>
    protected override void CopyBytesImpl(long value, int bytes, byte[] buffer, int index)
    {
        var endOffset = index + bytes - 1;

        for (var i = 0; i < bytes; i++)
        {
            buffer[endOffset - i] = unchecked((byte)(value & 0xff));
            value >>= 8;
        }
    }

    /// <summary>
    /// Copies the specified number of bytes from value to buffer span.
    /// </summary>
    protected override void CopyBytesImpl(long value, int bytes, Span<byte> buffer)
    {
        var endOffset = bytes - 1;

        for (var i = 0; i < bytes; i++)
        {
            buffer[endOffset - i] = unchecked((byte)(value & 0xff));
            value >>= 8;
        }
    }

    /// <summary>
    /// Returns a value built from the specified number of bytes from the given buffer.
    /// </summary>
    protected override long FromBytes(byte[] buffer, int startIndex, int bytesToConvert)
    {
        long ret = 0;

        for (var i = 0; i < bytesToConvert; i++)
        {
            ret = unchecked((ret << 8) | buffer[startIndex + i]);
        }

        return ret;
    }

    /// <summary>
    /// Returns a value built from the specified number of bytes from the given span.
    /// </summary>
    protected override long FromBytes(ReadOnlySpan<byte> buffer, int bytesToConvert)
    {
        long ret = 0;

        for (var i = 0; i < bytesToConvert; i++)
        {
            ret = unchecked((ret << 8) | buffer[i]);
        }

        return ret;
    }
}
