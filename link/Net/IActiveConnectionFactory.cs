using System;
using System.Threading;
using System.Threading.Tasks;

namespace Link.Net;

public interface IActiveConnectionFactory
{
    event ConnectionEventHandler? ConnectionAccept;
    bool Started { get; }
    void Start();
    Task StartAsync(CancellationToken cancellationToken = default);
    void Stop();
    Task StopAsync(CancellationToken cancellationToken = default);
    void Free(Connection? connection);
}

