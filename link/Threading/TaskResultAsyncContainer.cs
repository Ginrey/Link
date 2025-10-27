using System;
using System.Threading;
using System.Threading.Tasks;

namespace Link.Threading;

internal sealed class TaskResultAsyncContainer<T> : IDisposable
{
    private readonly TaskCompletionSource<T> _tcs = new();
    private bool _disposed;

    public Task<T> ResultTask => _tcs.Task;

    public void SetResult(T result)
    {
        _tcs.TrySetResult(result);
    }

    public void SetException(Exception ex)
    {
        _tcs.TrySetException(ex);
    }

    public void SetCanceled()
    {
        _tcs.TrySetCanceled();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
        }
    }
}
