using Core.Models;

namespace Core.VectorStore;

/// <summary>
/// In-memory implementation of <see cref="IVectorStore"/> for development and testing.
/// All entries are lost when the process restarts. Will be replaced by the SQLite
/// vector store in a later iteration.
/// </summary>
public sealed class InMemoryVectorStore : IVectorStore
{
    private readonly List<(DocumentChunk Chunk, float[] Vector)> _entries = [];
    private readonly object _lock = new();

    public void Store(DocumentChunk chunk, float[] vector)
    {
        lock (_lock)
        {
            _entries.Add((chunk, vector));
        }
    }

    public IReadOnlyList<(DocumentChunk Chunk, float[] Vector)> GetAll()
    {
        lock (_lock)
        {
            return _entries.ToList();
        }
    }
}
