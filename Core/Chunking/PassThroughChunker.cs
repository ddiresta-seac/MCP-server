using Core.Models;

namespace Core.Chunking;

/// <summary>
/// A pass-through chunker that returns the entire document content as a single chunk.
/// This is the first implementation; the real H1-based chunker will replace it
/// while implementing the same <see cref="IChunker"/> interface.
/// </summary>
public sealed class PassThroughChunker : IChunker
{
    public IReadOnlyList<DocumentChunk> Chunk(string title, string content)
    {
        return [new DocumentChunk(
            ChunkId: $"{title}#0",
            DocumentTitle: title,
            Text: content)];
    }
}
