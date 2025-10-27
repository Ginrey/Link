using System;
using System.Collections.Generic;
using Link.IO;

namespace Link.Net.Protocol;

public class ProtoDictionaryTable : ProtoTable
{
    protected readonly Dictionary<Type, IPacketBuilder> TypeTable = new();
    protected readonly Dictionary<uint, IPacketBuilder> IdTable = new();
    protected readonly object lockObject = new();

    public object LockObject => lockObject;

    public virtual void Register<T>(PacketBaseInformation information) where T : IDataSerializer
    {
        if (information == null)
        {
            return;
        }
        if (Helpers.FastConstructor<T>.Exists)
        {
            Register(Helpers.FastConstructor<T>.Create, information);
        }
    }
    public virtual void Register<T>(Func<T> constructor, PacketBaseInformation information) where T : IDataSerializer
    {
        if (constructor == null || information == null)
        {
            return;
        }
        var builder = new PacketBuilder<T>();
        builder.Setup(information, constructor);
        Register(builder);
    }
    public virtual void Register<T>(IPacketBuilder<T> builder) where T : IDataSerializer
    {
        if (builder == null)
        {
            return;
        }
        Register(typeof(T), builder);
    }
    public virtual void Register(Type type, IPacketBuilder builder)
    {
        if (builder.Information == null || builder == null)
        {
            return;
        }
        lock (lockObject)
        {
            IdTable[builder.Information.Id] = builder;
            TypeTable[type] = builder;
        }
    }
    public virtual void Register<T>() where T : IDataSerializer
    {
        Register(Helpers.FastConstructor<T>.Create);
    }
    public virtual void Register<T>(Func<T> constructor) where T : IDataSerializer
    {
        var builder = new PacketBuilder<T>();
        builder.Setup(constructor);
        lock (lockObject)
        {
            TypeTable[typeof(T)] = builder;
        }
    }

    public override IPacketContainer GetContainer(Type type)
    {
        lock (lockObject)
        {
            TypeTable.TryGetValue(type, out IPacketBuilder result);
            return result?.CreateContainer() ?? null;
        }
    }

    public override IPacketContainer GetContainer(uint packetId)
    {
        lock (lockObject)
        {
            IdTable.TryGetValue(packetId, out IPacketBuilder result);
            return result?.CreateContainer() ?? null;
        }
    }

    public override IPacketBuilder GetBuilder(Type type)
    {
        lock (lockObject)
        {
            TypeTable.TryGetValue(type, out IPacketBuilder result);
            return result;
        }
    }

    public override IPacketBuilder GetBuilder(uint packetId)
    {
        lock (lockObject)
        {
            IdTable.TryGetValue(packetId, out IPacketBuilder result);
            return result;
        }
    }

    public override PacketBaseInformation GetInfo(Type type)
    {
        lock (lockObject)
        {
            TypeTable.TryGetValue(type, out IPacketBuilder result);
            return result?.Information ?? null;
        }
    }

    public override PacketBaseInformation GetInfo(uint packetId)
    {
        lock (lockObject)
        {
            IdTable.TryGetValue(packetId, out IPacketBuilder result);
            return result?.Information ?? null;
        }
    }

    public override IDataSerializer Get(Type type)
    {
        var builder = GetBuilder(type);
        return builder?.Create();
    }
}