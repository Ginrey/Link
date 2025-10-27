using System;
using System.Threading;
using System.Threading.Tasks;
using Link.Security;
using Link.IO;

namespace Link.Net;

public abstract class Connection
{
    private readonly SemaphoreSlim _encodeLock = new(1, 1);
    private readonly SemaphoreSlim _decodeLock = new(1, 1);
    private ConnectionState _state = ConnectionState.NotWorking;

    public event EventHandler? StateChanged;
    public event ReceivedDataHandler? DataReceived;

    public EncodeStack EncodeStack { get; }
    public EncodeStack DecodeStack { get; }

    public EncodeContainer Encoder { get; }
    public EncodeContainer Decoder { get; }

    protected Connection()
    {
        EncodeStack = new EncodeStack();
        DecodeStack = new EncodeStack();

        Encoder = EncodeContainer.Create(EncodeStack);
        Decoder = EncodeContainer.Create(DecodeStack);
    }

    public virtual ConnectionState State
    {
        get => _state;
        protected set
        {
            _state = value;
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public abstract void Start();
    public abstract void Stop();
    public abstract void Close();

    public virtual bool Send(byte[] buffer, int offset, int length)
    {
        _encodeLock.Wait();
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
            _encodeLock.Release();
        }
    }

    public virtual async ValueTask<bool> SendAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken = default)
    {
        await _encodeLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            Encoder.Reset();
            Encoder.Encode(buffer, offset, length);
            return await ProcessSendAsync(
                Encoder.OutputStream.Buffer,
                Encoder.OutputStream.Position,
                Encoder.OutputStream.Count - Encoder.OutputStream.Position,
                cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _encodeLock.Release();
        }
    }

    protected abstract bool ProcessSend(byte[] buffer, int offset, int length);

    protected virtual ValueTask<bool> ProcessSendAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken)
    {
        return new ValueTask<bool>(ProcessSend(buffer, offset, length));
    }

    protected virtual void ProcessReceive(byte[] buffer, int offset, int length)
    {
        _decodeLock.Wait();
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
            _decodeLock.Release();
        }
    }

    protected virtual async ValueTask ProcessReceiveAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken = default)
    {
        await _decodeLock.WaitAsync(cancellationToken).ConfigureAwait(false);
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
            _decodeLock.Release();
        }
    }
}
