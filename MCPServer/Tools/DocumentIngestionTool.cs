using Core.Models;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace MCPServer.Tools;

[McpServerToolType]
public sealed class DocumentIngestionTool
{
    [McpServerTool(Name = "ingest_document")]
    [Description("Ingests a Markdown document into the knowledge base, chunking and embedding it for semantic search.")]
    public static IngestResult Ingest(
        [Description("The title of the document.")] string title,
        [Description("The full Markdown content of the document.")] string content)
    {
        // Walking skeleton: ignore inputs, return hardcoded success.
        return new IngestResult(200, "Document accepted.");
    }
}
