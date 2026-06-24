using Core.Models;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace MCPServer.Tools;

[McpServerToolType]
public sealed class SemanticSearchTool
{
    [McpServerTool(Name = "semantic_search")]
    [Description("Performs semantic search over ingested documents and returns the most relevant chunks.")]
    public static IReadOnlyList<SearchResult> Search(
        [Description("The natural language query to search for.")] string query,
        [Description("Maximum number of results to return.")] int topK = 5)
    {
        // Walking skeleton: ignore inputs, return hardcoded fake results.
        return
        [
            new SearchResult(
                ChunkId: "doc-001#chunk-1",
                DocumentTitle: "Introduction to Semantic Search",
                ChunkText: "Semantic search uses vector embeddings to find documents that are conceptually similar to a query, even when they do not share exact keywords.",
                Score: 0.95),

            new SearchResult(
                ChunkId: "doc-002#chunk-3",
                DocumentTitle: "ONNX Models for Text Embedding",
                ChunkText: "ONNX Runtime allows running pre-trained transformer models locally without calling external APIs, making embedding generation fast and private.",
                Score: 0.87),
        ];
    }
}