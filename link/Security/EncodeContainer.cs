using System;
using System.Runtime.CompilerServices;
using Link.IO;

namespace Link.Security
{
    public struct EncodeContainer
    {
        public DataStream OutputStream { get; private set; }
        public StreamEncoder Encoder { get; private set; }

        public EncodeContainer(StreamEncoder encoder, DataStream outputStream)
        {
            Encoder = encoder;
            OutputStream = outputStream;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Encode(DataStream inputStream)
        {
            Encoder.Encode(inputStream, OutputStream);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Encode(byte[] buffer)
        {
            Encoder.Encode(buffer, OutputStream);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Encode(byte[] buffer, int offset, int length)
        {
            Encoder.Encode(buffer, offset, length, OutputStream);
        }

        /// <summary>
        /// Кодирование с использованием Span (новый метод).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Encode(ReadOnlySpan<byte> data)
        {
            Encoder.Encode(data, OutputStream);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset()
        {
            OutputStream.Clear();
        }

        public static EncodeContainer Create(StreamEncoder encoder)
        {
            return new EncodeContainer(encoder, new DataStream());
        }
    }
}

