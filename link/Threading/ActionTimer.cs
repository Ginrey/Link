using System;
using System.Threading;

namespace Link.Threading;

public sealed class ActionTimer : IDisposable
{
    private readonly Timer _timer;
    private bool _disposed;

    public ActionTimer(TimerCallback callBack) : this(callBack, null)
    {
    }

    public ActionTimer(TimerCallback callBack, object? state)
    {
        _timer = new Timer(callBack, state, Timeout.Infinite, Timeout.Infinite);
    }

    public void Start(int dueTime, int period)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        _timer.Change(dueTime, period);
    }

    public void Stop()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        _timer.Change(Timeout.Infinite, Timeout.Infinite);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            _timer.Dispose();
        }
    }
}
