using System.Runtime.InteropServices;

namespace HttpServer.Http;

public static class HttpParser
{
    /*
     * HTTP-message   = start-line
     *( header-field CRLF )
     CRLF
     [ message-body ]
    */
    public static HttpRequest ParseRequest(StreamReader reader)
    {
        // Reading the startLine in
        var startLine = reader.ReadLine();
        if (string.IsNullOrWhiteSpace(startLine))
        {
            // Probably a better way to handle this - fix it later
            return new HttpRequest();
        }

        var parts = startLine.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
        var method = parts[0];
        var target = parts[1];
        var version = parts[2];
        
        // Reading headers
        var headers = new Dictionary<string, string>();

        string line;
        while (!string.IsNullOrWhiteSpace(line = reader.ReadLine()))
        {
            var colonIndex = line.IndexOf(':');
            // Need to handle this case where there is no data data, or the oclon doesn't exist
            if (colonIndex <= 0)
            {
                return new HttpRequest();
            }

            var name = line[..colonIndex].Trim();
            var value = line[(colonIndex + 1)..].Trim();
            // We avoid the dictionary.Add here because of dupes
            // and just want the latest/up to date header details
            // Assume 1 header 1 value for now but
            // we have things like Set-Cooked and Accept
            // but then we'll need Dictionary<string, List<string>> 
            headers[name] = value;
        }
        
        var body = string.Empty;
        
        if (headers.TryGetValue("Content-Length", out var contentLengthStr) &&
            int.TryParse(contentLengthStr, out var contentLength) && contentLength > 0)
        {
            var buffer = new char[contentLength];
            reader.ReadBlock(buffer, 0, contentLength);
            body = new string(buffer);
        }

        return new HttpRequest
        {
            Method = method,
            Target = target,
            Version = version,
            Headers = headers,
            Body = body
        };
    }
}