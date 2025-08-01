using System.Text;

namespace HttpServer.Http;

public class HttpResponse
{
    public int StatusCode { get; set; }
    public string ReasonPhrase { get; set; } = string.Empty;
    public Dictionary<string, string> Headers { get; set; } = new();
    public string Body { get; set; } = string.Empty;

    public override string ToString()
    {
        var response = new StringBuilder();
        response.Append($"HTTP/1.1 {StatusCode} {ReasonPhrase}\r\n");
        foreach (var header in Headers)
        {
            response.Append($"{header.Key}: {header.Value}\r\n");
        }
        response.Append("\r\n");
        response.Append(Body);
        return response.ToString();
    }

}