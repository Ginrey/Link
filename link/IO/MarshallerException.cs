using System;

namespace Link.IO;

public sealed class MarshallerException : Exception
{
    public DataStream? DataStream { get; }

    public MarshallerException()
    {
    }

    public MarshallerException(string message) : base(message)
    {
    }

    public MarshallerException(DataStream ds)
    {
        DataStream = ds;
    }

    public MarshallerException(DataStream ds, string message)
        : base(message)
    {
        DataStream = ds;
    }
}
