using System;

namespace Link.IO;

/// <summary>
/// Implementation of EndianBitConverter which converts to/from little-endian byte arrays.
/// </summary>
public sealed class LittleEndianBitConverter : EndianBitConverter
{
    /// <summary>
    /// Indicates the byte order ("endianess") in which data is converted using this class.
    /// </summary>
    public sealed override bool IsLittleEndian() => true;

    /// <summary>
    /// Indicates the byte order ("endianess") in which data is converted using this class.
    /// </summary>
    public sealed override Endianness Endianness => Endianness.LittleEndian;

    /// <summary>
    /// Copies the specified number of bytes from value to buffer, starting at index.
    /// </summary>
    protected override void CopyBytesImpl(long value, int bytes, byte[] buffer, int index)
    {
        for (int i = 0; i < bytes; i++)
        {
            buffer[i + index] = unchecked((byte)(value & 0xff));
            value >>= 8;
        }
    }

    /// <summary>
    /// Copies the specified number of bytes from value to buffer span.
    /// </summary>
    protected override void CopyBytesImpl(long value, int bytes, Span<byte> buffer)
    {
        for (int i = 0; i < bytes; i++)
        {
            buffer[i] = unchecked((byte)(value & 0xff));
            value >>= 8;
        }
    }

    /// <summary>
    /// Returns a value built from the specified number of bytes from the given buffer.
    /// </summary>
    protected override long FromBytes(byte[] buffer, int startIndex, int bytesToConvert)
    {
        var endOffset = startIndex + bytesToConvert - 1;
        long ret = 0;
        for (int i = 0; i < bytesToConvert; i++)
            ret = unchecked((ret << 8) | buffer[endOffset - i]);
        return ret;
    }

    /// <summary>
    /// Returns a value built from the specified number of bytes from the given span.
    /// </summary>
    protected override long FromBytes(ReadOnlySpan<byte> buffer, int bytesToConvert)
    {
        var endOffset = bytesToConvert - 1;
        long ret = 0;
        for (int i = 0; i < bytesToConvert; i++)
            ret = unchecked((ret << 8) | buffer[endOffset - i]);
        return ret;
    }
}
