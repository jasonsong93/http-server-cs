using HttpServer.Interfaces;

namespace HttpServer.Http;

public class HttpHandler : IHttpHandler
{
    public HttpResponse HandleRequest(HttpRequest request)
    {
        var response = new HttpResponse
        {
            StatusCode = 200,
            ReasonPhrase = "OK",
            Headers = new Dictionary<string, string>
            {
                ["Content-Type"] = "text/plain",
                ["Content-Length"] = "5"
            },
            Body = "Hello"
        };

        return response;
    }
}