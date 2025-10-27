using System;
using System.Threading;

namespace Link.Pools;

public sealed class PoolInstance<P, PV> : IPool<PV> where P : IPool<PV>
{
    private P _instance;

    public P Instance
    {
        get => _instance;
        set => _instance = value;
    }

    public PoolInstance(P defaultInstance)
    {
        _instance = defaultInstance;
    }

    public P Get() => _instance;

    public void Set(P pool) => _instance = pool;

    public void SetupNew(P instance)
    {
        var current = Interlocked.Exchange(ref _instance, instance);
        current?.Clear();
    }

    public PV Take() => _instance.Take();

    public bool Return(PV item) => _instance.Return(item);

    public PV Create() => _instance.Create();

    public void Reset(PV item) => _instance.Reset(item);

    public void Cleanup(PV item) => _instance.Cleanup(item);

    public void Allocate() => _instance.Allocate();

    public void Clear() => _instance.Clear();
}

