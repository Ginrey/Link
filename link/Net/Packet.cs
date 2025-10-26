using System;
using Link.IO;

namespace Link.Net
{
    public class Packet : IDisposable
    {
        public uint Id { get; }
        public DataStream Stream { get; }
        private bool _disposed;

        public Packet(uint id, DataStream stream)
        {
            Id = id;
            Stream = stream;
        }

        public static Packet Create(uint id, IDataSerializer packet)
        {
            var stream = new DataStream();
            stream.Write(packet);
            return new Packet(id, stream);
        }

        public T Read<T>() where T : IDataSerializer, new()
        {
            Stream.Position = 0;
            var obj = new T();
            if (!obj.TryDeserialize(Stream))
            {
                throw new InvalidOperationException("Failed to deserialize packet content.");
            }
            return obj;
        }

        public bool TryRead<T>(out T result) where T : IDataSerializer, new()
        {
            Stream.Position = 0;
            result = new T();
            return result.TryDeserialize(Stream);
        }

        public Packet Write(IDataSerializer packet)
        {
            Stream.Clear();
            packet.Serialize(Stream);
            return this;
        }

        public void Dispose()
        {
            if (_disposed) return;
            Stream.Dispose();
            _disposed = true;
        }
    }
}
