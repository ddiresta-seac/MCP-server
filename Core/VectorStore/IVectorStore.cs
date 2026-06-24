using Core.Models;

namespace Core.VectorStore;

/// <summary>
/// Stores and retrieves document chunks together with their embedding vectors.
/// </summary>
public interface IVectorStore
{
    /// <summary>Stores a chunk alongside its embedding vector.</summary>
    void Store(DocumentChunk chunk, float[] vector);

    /// <summary>Returns all stored (chunk, vector) pairs as a snapshot.</summary>
    IReadOnlyList<(DocumentChunk Chunk, float[] Vector)> GetAll();
}
