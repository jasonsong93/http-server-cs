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
        response.AppendLine($"HTTP/1.1 {StatusCode} {ReasonPhrase}");
        foreach (var header in Headers)
        {
            response.AppendLine($"{header.Key}: {header.Value}");
        }
        response.AppendLine();  // blank line
        response.Append(Body);
        return response.ToString();

    }
}