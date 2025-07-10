using System.Net.Sockets;
using System.Text;

namespace HttpServer.Networking;

/// <summary>
/// Wraps the socket so we can easily read and write to it
/// using streams with helper methods to close and flush etc.
///
/// Note that the StreamReader and StreamWriter have buffering built in
/// </summary>
public class Connection
{
    private readonly Socket _clientSocket;
    private readonly NetworkStream _networkStream;
    
    // Maybe allow user config when I learn if it's good/bad practice
    private static readonly Encoding DefaultEncoding = Encoding.UTF8;

    public Connection(Socket clientSocket)
    {
        _clientSocket = clientSocket;
        _networkStream = new NetworkStream(clientSocket);
    }

    public StreamReader GetReader()
    {
        // UTF-8 decoding by default, you can pass in an encoding:
        // new StreamReader(_networkStream, Encoding.<Type>)
        return new StreamReader(_networkStream, DefaultEncoding);
    }

    public StreamWriter GetWriter()
    {
        // UTF-8 encoding by default, you can pass in an encoding:
        // new StreamWriter(_networkStream, Encoding.UTF) { AutoFlush = true }
        return new StreamWriter(_networkStream, DefaultEncoding) { AutoFlush = true };
    }

    public void Close()
    {
        // If the Socket is closed first the NetworkStream might try to access a socket that’s already closed
        // when it attempts to flush or dispose, possibly causing exceptions/errors
        _networkStream.Close();
        _clientSocket.Close();
    }
    
    
}