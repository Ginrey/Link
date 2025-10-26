using System;

namespace Link.IO
{
    public abstract class EndianBitConverter
    {
        public abstract bool IsLittleEndian();
        public abstract Endianness Endianness { get; }

        public static LittleEndianBitConverter Little { get; } = new LittleEndianBitConverter();
        public static BigEndianBitConverter Big { get; } = new BigEndianBitConverter();

        public long DoubleToInt64Bits(double value) => BitConverter.DoubleToInt64Bits(value);
        public double Int64BitsToDouble(long value) => BitConverter.Int64BitsToDouble(value);
        public int SingleToInt32Bits(float value) => BitConverter.SingleToInt32Bits(value);
        public float Int32BitsToSingle(int value) => BitConverter.Int32BitsToSingle(value);

        public bool ToBoolean(ReadOnlySpan<byte> value) => value[0] != 0;
        public char ToChar(ReadOnlySpan<byte> value) => (char)FromBytes(value, 2);
        public double ToDouble(ReadOnlySpan<byte> value) => Int64BitsToDouble(ToInt64(value));
        public float ToSingle(ReadOnlySpan<byte> value) => Int32BitsToSingle(ToInt32(value));
        public short ToInt16(ReadOnlySpan<byte> value) => (short)FromBytes(value, 2);
        public int ToInt32(ReadOnlySpan<byte> value) => (int)FromBytes(value, 4);
        public long ToInt64(ReadOnlySpan<byte> value) => FromBytes(value, 8);
        public ushort ToUInt16(ReadOnlySpan<byte> value) => (ushort)FromBytes(value, 2);
        public uint ToUInt32(ReadOnlySpan<byte> value) => (uint)FromBytes(value, 4);
        public ulong ToUInt64(ReadOnlySpan<byte> value) => (ulong)FromBytes(value, 8);

        protected abstract long FromBytes(ReadOnlySpan<byte> value, int bytesToConvert);
        protected abstract void CopyBytesImpl(long value, int bytes, Span<byte> buffer);

        public void CopyBytes(char value, Span<byte> buffer) => CopyBytesImpl(value, 2, buffer);
        public void CopyBytes(double value, Span<byte> buffer) => CopyBytesImpl(DoubleToInt64Bits(value), 8, buffer);
        public void CopyBytes(short value, Span<byte> buffer) => CopyBytesImpl(value, 2, buffer);
        public void CopyBytes(int value, Span<byte> buffer) => CopyBytesImpl(value, 4, buffer);
        public void CopyBytes(long value, Span<byte> buffer) => CopyBytesImpl(value, 8, buffer);
        public void CopyBytes(float value, Span<byte> buffer) => CopyBytesImpl(SingleToInt32Bits(value), 4, buffer);
        public void CopyBytes(ushort value, Span<byte> buffer) => CopyBytesImpl(value, 2, buffer);
        public void CopyBytes(uint value, Span<byte> buffer) => CopyBytesImpl(value, 4, buffer);
        public void CopyBytes(ulong value, Span<byte> buffer) => CopyBytesImpl(unchecked((long)value), 8, buffer);

        public int GetCompactUInt32Bytes(uint value, Span<byte> buffer)
        {
            if (value < 0x80)
            {
                buffer[0] = (byte)value;
                return 1;
            }
            if (value < 0x4000)
            {
                Big.CopyBytes((ushort)(value | 0x8000), buffer);
                return 2;
            }
            if (value < 0x20000000)
            {
                Big.CopyBytes((int)(value | 0xC0000000), buffer);
                return 4;
            }

            buffer[0] = 0xE0;
            Big.CopyBytes(value, buffer.Slice(1));
            return 5;
        }
    }
}
