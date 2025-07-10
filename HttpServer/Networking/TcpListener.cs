using System.Net;
using System.Net.Sockets;

namespace HttpServer.Networking;

/// <summary>
/// Custom TCP listener I created that wraps the socket
/// Basically wraps the raw socket to bind and then listen to connections
/// for a specific IP address and port number
///
/// The backlog specifies how many total requests the server can queue before
/// refusing more connections
///
/// You should probably just use the built-in .NET TcpListener here:
/// https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcplistener?view=net-9.0
/// </summary>
public class TcpListener
{
    private readonly IPEndPoint _localEndpoint;
    private readonly Socket _listenerSocket;

    public TcpListener(IPAddress address, int port)
    {
        _localEndpoint = new IPEndPoint(address, port);
        _listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public void Start()
    {
        const int backLog = 100;
        _listenerSocket.Bind(_localEndpoint);
        _listenerSocket.Listen(backLog);
    }

    public Socket Accept()
    {
        return _listenerSocket.Accept();
    }

    public void Stop()
    {
    }
}