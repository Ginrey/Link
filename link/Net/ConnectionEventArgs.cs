namespace Link.Net;

public class ConnectionEventArgs
{
    public Connection Connection { get; private set; }

    public ConnectionEventArgs(Connection connection)
    {
        Connection = connection;
    }
}
