using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Link.Threading
{
    public class ActionTimer : IDisposable
    {
        private Timer? timer;
        private bool disposed;

        public ActionTimer(TimerCallback callBack) : this(callBack, null)
        {
        }

        public ActionTimer(TimerCallback callBack, object? state)
        {
            timer = new Timer(callBack, state, Timeout.Infinite, Timeout.Infinite);
        }

        public void Start(int dueTime, int period)
        {
            ObjectDisposedException.ThrowIf(disposed, this);
            timer?.Change(dueTime, period);
        }

        public void Stop()
        {
            timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                timer?.Dispose();
                timer = null;
                disposed = true;
            }
        }
    }
}
