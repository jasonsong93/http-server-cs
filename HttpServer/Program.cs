using System.Net;
using Server = HttpServer.Server.HttpServer;

// Need a better way to configure the port number 
var server = new Server(IPAddress.Any, 8080);
server.Start();