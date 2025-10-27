using System;
using System.Threading;
using System.Threading.Tasks;

namespace Link.Threading;

/// <summary>
/// Модернизированный контейнер для асинхронных результатов с использованием TaskCompletionSource.
/// </summary>
internal class TaskResultAsyncContainer<T> : IAsyncResult
{
    private readonly TaskCompletionSource<T> tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly ManualResetEventSlim resetEvent = new(false);

    public T? Result { get; private set; }
    public Task<T> ResultTask => tcs.Task;

    public TaskResultAsyncContainer()
    {
    }

    /// <summary>
    /// Устанавливает результат и завершает операцию.
    /// </summary>
    public void SetResult(T result)
    {
        Result = result;
        resetEvent.Set();
        tcs.TrySetResult(result);
    }

    /// <summary>
    /// Устанавливает исключение и завершает операцию.
    /// </summary>
    public void SetException(Exception exception)
    {
        resetEvent.Set();
        tcs.TrySetException(exception);
    }

    /// <summary>
    /// Отменяет операцию.
    /// </summary>
    public void SetCanceled()
    {
        resetEvent.Set();
        tcs.TrySetCanceled();
    }

    public object? AsyncState => null;

    public WaitHandle AsyncWaitHandle => resetEvent.WaitHandle;

    public bool CompletedSynchronously => false;

    public bool IsCompleted => resetEvent.IsSet;
}