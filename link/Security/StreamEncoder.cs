using System;
using Link.IO;

namespace Link.Security;

public abstract class StreamEncoder
{
    public void Encode(DataStream inputStream, DataStream outputStream)
    {
        ArgumentNullException.ThrowIfNull(inputStream);
        ArgumentNullException.ThrowIfNull(outputStream);

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
        ArgumentNullException.ThrowIfNull(buffer);

        var ds = new DataStream();
        Encode(buffer, ds);
        return ds.GetBytes();
    }

    public void Encode(byte[] buffer, DataStream outputStream)
    {
        ArgumentNullException.ThrowIfNull(buffer);
        Encode(buffer, 0, buffer.Length, outputStream);
    }

    public abstract void Encode(byte[] buffer, int offset, int length, DataStream outputStream);
}
