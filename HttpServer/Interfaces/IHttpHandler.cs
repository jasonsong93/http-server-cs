using HttpServer.Http;

namespace HttpServer.Interfaces;

public interface IHttpHandler
{
    HttpResponse HandleRequest(HttpRequest request);
}