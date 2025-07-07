using Server = HttpServer.Server.HttpServer;

// We can create a manager to handle HTTPS later
const int port = 80;

var server = new Server(port);
server.Start();