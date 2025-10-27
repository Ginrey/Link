using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Link.Security;
using Link.IO;

namespace Link.Net
{
    public abstract class Connection
    {
        public event EventHandler? StateChanged;
        public event ReceivedDataHandler? DataReceived;

        public EncodeStack EncodeStack { get; private set; }
        public EncodeStack DecodeStack { get; private set; }

        public EncodeContainer Encoder { get; private set; }
        public EncodeContainer Decoder { get; private set; }

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
            get
            {
                return state;
            }
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
            lock (EncodeStack)
            {
                Encoder.Reset();
                Encoder.Encode(buffer, offset, length);
                return ProcessSend(
                    Encoder.OutputStream.Buffer, 
                    Encoder.OutputStream.Position, 
                    Encoder.OutputStream.Count - Encoder.OutputStream.Position);
            }
        }

        /// <summary>
        /// Асинхронная отправка данных с использованием Span.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual bool Send(ReadOnlySpan<byte> data)
        {
            lock (EncodeStack)
            {
                Encoder.Reset();
                Encoder.OutputStream.Clear();
                Encoder.OutputStream.PushBack(data);
                return ProcessSend(
                    Encoder.OutputStream.Buffer, 
                    Encoder.OutputStream.Position, 
                    Encoder.OutputStream.Count - Encoder.OutputStream.Position);
            }
        }

        /// <summary>
        /// Асинхронная отправка данных.
        /// </summary>
        public virtual ValueTask<bool> SendAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken = default)
        {
            // Базовая реализация - синхронная обертка
            // Наследники должны переопределить для истинно асинхронного поведения
            return new ValueTask<bool>(Send(buffer, offset, length));
        }

        /// <summary>
        /// Асинхронная отправка данных с использованием ReadOnlyMemory.
        /// </summary>
        public virtual ValueTask<bool> SendAsync(ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default)
        {
            // Базовая реализация - синхронная обертка
            return new ValueTask<bool>(Send(data.Span));
        }

        protected abstract bool ProcessSend(byte[] buffer, int offset, int length);
        
        protected virtual void ProcessReceive(byte[] buffer, int offset, int length)
        {
            lock (DecodeStack)
            {
                Decoder.Reset();
                Decoder.Encode(buffer, offset, length);
                DataReceived?.Invoke(this, 
                    Decoder.OutputStream.Buffer, 
                    Decoder.OutputStream.Position, 
                    Decoder.OutputStream.Count - Decoder.OutputStream.Position);
            }
        }

        /// <summary>
        /// Оптимизированная обработка получения данных с использованием Span.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void ProcessReceive(ReadOnlySpan<byte> data)
        {
            lock (DecodeStack)
            {
                Decoder.Reset();
                Decoder.OutputStream.Clear();
                Decoder.OutputStream.PushBack(data);
                DataReceived?.Invoke(this, 
                    Decoder.OutputStream.Buffer, 
                    Decoder.OutputStream.Position, 
                    Decoder.OutputStream.Count - Decoder.OutputStream.Position);
            }
        }
    }
}
