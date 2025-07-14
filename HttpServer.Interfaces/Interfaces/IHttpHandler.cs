using HttpServer.Server;

namespace Interfaces.Interfaces;

public interface IHttpHandler
{
    HttpResponse HandleRequest(HttpRequest request);
}