using Core.Models;

namespace Core.Chunking;

/// <summary>
/// Splits document content into a list of <see cref="DocumentChunk"/> items.
/// </summary>
public interface IChunker
{
    /// <summary>
    /// Splits <paramref name="content"/> into chunks.
    /// </summary>
    /// <param name="title">The document title used to identify chunks.</param>
    /// <param name="content">The full Markdown content of the document.</param>
    /// <returns>An ordered list of chunks.</returns>
    IReadOnlyList<DocumentChunk> Chunk(string title, string content);
}
