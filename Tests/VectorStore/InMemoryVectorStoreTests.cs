using Core.Models;
using Core.VectorStore;

namespace Tests.VectorStore;

public sealed class InMemoryVectorStoreTests
{
    private readonly InMemoryVectorStore _store = new();

    [Fact]
    public void Store_AddsEntry()
    {
        var chunk = new DocumentChunk("doc#0", "Doc", "content");

        _store.Store(chunk, new float[] { 0.1f, 0.2f });

        Assert.Equal(1, _store.GetAll().Count);
    }

    [Fact]
    public void Store_PreservesChunk()
    {
        var chunk = new DocumentChunk("doc#0", "Doc", "content");

        _store.Store(chunk, new float[] { 0.1f });

        Assert.Equal(chunk, _store.GetAll()[0].Chunk);
    }

    [Fact]
    public void Store_PreservesVector()
    {
        var vector = new float[] { 0.5f, 0.9f };

        _store.Store(new DocumentChunk("doc#0", "Doc", "text"), vector);

        Assert.Equal(vector, _store.GetAll()[0].Vector);
    }

    [Fact]
    public void Store_MultipleEntries_AllPresent()
    {
        _store.Store(new DocumentChunk("a#0", "A", "a"), []);
        _store.Store(new DocumentChunk("b#0", "B", "b"), []);
        _store.Store(new DocumentChunk("c#0", "C", "c"), []);

        Assert.Equal(3, _store.GetAll().Count);
    }
}
