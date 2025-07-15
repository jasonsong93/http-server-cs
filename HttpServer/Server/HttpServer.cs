using System.Net;
using HttpServer.Http;
using HttpServer.Interfaces;
using HttpServer.Networking;
using TcpListener = HttpServer.Networking.TcpListener;

namespace HttpServer.Server;

public class HttpServer
{
    private readonly IPAddress _address;
    private readonly int _port;
    private readonly HttpHandler _handler;
    private readonly TcpListener _listener;
    private readonly ILogger _logger;

    public HttpServer(IPAddress address, int port, HttpHandler handler, ILogger logger)
    {
        _address = address;
        _port = port;
        _handler = handler;
        _logger = logger;
        _listener = new TcpListener(address, port);
    }

    public void Start()
    {
        // Binds to the IP address and port, then listens
        _listener.Start();
        _logger.Log($"Server started on {_address}:{_port}");
        while (true)
        {
            // Accepts a single new connection
            var socket = _listener.Accept();
            var connection = new Connection(socket);
            var reader = connection.GetReader();
            var writer = connection.GetWriter();
            
            var request = HttpParser.ParseRequest(reader);
            var response = _handler.HandleRequest(request);

            Console.WriteLine(response.ToString());
            
        }
    }
}