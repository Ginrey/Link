using System;
using System.Collections.Generic;
using System.Linq;
using Link.IO;

namespace Link.Security;

public sealed class EncodeStack : StreamEncoder
{
    public Stack<EncodeContainer> Stack { get; } = new();

    public void Setup(StreamEncoder encoder)
    {
        Setup(EncodeContainer.Create(encoder));
    }

    public void Setup(EncodeContainer encodeContainer)
    {
        Stack.Push(encodeContainer);
    }

    public EncodeContainer Setdown()
    {
        return Stack.Pop();
    }

    public override void Encode(byte[] buffer, int offset, int length, DataStream output)
    {
        ArgumentNullException.ThrowIfNull(buffer);
        ArgumentNullException.ThrowIfNull(output);

        foreach (var encoder in Stack.Reverse())
        {
            encoder.Reset();
            encoder.Encode(buffer, offset, length);

            buffer = encoder.OutputStream.Buffer;
            offset = encoder.OutputStream.Position;
            length = encoder.OutputStream.Count;
        }
        output.PushBack(buffer, offset, length);
    }
}

