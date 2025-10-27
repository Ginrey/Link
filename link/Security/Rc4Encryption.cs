using System;
using System.Runtime.CompilerServices;
using Link.IO;

namespace Link.Security
{
    public class Rc4Encryption : StreamEncoder
    {
        private readonly byte[] table;
        private byte shift1;
        private byte shift2;

        public Rc4Encryption(byte[] key)
        {
            table = new byte[256];

            for (int i = 0; i < 256; i++)
            {
                table[i] = (byte)i;
            }

            byte shift = 0;

            for (uint i = 0; i < 256; i++)
            {
                var a = key[i % key.Length];
                shift += (byte)((a + table[i]) & 255);

                var b = table[i];
                table[i] = table[shift];
                table[shift] = b;
            }
        }

        public override void Encode(byte[] buffer, int offset, int length, DataStream outputStream)
        {
            outputStream.Resize(outputStream.Count + length);
            var dstBuffer = outputStream.Buffer;
            var dstOffset = outputStream.Position;
            
            // Используем Span для оптимизации
            Span<byte> src = buffer.AsSpan(offset, length);
            Span<byte> dst = dstBuffer.AsSpan(dstOffset, length);
            
            EncodeInternal(src, dst);
        }

        /// <summary>
        /// Оптимизированная версия кодирования с использованием Span.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EncodeInternal(ReadOnlySpan<byte> src, Span<byte> dst)
        {
            for (var i = 0; i < src.Length; i++)
            {
                shift1++;
                var a = table[shift1];

                shift2 += a;
                var b = table[shift2];

                table[shift2] = a;
                table[shift1] = b;

                var c = (byte)((a + b) & 255);
                var d = table[c];

                dst[i] = (byte)(src[i] ^ d);
            }
        }

        /// <summary>
        /// Кодирование/декодирование данных с использованием Span (новый метод).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Transform(ReadOnlySpan<byte> source, Span<byte> destination)
        {
            if (destination.Length < source.Length)
                throw new ArgumentException("Destination buffer is too small");

            EncodeInternal(source, destination);
        }
    }
}
