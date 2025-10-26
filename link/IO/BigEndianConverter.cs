using System;

namespace Link.IO
{
    public sealed class BigEndianBitConverter : EndianBitConverter
    {
        public override bool IsLittleEndian() => false;
        public override Endianness Endianness => Endianness.BigEndian;

        protected override void CopyBytesImpl(long value, int bytes, Span<byte> buffer)
        {
            int endOffset = bytes - 1;
            for (int i = 0; i < bytes; i++)
            {
                buffer[endOffset - i] = unchecked((byte)(value & 0xff));
                value >>= 8;
            }
        }

        protected override long FromBytes(ReadOnlySpan<byte> buffer, int bytesToConvert)
        {
            long ret = 0;
            for (int i = 0; i < bytesToConvert; i++)
            {
                ret = unchecked((ret << 8) | buffer[i]);
            }
            return ret;
        }
    }
}
