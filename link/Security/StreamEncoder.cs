using System;
using System.Runtime.CompilerServices;
using Link.IO;

namespace Link.Security;

public abstract class StreamEncoder
{
    public void Encode(DataStream inputStream, DataStream outputStream)
    {
        if (inputStream.CanReadBytes())
        {
            var offset = inputStream.Position;
            var length = inputStream.Count - offset;
            Encode(inputStream.Buffer, offset, length, outputStream);
            inputStream.Position = length;
        }
    }

    public byte[] Encode(byte[] buffer)
    {
        var ds = new DataStream();
        Encode(buffer, ds);
        return ds.GetBytes();
    }

    public void Encode(byte[] buffer, DataStream outputStream)
    {
        Encode(buffer, 0, buffer.Length, outputStream);
    }

    /// <summary>
    /// Кодирование с использованием Span (новый метод).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public virtual void Encode(ReadOnlySpan<byte> data, DataStream outputStream)
    {
        // Базовая реализация через массив для обратной совместимости
        Encode(data.ToArray(), 0, data.Length, outputStream);
    }

    public abstract void Encode(byte[] buffer, int offset, int length, DataStream outputStream);
}