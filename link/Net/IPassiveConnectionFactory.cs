using System;
using System.Threading;
using System.Threading.Tasks;

namespace Link.Net;

public interface IPassiveConnectionFactory
{
    Connection Take();
    Task<Connection> TakeAsync(CancellationToken cancellationToken = default);
    void Free(Connection? connection);
}

