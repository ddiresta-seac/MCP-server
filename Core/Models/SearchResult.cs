namespace Core.Models;

/// <summary>
/// Represents a single search result returned by semantic search.
/// </summary>
/// <param name="ChunkId">Unique identifier of the document chunk.</param>
/// <param name="DocumentTitle">Title of the source document.</param>
/// <param name="ChunkText">The text content of the chunk.</param>
/// <param name="Score">Cosine similarity score between the query and this chunk (0–1).</param>
public record SearchResult(
    string ChunkId,
    string DocumentTitle,
    string ChunkText,
    double Score);
