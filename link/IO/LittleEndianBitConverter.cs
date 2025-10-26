using System;

namespace Link.IO
{
    public sealed class LittleEndianBitConverter : EndianBitConverter
    {
        public override bool IsLittleEndian() => true;
        public override Endianness Endianness => Endianness.LittleEndian;

        protected override void CopyBytesImpl(long value, int bytes, Span<byte> buffer)
        {
            for (int i = 0; i < bytes; i++)
            {
                buffer[i] = unchecked((byte)(value & 0xff));
                value >>= 8;
            }
        }

        protected override long FromBytes(ReadOnlySpan<byte> buffer, int bytesToConvert)
        {
            long ret = 0;
            for (int i = 0; i < bytesToConvert; i++)
            {
                ret = unchecked((ret << 8) | buffer[bytesToConvert - 1 - i]);
            }
            return ret;
        }
    }
}
