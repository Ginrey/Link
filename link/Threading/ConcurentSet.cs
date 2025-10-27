using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Link.Threading;

public sealed class ConcurentSet<T> : ISet<T>, IEnumerable<T> where T : notnull
{
    private readonly ConcurrentDictionary<T, byte> _dictionary = new();

    public int Count => _dictionary.Count;

    public bool IsReadOnly => false;

    public IEnumerable<T> Items => _dictionary.Keys;

    public T[] ToArray() => [.. _dictionary.Keys];

    public bool Add(T item) => _dictionary.TryAdd(item, 0);

    public void Clear() => _dictionary.Clear();

    public bool Contains(T item) => _dictionary.ContainsKey(item);

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));

        var items = ToArray();
        if (array.Length - arrayIndex < items.Length)
            throw new ArgumentException("Array is too small");

        Array.Copy(items, 0, array, arrayIndex, items.Length);
    }

    public void ExceptWith(IEnumerable<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        foreach (var item in other)
        {
            _dictionary.TryRemove(item, out _);
        }
    }

    public IEnumerator<T> GetEnumerator() => _dictionary.Keys.GetEnumerator();

    public void IntersectWith(IEnumerable<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        var otherSet = new HashSet<T>(other);
        var toRemove = _dictionary.Keys.Where(k => !otherSet.Contains(k)).ToList();
        foreach (var item in toRemove)
        {
            _dictionary.TryRemove(item, out _);
        }
    }

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        var otherSet = new HashSet<T>(other);
        return _dictionary.Keys.All(k => otherSet.Contains(k)) && otherSet.Count > _dictionary.Count;
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        var otherSet = new HashSet<T>(other);
        return otherSet.All(item => _dictionary.ContainsKey(item)) && _dictionary.Count > otherSet.Count;
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        var otherSet = new HashSet<T>(other);
        return _dictionary.Keys.All(k => otherSet.Contains(k));
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        return other.All(item => _dictionary.ContainsKey(item));
    }

    public bool Overlaps(IEnumerable<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        return other.Any(item => _dictionary.ContainsKey(item));
    }

    public bool Remove(T item) => _dictionary.TryRemove(item, out _);

    public bool SetEquals(IEnumerable<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        var otherSet = new HashSet<T>(other);
        return _dictionary.Count == otherSet.Count && _dictionary.Keys.All(k => otherSet.Contains(k));
    }

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        foreach (var item in other)
        {
            if (_dictionary.ContainsKey(item))
            {
                _dictionary.TryRemove(item, out _);
            }
            else
            {
                _dictionary.TryAdd(item, 0);
            }
        }
    }

    public void UnionWith(IEnumerable<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        foreach (var item in other)
        {
            _dictionary.TryAdd(item, 0);
        }
    }

    void ICollection<T>.Add(T item)
    {
        Add(item);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
