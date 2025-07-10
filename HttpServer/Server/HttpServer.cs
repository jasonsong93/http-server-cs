using System.Net;
using System.Net.Sockets;

namespace HttpServer.Server;

public class HttpServer
{
    private readonly int _port;
    public HttpServer(int port)
    {
        _port = port;
    }

    public void Start()
    {
        /* This is the higher-level version, which wraps the socket for you:
        
        var listener = new TcpListener(IPAddress.Any, _port);
        listener.Start();

        while (true)
        {
            var client = listener.AcceptTcpClient();
            Console.WriteLine("Client is now connected!");
        }
        
        */
        
        // This is the raw socket version — gives you full control
        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        // Bind to all network interfaces on the specified port (0.0.0.0:_port)
        socket.Bind(new IPEndPoint(IPAddress.Any, _port));

        /* Start listening with a backlog of 100 connections.
         The OS caps this value, you can check it as follows (silently caps if set higher)
         Linux: cat /proc/sys/net/core/somaxconn
         macOS: sysctl kern.ipc.somaxconn
         Windows: SOMAXCONN constant (≈200-256)
        */
        socket.Listen(100);

        while (true)
        {
            // Accept an incoming connection (blocking call)
            var clientSocket = socket.Accept();
            Console.WriteLine("Client is now connected!");
        }
    }
}