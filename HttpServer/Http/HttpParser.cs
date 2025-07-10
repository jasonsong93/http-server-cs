using HttpServer.Server;

namespace HttpServer.Http;

public static class HttpParser
{
    public static HttpResponse ParseRequest(StreamReader reader)
    {
        // Should parse the request into an HttpResponse type 
        return new HttpResponse();
    }
}