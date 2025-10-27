using System;
using Link.IO;

namespace Link.Pools;

using DataStreamPoolInstance = PoolInstance<DataStreamPool, DataStream>;

public sealed class DataStreamPool : StackPool<DataStream>
{
    public static readonly DataStreamPoolInstance Instance = new(new DataStreamPool());

    public DataStreamPool(int maxFreeCount = 1024, int allocateDefaultCount = 16)
        : base(maxFreeCount, allocateDefaultCount)
    {
    }

    public override void Reset(DataStream item)
    {
        item.Clear();
        item.IsLittleEndian = true;
    }

    public override DataStream Create() => new();
}

