using System.Net;
using HttpServer.Http;
using HttpServer.Networking;
using TcpListener = HttpServer.Networking.TcpListener;

namespace HttpServer.Server;

public class HttpServer
{
    private readonly IPAddress _address;
    private readonly int _port;
    private readonly TcpListener _listener;

    public HttpServer(IPAddress address, int port)
    {
        _address = address;
        _port = port;
        _listener = new TcpListener(address, port);
    }

    public void Start()
    {
        // Binds to the IP address and port, then listens
        _listener.Start();
        Console.WriteLine($"Server started on {_address}:{_port}");
        
        while (true)
        {
            // Accepts a single new connection
            var socket = _listener.Accept();
            var connection = new Connection(socket);
            var reader = connection.GetReader();
            var writer = connection.GetWriter();

            var request = HttpParser.ParseRequest(reader);
            var handler = new HttpHandler();
            var response = handler.HandleRequest(request);
        }
    }
}