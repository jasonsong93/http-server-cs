using System.Net;
using System.Net.Sockets;

namespace HttpServer.Server;

public class HttpServer
{
    private int port;
    public HttpServer(int port)
    {
        this.port = port;
    }

    public void Start()
    {
        // Create a client on a socket
        var listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        
        while (true)
        {
            var client = listener.AcceptTcpClient();
            Console.WriteLine("Client is now connected!");
        }
    }
}