using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Link.Security;

namespace Link.Net;

public abstract class Connection
{
    public event EventHandler? StateChanged;
    public event ReceivedDataHandler? DataReceived;

    // Modern async alternatives to events using Channels
    private readonly Channel<ConnectionState> _stateChangedChannel = Channel.CreateUnbounded<ConnectionState>(new UnboundedChannelOptions 
    { 
        SingleReader = false, 
        SingleWriter = false 
    });
    
    private readonly Channel<(byte[] buffer, int offset, int length)> _dataReceivedChannel = Channel.CreateUnbounded<(byte[], int, int)>(new UnboundedChannelOptions 
    { 
        SingleReader = false, 
        SingleWriter = false 
    });

    /// <summary>
    /// Асинхронная альтернатива событию StateChanged.
    /// Подписчики могут читать из этого канала для получения уведомлений о смене состояния.
    /// </summary>
    public ChannelReader<ConnectionState> StateChangedChannel => _stateChangedChannel.Reader;

    /// <summary>
    /// Асинхронная альтернатива событию DataReceived.
    /// Подписчики могут читать из этого канала для получения данных.
    /// </summary>
    public ChannelReader<(byte[] buffer, int offset, int length)> DataReceivedChannel => _dataReceivedChannel.Reader;

    public EncodeStack EncodeStack { get; private set; }
    public EncodeStack DecodeStack { get; private set; }

    public EncodeContainer Encoder { get; private set; }
    public EncodeContainer Decoder { get; private set; }

    private readonly SemaphoreSlim _encodeSemaphore = new(1, 1);
    private readonly SemaphoreSlim _decodeSemaphore = new(1, 1);

    public Connection()
    {
        EncodeStack = new EncodeStack();
        DecodeStack = new EncodeStack();

        Encoder = EncodeContainer.Create(EncodeStack);
        Decoder = EncodeContainer.Create(DecodeStack);
    }

    private ConnectionState state = ConnectionState.NotWorking;
    public virtual ConnectionState State
    {
        get => state;
        protected set
        {
            state = value;
            // Поддерживаем оба подхода: events и channels
            StateChanged?.Invoke(this, EventArgs.Empty);
            _ = _stateChangedChannel.Writer.TryWrite(value);
        }
    }

    public abstract void Start();
    public abstract void Stop();
    public abstract void Close();

    public virtual bool Send(byte[] buffer, int offset, int length)
    {
        _encodeSemaphore.Wait();
        try
        {
            Encoder.Reset();
            Encoder.Encode(buffer, offset, length);
            var memory = Encoder.OutputStream.AsMemory();
            return ProcessSendAsync(memory).GetAwaiter().GetResult();
        }
        finally
        {
            _encodeSemaphore.Release();
        }
    }

    /// <summary>
    /// Синхронная отправка данных с использованием Span.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public virtual bool Send(ReadOnlySpan<byte> data)
    {
        _encodeSemaphore.Wait();
        try
        {
            Encoder.Reset();
            Encoder.OutputStream.Clear();
            Encoder.OutputStream.PushBack(data);
            var memory = Encoder.OutputStream.AsMemory();
            return ProcessSendAsync(memory).GetAwaiter().GetResult();
        }
        finally
        {
            _encodeSemaphore.Release();
        }
    }

    /// <summary>
    /// Асинхронная отправка данных.
    /// </summary>
    public virtual async ValueTask<bool> SendAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken = default)
    {
        await _encodeSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            Encoder.Reset();
            Encoder.Encode(buffer, offset, length);
            var memory = Encoder.OutputStream.AsMemory();
            return await ProcessSendAsync(memory, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _encodeSemaphore.Release();
        }
    }

    /// <summary>
    /// Асинхронная отправка данных с использованием ReadOnlyMemory.
    /// </summary>
    public virtual async ValueTask<bool> SendAsync(ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default)
    {
        await _encodeSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            Encoder.Reset();
            Encoder.OutputStream.Clear();
            Encoder.OutputStream.PushBack(data.Span);
            var memory = Encoder.OutputStream.AsMemory();
            return await ProcessSendAsync(memory, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _encodeSemaphore.Release();
        }
    }

    /// <summary>
    /// Асинхронный метод отправки данных через ReadOnlyMemory (для переопределения в наследниках).
    /// Заменяет старый синхронный ProcessSend(byte[], int, int).
    /// Использует ReadOnlyMemory вместо Span для поддержки async.
    /// </summary>
    protected abstract ValueTask<bool> ProcessSendAsync(ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Устаревший синхронный метод для обратной совместимости.
    /// Новый код должен использовать ProcessSendAsync.
    /// </summary>
    [Obsolete("Use ProcessSendAsync instead for better async performance")]
    protected virtual bool ProcessSend(byte[] buffer, int offset, int length)
    {
        return ProcessSendAsync(new ReadOnlyMemory<byte>(buffer, offset, length)).GetAwaiter().GetResult();
    }
        
    protected virtual void ProcessReceive(byte[] buffer, int offset, int length)
    {
        _decodeSemaphore.Wait();
        try
        {
            Decoder.Reset();
            Decoder.Encode(buffer, offset, length);
            var resultBuffer = Decoder.OutputStream.Buffer;
            var resultOffset = Decoder.OutputStream.Position;
            var resultLength = Decoder.OutputStream.Count - Decoder.OutputStream.Position;
            
            // Поддерживаем оба подхода: события и каналы
            DataReceived?.Invoke(this, resultBuffer, resultOffset, resultLength);
            _ = _dataReceivedChannel.Writer.TryWrite((resultBuffer, resultOffset, resultLength));
        }
        finally
        {
            _decodeSemaphore.Release();
        }
    }

    /// <summary>
    /// Оптимизированная обработка получения данных с использованием Span.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected virtual void ProcessReceive(ReadOnlySpan<byte> data)
    {
        _decodeSemaphore.Wait();
        try
        {
            Decoder.Reset();
            Decoder.OutputStream.Clear();
            Decoder.OutputStream.PushBack(data);
            var resultBuffer = Decoder.OutputStream.Buffer;
            var resultOffset = Decoder.OutputStream.Position;
            var resultLength = Decoder.OutputStream.Count - Decoder.OutputStream.Position;
            
            // Поддерживаем оба подхода: события и каналы
            DataReceived?.Invoke(this, resultBuffer, resultOffset, resultLength);
            _ = _dataReceivedChannel.Writer.TryWrite((resultBuffer, resultOffset, resultLength));
        }
        finally
        {
            _decodeSemaphore.Release();
        }
    }

    /// <summary>
    /// Асинхронная обработка получения данных.
    /// Используйте DataReceivedChannel для чтения данных в асинхронном коде.
    /// </summary>
    protected virtual async ValueTask ProcessReceiveAsync(ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default)
    {
        await _decodeSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            Decoder.Reset();
            Decoder.OutputStream.Clear();
            Decoder.OutputStream.PushBack(data.Span);
            var resultBuffer = Decoder.OutputStream.Buffer;
            var resultOffset = Decoder.OutputStream.Position;
            var resultLength = Decoder.OutputStream.Count - Decoder.OutputStream.Position;
            
            // Поддерживаем оба подхода: события и каналы
            DataReceived?.Invoke(this, resultBuffer, resultOffset, resultLength);
            await _dataReceivedChannel.Writer.WriteAsync((resultBuffer, resultOffset, resultLength), cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _decodeSemaphore.Release();
        }
    }
}