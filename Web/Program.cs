using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var mcpBaseUrl = builder.Configuration["McpServer:BaseUrl"]
    ?? throw new InvalidOperationException("McpServer:BaseUrl is not configured.");

builder.Services.AddHttpClient("McpServer", client =>
    client.BaseAddress = new Uri(mcpBaseUrl));

await builder.Build().RunAsync();
