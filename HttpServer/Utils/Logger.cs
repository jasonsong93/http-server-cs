using Interfaces.Interfaces;

namespace HttpServer.Utils;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] {message}");
    }
}