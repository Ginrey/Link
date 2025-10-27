namespace Link.Net;

public class RouteChain : Route
{
    public Route Next { get; set; }

    public static void Combine(RouteChain inputRoute, Route outputRoute)
    {
        inputRoute.Next = outputRoute;
    }

    public RouteChain() : this(null)
    {
            
    }
    public RouteChain(Route outputRoute)
    {
        Next = outputRoute;
    }

    public override bool Send(Packet packet)
    {
        return Next?.Send(packet) ?? false;
    }
    public void Clear()
    {
        Next = null;
    }
}