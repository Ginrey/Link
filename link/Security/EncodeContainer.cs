using System;
using Link.IO;

namespace Link.Security;

public readonly struct EncodeContainer
{
    public DataStream OutputStream { get; }
    public StreamEncoder Encoder { get; }

    public EncodeContainer(StreamEncoder encoder, DataStream outputStream)
    {
        Encoder = encoder ?? throw new ArgumentNullException(nameof(encoder));
        OutputStream = outputStream ?? throw new ArgumentNullException(nameof(outputStream));
    }

    public void Encode(DataStream inputStream)
    {
        Encoder.Encode(inputStream, OutputStream);
    }

    public void Encode(byte[] buffer)
    {
        Encoder.Encode(buffer, OutputStream);
    }

    public void Encode(byte[] buffer, int offset, int length)
    {
        Encoder.Encode(buffer, offset, length, OutputStream);
    }

    public void Reset()
    {
        OutputStream.Clear();
    }

    public static EncodeContainer Create(StreamEncoder encoder)
    {
        return new EncodeContainer(encoder, new DataStream());
    }
}

