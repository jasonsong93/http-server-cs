using System.Net;
using HttpServer.Http;
using HttpServer.Utils;
using Server = HttpServer.Server.HttpServer;

var handler = new HttpHandler();
var logger = new Logger();

// Need a better way to configure the port number 
var server = new Server(IPAddress.Any, 8080, handler, logger);
server.Start();