using System.Net;

namespace HttpServerTests;
using HttpServer.Server;

public class HttpServerTests
{
    [Fact]
    public void Test1()
    {
        const int port = 80;
        var server = new HttpServer(IPAddress.Any, port);
        Assert.NotNull(server);
    }
}