using System;
using System.Collections.Concurrent;

namespace Link.Pools;

public abstract class StackPool<T> : IPool<T>
{
    private readonly ConcurrentStack<T> _freeItems = new();

    public int AllocateDefaultCount { get; set; }
    public int MaxFreeCount { get; set; }

    public int Count => _freeItems.Count;

    protected StackPool(int maxFreeCount = 1024, int allocateDefaultCount = 16)
    {
        MaxFreeCount = maxFreeCount;
        AllocateDefaultCount = allocateDefaultCount;
    }

    public virtual T Take()
    {
        if (!_freeItems.TryPop(out var item))
        {
            if (MaxFreeCount == 0 || AllocateDefaultCount == 0)
            {
                return Create();
            }
            Allocate();
            _freeItems.TryPop(out item);
        }
        return item!;
    }

    public bool Return(T item) => Return(item, false);

    public virtual bool Return(T item, bool force)
    {
        Reset(item);

        if (_freeItems.Count < MaxFreeCount || force)
        {
            _freeItems.Push(item);
            return true;
        }

        Cleanup(item);
        return false;
    }

    public abstract T Create();

    public virtual void Clear()
    {
        while (_freeItems.TryPop(out var item))
        {
            Cleanup(item);
        }
    }

    public virtual void Reset(T item)
    {
    }

    public virtual void Cleanup(T item)
    {
    }

    public void Allocate()
    {
        Allocate(AllocateDefaultCount <= 0 ? 1 : AllocateDefaultCount);
    }

    public virtual void Allocate(int count)
    {
        while (count-- > 0)
        {
            Return(Create());
        }
    }
}

