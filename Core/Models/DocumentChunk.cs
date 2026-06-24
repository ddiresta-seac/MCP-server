namespace Core.Models;

/// <summary>
/// Represents a single chunk of a document produced by an <see cref="Core.Chunking.IChunker"/>.
/// </summary>
/// <param name="ChunkId">Unique identifier of the chunk, e.g. "{title}#0".</param>
/// <param name="DocumentTitle">Title of the source document this chunk belongs to.</param>
/// <param name="Text">The text content of the chunk.</param>
public record DocumentChunk(string ChunkId, string DocumentTitle, string Text);
