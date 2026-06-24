using MCPServer.Tools;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5177")
              .WithMethods("GET", "POST", "DELETE")
              .WithHeaders("Content-Type", "MCP-Protocol-Version", "Mcp-Session-Id")
              .WithExposedHeaders("Mcp-Session-Id")));

builder.Services
    .AddMcpServer()
    .WithHttpTransport(o => o.Stateless = true)
    .WithTools<SemanticSearchTool>();

var app = builder.Build();

app.UseCors();
app.MapMcp();

app.Run();
