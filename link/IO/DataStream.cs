using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Link.IO
{
    public class DataStream : IDisposable
    {
        private IMemoryOwner<byte> _memoryOwner;
        private int _position;
        private int _length;
        private bool _isLittleEndian = true;
        private Stack<bool> _savedEndianness;

        public Memory<byte> Buffer => _memoryOwner.Memory;
        public int Position { get => _position; set { if (value < 0 || value > _length) throw new ArgumentOutOfRangeException(nameof(value)); _position = value; } }
        public int Count => _length;
        public Span<byte> Span => Buffer.Span.Slice(0, _length);
        public ReadOnlySpan<byte> UnreadSpan => Buffer.Span.Slice(_position, _length - _position);
        public bool IsLittleEndian { get => _isLittleEndian; set => _isLittleEndian = value; }
        public EndianBitConverter Converter => _isLittleEndian ? EndianBitConverter.Little : EndianBitConverter.Big;

        public DataStream(int initialCapacity = 256)
        {
            _memoryOwner = MemoryPool<byte>.Shared.Rent(initialCapacity);
        }

        public DataStream(byte[] source) : this(source.Length)
        {
            source.CopyTo(Buffer.Span);
            _length = source.Length;
        }

        private void EnsureCapacity(int newSize)
        {
            if (newSize > Buffer.Length)
            {
                int newCapacity = Math.Max(Buffer.Length * 2, newSize);
                var newOwner = MemoryPool<byte>.Shared.Rent(newCapacity);
                Buffer.Span.Slice(0, _length).CopyTo(newOwner.Memory.Span);
                _memoryOwner.Dispose();
                _memoryOwner = newOwner;
            }
        }

        public void Write(ReadOnlySpan<byte> value)
        {
            EnsureCapacity(_position + value.Length);
            value.CopyTo(Buffer.Span.Slice(_position));
            _position += value.Length;
            if (_position > _length) _length = _position;
        }

        public byte ReadByte() { var val = Buffer.Span[_position]; _position++; return val; }

        public byte[] ReadBytes(int count) => ReadSpan(count).ToArray();

        public ReadOnlySpan<byte> ReadSpan(int count)
        {
            var slice = Buffer.Span.Slice(_position, count);
            _position += count;
            return slice;
        }

        public void Clear() { _position = 0; _length = 0; }

        public void Dispose()
        {
            _memoryOwner?.Dispose();
            _memoryOwner = null;
        }

        // --- Restored Methods ---
        public void PushBack(byte[] bytes, int offset, int len) { Write(new ReadOnlySpan<byte>(bytes, offset, len)); }
        public bool TryRead(byte[] buffer, int offset, int count)
        {
            if (UnreadSpan.Length < count) return false;
            ReadSpan(count).CopyTo(new Span<byte>(buffer, offset, count));
            return true;
        }
        public bool TryReadCompactUInt32(out uint value)
        {
            var initialPos = _position;
            try { value = ReadCompactUInt32(); return true; }
            catch { value = 0; _position = initialPos; return false; }
        }
        public uint ReadCompactUInt32()
        {
            if (_position >= _length) throw new InvalidOperationException("Not enough data.");
            var tempSpan = UnreadSpan;
            var isLe = IsLittleEndian;
            if (isLe) IsLittleEndian = false;
            uint rtnValue;
            switch (tempSpan[0] & 0xE0)
            {
                case 0xE0: ReadByte(); rtnValue = ReadUInt32(); break;
                case 0xC0: rtnValue = ReadUInt32() & 0x3FFFFFFF; break;
                case 0x80: case 0xA0: rtnValue = (uint)(ReadUInt16() & 0x7FFF); break;
                default: rtnValue = ReadByte(); break;
            }
            if (isLe) IsLittleEndian = true;
            return rtnValue;
        }
        public ushort ReadUInt16() => Converter.ToUInt16(ReadSpan(2));
        public uint ReadUInt32() => Converter.ToUInt32(ReadSpan(4));
        public void WriteCompactUInt32(uint value)
        {
            Span<byte> buffer = stackalloc byte[5];
            int bytesWritten = EndianBitConverter.Big.GetCompactUInt32Bytes(value, buffer);
            Write(buffer.Slice(0, bytesWritten));
        }
    }
}
