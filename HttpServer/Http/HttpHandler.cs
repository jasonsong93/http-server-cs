using HttpServer.Interfaces;

namespace HttpServer.Http;

public class HttpHandler : IHttpHandler
{
    public HttpResponse HandleRequest(HttpRequest request)
    {
        throw new NotImplementedException();
    }
}