using MCPServer.Tools;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMcpServer()
    .WithHttpTransport(o => o.Stateless = true)
    .WithTools<SemanticSearchTool>();

var app = builder.Build();

app.MapMcp();

app.Run();
