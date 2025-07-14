using HttpServer.Server;

namespace HttpServer.Http;

public static class HttpParser
{
    public static HttpRequest ParseRequest(StreamReader reader)
    {
        // Should parse the request into an HttpResponse type 
        return new HttpRequest();
    }
}