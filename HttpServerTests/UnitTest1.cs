namespace HttpServerTests;
using HttpServer.Server;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        const int port = 80;
        var server = new HttpServer(port);
        Assert.NotNull(server);
    }
}