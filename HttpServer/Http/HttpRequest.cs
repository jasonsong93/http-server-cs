namespace HttpServer.Server;

/// <summary>
/// See the following specs:
/// https://datatracker.ietf.org/doc/html/rfc7230#section-3
/// and a bit ofplugin
/// https://datatracker.ietf.org/doc/html/rfc7231
/// 
/// </summary>

public class HttpRequest
{
    /*
     * HTTP-message   = start-line
       *( header-field CRLF )
       CRLF
       [ message-body ]
     */
    
    // The start-line is modelled as 3 parts, eg:
    // Method: GET
    // Target: /index.html
    // HTTP Version: HTTP/1.1
    public string Method { get; set; } = string.Empty;
    public string Target { get; set; } = string.Empty;
}