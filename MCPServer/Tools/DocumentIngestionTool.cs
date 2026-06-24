using Core.Chunking;
using Core.Models;
using Core.VectorStore;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace MCPServer.Tools;

[McpServerToolType]
public sealed class DocumentIngestionTool(IVectorStore vectorStore)
{
    private static readonly IChunker Chunker = new PassThroughChunker();

    [McpServerTool(Name = "ingest_document")]
    [Description("Ingests a Markdown document into the knowledge base, chunking and embedding it for semantic search.")]
    public IngestResult Ingest(
        [Description("The title of the document.")] string title,
        [Description("The full Markdown content of the document.")] string content)
    {
        var chunks = Chunker.Chunk(title, content);

        foreach (var chunk in chunks)
        {
            // Embedding placeholder: real IEmbedder arrives in the next iteration.
            vectorStore.Store(chunk, new float[0]);
        }

        return new IngestResult(200, $"{chunks.Count} chunk(s) stored.");
    }
}

