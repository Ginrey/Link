using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Link.Pools;
using Link.IO;
using Link.Modules;
using Link.Net.Protocol;
using Link.Net.Protocol.Core;

namespace Link.Net;

public class Session
{
    public Connection? Connection { get; private set; }
    public IConnectionConfigurator? ConnectionConfigurator { get; set; }

    public IPool<DataStream> DataStreamPool { get; set; }

    public PacketPolicy PacketPolicy { get; private set; }
    public PacketWriter PacketWriter { get; private set; }
    public PacketReader PacketReader { get; private set; }
        
    public PacketHandlerTable Handler { get; private set; }

    private readonly RouteOutputHandler connectionOutputRoute;
    private readonly RouteChain connectionInputRoute;
        


    public RouteSession InputChain { get; private set; }
    public RouteSession OutputChain { get; private set; }


    public event EventHandler? StateChanged;
    private SessionState state = SessionState.NotWorking;
    public SessionState State
    {
        get => state;
        protected set
        {
            state = value;
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public ProtoListTable Proto { get; private set; }
    public ModulesManager Modules { get; private set; }

    private readonly SemaphoreSlim _connectionSemaphore = new(1, 1);
    private readonly Lock _packetWriterLock = new();
    private CancellationTokenSource? _dataReceiverCts;

    public Session(
        IPool<DataStream>? dataStreamPool = null, 
        PacketReader? packetReader = null, 
        PacketWriter? packetWriter = null,
        PacketPolicy? packetPolicy = null,
        ProtoListTable? baseProto = null)
    {
        dataStreamPool ??= Link.Pools.DataStreamPool.Instance;
        packetReader ??= new PacketReader(dataStreamPool.Take(), dataStreamPool.Take());
        packetWriter ??= new PacketWriter(dataStreamPool.Take(), dataStreamPool.Take());
        packetPolicy ??= PacketPolicy.AllAcceptPolicy;

        DataStreamPool = dataStreamPool;
        PacketReader = packetReader;
        PacketWriter = packetWriter;
        PacketPolicy = packetPolicy;

        Proto = baseProto ?? new ProtoListTable();

        Handler = new PacketHandlerTable
        {
            Proto = Proto
        };
        Modules = new ModulesManager(this);

        connectionInputRoute = new RouteChain();
        connectionOutputRoute = new RouteOutputHandler(SendNext);

        InputChain = new RouteSession();
        OutputChain = new RouteSession();

        InputChain.Handler = OutputChain.Handler = Handler;
        InputChain.Session = OutputChain.Session = this;

        connectionInputRoute.Next = InputChain;
        OutputChain.Next = connectionOutputRoute;

        InputChain.IsInput = true;
        OutputChain.IsInput = false;

        InputChain.Redirect = OutputChain;
        OutputChain.Redirect = InputChain;
    }

    public async Task SetupConnectionAsync(Connection connection, bool start = true)
    {
        if (Connection != null)
        {
            Close();
        }
        
        await _connectionSemaphore.WaitAsync().ConfigureAwait(false);
        
        try
        {
            ConnectionConfigurator?.Configure(connection);

            Connection = connection;
            Connection.StateChanged += Connection_StatusChanged;
            
            // Создаем новый CancellationTokenSource для задачи чтения данных
            _dataReceiverCts?.Cancel();
            _dataReceiverCts?.Dispose();
            _dataReceiverCts = new CancellationTokenSource();
            
            // Запускаем задачу чтения из канала вместо подписки на событие
            _ = Task.Run(() => DataReceiverLoopAsync(_dataReceiverCts.Token), _dataReceiverCts.Token);

            PacketReader.Clear();
            State = SessionState.Working;

            if (start)
            {
                Start();
            }
        }
        finally
        {
            _connectionSemaphore.Release();
        }
    }

    public void SetupConnection(Connection connection, bool start = true)
    {
        // Синхронная обертка - просто вызываем async версию и ждем
        Task.Run(() => SetupConnectionAsync(connection, start)).GetAwaiter().GetResult();
    }

    public virtual void Start()
    {
        Connection?.Start();
    }
    public virtual void Close()
    {
        _dataReceiverCts?.Cancel();
        _dataReceiverCts?.Dispose();
        _dataReceiverCts = null;
        
        Connection?.Stop();
        Connection?.Close();
    }

    private async void Connection_StatusChanged(object? sender, EventArgs e)
    {
        await _connectionSemaphore.WaitAsync().ConfigureAwait(false);
        try
        {
            if (Connection?.State == ConnectionState.Closed)
            {
                // Отменяем задачу чтения из канала
                _dataReceiverCts?.Cancel();
                
                Connection.StateChanged -= Connection_StatusChanged;

                if (ReferenceEquals(sender, Connection))
                {
                    PacketReader.Clear();
                    State = SessionState.Closed;
                }
            }
        }
        finally
        {
            _connectionSemaphore.Release();
        }
    }

    public Packet GetPacket(uint id)
    {
        return GetPacket(id, DataStreamPool.Take());
    }
    public Packet GetPacket(uint id, IDataSerializer packet)
    {
        return GetPacket(id, DataStreamPool.Take(), packet);
    }
    public Packet GetPacket(uint id, DataStream stream, IDataSerializer packet)
    {
        var res = GetPacket(id, stream);
        res.WritePacket(packet);
        return res;
    }
    public Packet GetPacket(uint id, DataStream stream)
    {
        stream.IsLittleEndian = false;
        return new PacketProto(id, stream, Proto);
    }
    public Packet GetPacket<T>(T packet) where T : IDataSerializer
    {
        var info = Proto.GetInfo<T>();
        if (info == null)
        {
            throw new NullReferenceException("Unknwon packet");
        }
        return GetPacket(info.Id, packet);
    }
    public Packet GetPacket<T>(T packet, DataStream stream) where T : IDataSerializer
    {
        var info = Proto.GetInfo<T>();
        if (info == null)
        {
            throw new NullReferenceException("Unknwon packet");
        }
        return GetPacket(info.Id, stream, packet);
    }

    public PacketWriter TakeWriter()
    {
        var writer = new PacketWriter(DataStreamPool.Take(), DataStreamPool.Take());
        return writer;
    }
    public void ReturnWriter(PacketWriter writer)
    {
        DataStreamPool.Return(writer.NetworkStream);
        DataStreamPool.Return(writer.PacketStream);
    }
        
    public void Send<T>(T packet) where T : IDataSerializer
    {
        var info = Proto.GetInfo<T>();
        if (info == null)
        {
            throw new NullReferenceException("Unknwon packet");
        }
        Send(info.Id, packet);
    }
    public void Send(uint packetId, IDataSerializer packet)
    {
        Packet pck = GetPacket(packetId);
        pck.WritePacket(packet);
        Send(pck);
        DataStreamPool.Return(pck.Stream);
    }
    public void Send(uint packetId, DataStream packetStream)
    {
        Send(GetPacket(packetId, packetStream));
    }
    public void Send(Packet packet)
    {
        OutputChain?.Send(packet);
    }
    private async Task<bool> SendNextAsync(object? sender, Packet packet)
    {
        lock (_packetWriterLock) // Используем lock вместо semaphore для коротких синхронных операций
        {
            PacketWriter.Clear();
            PacketWriter.Write(packet);

            return Send(PacketWriter);
        }
    }

    private bool SendNext(object? sender, Packet packet)
    {
        lock (_packetWriterLock)
        {
            PacketWriter.Clear();
            PacketWriter.Write(packet);

            return Send(PacketWriter);
        }
    }

    public async Task<bool> SendNextAsync(params Packet[] packets)
    {
        lock (_packetWriterLock)
        {
            PacketWriter.Clear();
            foreach (var packet in packets)
                PacketWriter.Write(packet);
            return Send(PacketWriter);
        }
    }

    public bool SendNext(params Packet[] packets)
    {
        lock (_packetWriterLock)
        {
            PacketWriter.Clear();
            foreach (var packet in packets)
                PacketWriter.Write(packet);
            return Send(PacketWriter);
        }
    }


    public bool Send(PacketWriter packetWriter)
    {
        return Send(packetWriter.GetBuffer());
    }

    public bool Send(ArraySegment<byte> buffer)
    {
        return Send(buffer.Array!, buffer.Offset, buffer.Count);
    }

    public bool Send(byte[] buffer)
    {
        return Send(buffer, 0, buffer.Length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Send(byte[] buffer, int offset, int length)
    {
        return Connection?.Send(buffer, offset, length) ?? false;
    }

    /// <summary>
    /// Modern Span-based send for better performance.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Send(ReadOnlySpan<byte> data)
    {
        return Connection?.Send(data) ?? false;
    }

    /// <summary>
    /// Async send with cancellation support.
    /// </summary>
    public ValueTask<bool> SendAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken = default)
    {
        if (Connection == null)
            return new ValueTask<bool>(false);
            
        return Connection.SendAsync(buffer, offset, length, cancellationToken);
    }

    /// <summary>
    /// Async send with ReadOnlyMemory for modern async patterns.
    /// </summary>
    public ValueTask<bool> SendAsync(ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default)
    {
        if (Connection == null)
            return new ValueTask<bool>(false);
            
        return Connection.SendAsync(data, cancellationToken);
    }

    /// <summary>
    /// Async send for PacketWriter.
    /// </summary>
    public ValueTask<bool> SendAsync(PacketWriter packetWriter, CancellationToken cancellationToken = default)
    {
        if (Connection == null)
            return new ValueTask<bool>(false);
            
        return Connection.SendAsync(packetWriter.GetBufferMemory(), cancellationToken);
    }

    private async Task<bool> CheckConnectionAsync(Connection connection)
    {
        try
        {
            return ReferenceEquals(connection, Connection);
        }
        finally
        {
        }
    }

    private bool CheckConnection(Connection connection)
    {
        return ReferenceEquals(connection, Connection);
    }

    private void ProcessReceivedPacket(Packet packet)
    {
        InputChain?.Send(packet);
    }

    /// <summary>
    /// Асинхронный цикл чтения данных из канала Connection.DataReceivedChannel.
    /// Заменяет подписку на событие Connection.DataReceived.
    /// </summary>
    private async Task DataReceiverLoopAsync(CancellationToken cancellationToken)
    {
        var connection = Connection;
        if (connection == null)
            return;

        var channelReader = connection.DataReceivedChannel;

        try
        {
            await foreach (var (buffer, offset, length) in channelReader.ReadAllAsync(cancellationToken))
            {
                // Проверяем, что соединение еще актуально
                if (!await CheckConnectionAsync(connection))
                {
                    break;
                }

                ProcessReceivedData(connection, buffer, offset, length);
            }
        }
        catch (OperationCanceledException)
        {
            // Нормальное завершение при отмене
        }
        catch (Exception ex)
        {
            // Логируем ошибку, если есть система логирования
            // В текущей реализации просто завершаем цикл
            Console.WriteLine($"Error in DataReceiverLoop: {ex}");
        }
    }
    
    private void ProcessReceivedData(Connection connection, byte[] buffer, int offset, int length)
    {
        if (!CheckConnection(connection))
        {
            return;
        }
        PacketReader.PushBack(buffer, offset, length);

        while (PacketReader.ReadNext())
        {
            if (!CheckConnection(connection))
            {
                return;
            }
            switch (PacketReader.State)
            {
                case PacketReaderState.Complete:
                {
                    var packet = GetPacket(PacketReader.PacketId, PacketReader.PacketStream);
                    var policyResult = PacketPolicy.CheckPacket(packet);
                    PacketReader.UpdatePolicy(policyResult);

                    if (policyResult == PacketPolicyState.Drop)
                    {
                        Close();
                        return;
                    }
                    if (policyResult == PacketPolicyState.Reject)
                    {
                        continue;
                    }

                    ProcessReceivedPacket(packet);
                }
                    continue;
                case PacketReaderState.WaitingContent:
                {
                    var policyResult = PacketPolicy.CheckLength(PacketReader.PacketId, PacketReader.PacketLength);
                    PacketReader.UpdatePolicy(policyResult);

                    if (policyResult == PacketPolicyState.Drop)
                    {
                        Close();
                        return;
                    }
                }
                    continue;
                case PacketReaderState.WaitingLength:
                {
                    var policyResult = PacketPolicy.CheckId(PacketReader.PacketId);
                    PacketReader.UpdatePolicy(policyResult);

                    if (policyResult == PacketPolicyState.Drop)
                    {
                        Close();
                        return;
                    }
                }
                    continue;
            }
        }

    }
}
