using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Link.Security;

namespace Link.Net;

public abstract class Connection
{
    public event EventHandler? StateChanged;
    public event ReceivedDataHandler? DataReceived;

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
            StateChanged?.Invoke(this, EventArgs.Empty);
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
            return ProcessSend(
                Encoder.OutputStream.Buffer, 
                Encoder.OutputStream.Position, 
                Encoder.OutputStream.Count - Encoder.OutputStream.Position);
        }
        finally
        {
            _encodeSemaphore.Release();
        }
    }

    /// <summary>
    /// Асинхронная отправка данных с использованием Span.
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
            return ProcessSend(
                Encoder.OutputStream.Buffer, 
                Encoder.OutputStream.Position, 
                Encoder.OutputStream.Count - Encoder.OutputStream.Position);
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
            return ProcessSend(
                Encoder.OutputStream.Buffer, 
                Encoder.OutputStream.Position, 
                Encoder.OutputStream.Count - Encoder.OutputStream.Position);
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
            return ProcessSend(
                Encoder.OutputStream.Buffer, 
                Encoder.OutputStream.Position, 
                Encoder.OutputStream.Count - Encoder.OutputStream.Position);
        }
        finally
        {
            _encodeSemaphore.Release();
        }
    }

    protected abstract bool ProcessSend(byte[] buffer, int offset, int length);
        
    protected virtual void ProcessReceive(byte[] buffer, int offset, int length)
    {
        _decodeSemaphore.Wait();
        try
        {
            Decoder.Reset();
            Decoder.Encode(buffer, offset, length);
            DataReceived?.Invoke(this, 
                Decoder.OutputStream.Buffer, 
                Decoder.OutputStream.Position, 
                Decoder.OutputStream.Count - Decoder.OutputStream.Position);
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
            DataReceived?.Invoke(this, 
                Decoder.OutputStream.Buffer, 
                Decoder.OutputStream.Position, 
                Decoder.OutputStream.Count - Decoder.OutputStream.Position);
        }
        finally
        {
            _decodeSemaphore.Release();
        }
    }
}