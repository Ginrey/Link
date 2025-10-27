# Async Event Alternatives in Link Library

## Problem with Traditional C# Events in Async Code

Traditional C# events (`event EventHandler`) have limitations in async scenarios:

1. **Blocking Calls**: Event handlers are synchronous, causing blocking when used with async operations
2. **No Cancellation Support**: Events don't support CancellationToken
3. **No Backpressure**: No way to handle slow consumers
4. **Fire-and-Forget**: No way to await event completion

## Recommended Async Alternatives

### 1. **System.Threading.Channels** (Recommended - IMPLEMENTED)

Channels provide producer-consumer patterns with async support:

```csharp
// Producer side (in Connection class)
private readonly Channel<ConnectionState> _stateChangedChannel = 
    Channel.CreateUnbounded<ConnectionState>();

public ChannelReader<ConnectionState> StateChangedChannel => _stateChangedChannel.Reader;

// When state changes
await _stateChangedChannel.Writer.WriteAsync(newState, cancellationToken);

// Consumer side
await foreach (var state in connection.StateChangedChannel.ReadAllAsync(cancellationToken))
{
    Console.WriteLine($"State changed to: {state}");
}
```

**Advantages:**
- Built-in async/await support
- Backpressure handling (bounded channels)
- Cancellation token support
- Multiple consumers supported
- No blocking operations

**Implementation in Connection class:**
```csharp
// StateChanged event -> StateChangedChannel
public ChannelReader<ConnectionState> StateChangedChannel { get; }

// DataReceived event -> DataReceivedChannel
public ChannelReader<(byte[] buffer, int offset, int length)> DataReceivedChannel { get; }
```

### 2. **IObservable<T> / IAsyncEnumerable<T>**

Reactive Extensions (Rx) pattern for event streams:

```csharp
// Using IAsyncEnumerable
public async IAsyncEnumerable<ConnectionState> StateChanges(
    [EnumeratorCancellation] CancellationToken cancellationToken = default)
{
    while (!cancellationToken.IsCancellationRequested)
    {
        var state = await GetNextStateAsync(cancellationToken);
        yield return state;
    }
}

// Consumer
await foreach (var state in connection.StateChanges(ct))
{
    ProcessState(state);
}
```

**Advantages:**
- Clean LINQ-like operators
- Standard pattern
- Composable

**Disadvantages:**
- Requires System.Linq.Async or System.Reactive
- More complex setup

### 3. **Callback with Func<Task>**

Direct async callbacks:

```csharp
public Func<ConnectionState, CancellationToken, ValueTask>? OnStateChangedAsync { get; set; }

// When state changes
if (OnStateChangedAsync != null)
{
    await OnStateChangedAsync(newState, cancellationToken);
}
```

**Advantages:**
- Simple and direct
- Full async support

**Disadvantages:**
- Only one subscriber
- No multicast support

### 4. **AsyncEventHandler Pattern**

Custom async event pattern:

```csharp
public delegate ValueTask AsyncEventHandler<TEventArgs>(
    object? sender, TEventArgs e, CancellationToken cancellationToken);

public event AsyncEventHandler<ConnectionStateEventArgs>? StateChangedAsync;

// Raising event
var handlers = StateChangedAsync;
if (handlers != null)
{
    await Task.WhenAll(
        handlers.GetInvocationList()
            .Cast<AsyncEventHandler<ConnectionStateEventArgs>>()
            .Select(h => h(this, args, cancellationToken).AsTask()));
}
```

**Advantages:**
- Similar to standard events
- Multiple subscribers

**Disadvantages:**
- Custom implementation needed
- Complexity in error handling

## Migration Guide

### From Events to Channels (Current Implementation)

**Old Code (Events):**
```csharp
connection.StateChanged += (sender, e) => 
{
    Console.WriteLine($"State: {connection.State}");
};

connection.DataReceived += (sender, buffer, offset, length) =>
{
    ProcessData(buffer, offset, length);
};
```

**New Code (Channels - Async):**
```csharp
// Option 1: Background task reading from channel
_ = Task.Run(async () =>
{
    await foreach (var state in connection.StateChangedChannel.ReadAllAsync(ct))
    {
        Console.WriteLine($"State: {state}");
    }
});

_ = Task.Run(async () =>
{
    await foreach (var (buffer, offset, length) in connection.DataReceivedChannel.ReadAllAsync(ct))
    {
        await ProcessDataAsync(buffer, offset, length);
    }
});

// Option 2: Manual reading
while (await connection.StateChangedChannel.WaitToReadAsync(ct))
{
    if (connection.StateChangedChannel.TryRead(out var state))
    {
        Console.WriteLine($"State: {state}");
    }
}
```

**Hybrid Approach (Both Events and Channels - CURRENT):**
```csharp
// Old code still works (backward compatible)
connection.StateChanged += (sender, e) => { /* ... */ };

// New async code can use channels
await foreach (var state in connection.StateChangedChannel.ReadAllAsync(ct))
{
    await ProcessStateAsync(state);
}
```

## Performance Comparison

| Approach | Allocations | Throughput | Async Support | Backpressure |
|----------|-------------|------------|---------------|--------------|
| Events | Low | High | ❌ | ❌ |
| Channels | Medium | High | ✅ | ✅ |
| IAsyncEnumerable | Medium | Medium | ✅ | ⚠️ |
| Func<Task> | Low | High | ✅ | ❌ |
| AsyncEventHandler | High | Medium | ✅ | ❌ |

## Recommendation

For the Link library, **System.Threading.Channels** is the best choice because:

1. ✅ Built into .NET (no extra dependencies)
2. ✅ Excellent async/await support
3. ✅ Backpressure control (bounded channels)
4. ✅ Multiple consumers supported
5. ✅ Can coexist with events for backward compatibility
6. ✅ High performance with low overhead

## Implementation Notes

The current Connection class implementation provides:
- **Backward compatibility**: Traditional events still work
- **Modern async**: Channels for async consumers
- **Dual support**: Both patterns work simultaneously

This allows gradual migration from events to channels without breaking existing code.
