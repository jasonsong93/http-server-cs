# HTTP Server built in C#

A minimal HTTP/1.1 server written from scratch in C#.  
No frameworks - just raw sockets and following the RFC specification.

I had previously followed a tutorial in Java here which I would highly recommend as an introduction.
[Link - ↗](https://www.youtube.com/watch?v=FNUdLeGfShU&list=PLAuGQNR28pW56GigraPdiI0oKwcs8gglW)

This is mostly for learning, experimenting, and understanding how HTTP actually works under the hood.

---

## What is this?

This an RFC compliant HTTP server that:

- Listens on a TCP port
- Parses incoming HTTP requests (method, path, headers, body)
- Decides how to respond based on the path (basic router)
- Writes back a valid HTTP response (status line, headers, body)
- Closes the connection (via `Connection: close`)

---

## Try it out
Using curl:
```bash
curl -v http://localhost:8080/
```
or hit it in your browser.
Right now it just does something minimal like:
/ → returns 200 OK with "Hello, world!"

anything else → returns 404 Not Found