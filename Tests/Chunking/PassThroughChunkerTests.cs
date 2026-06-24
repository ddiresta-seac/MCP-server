using Core.Chunking;

namespace Tests.Chunking;

public sealed class PassThroughChunkerTests
{
    private readonly IChunker _chunker = new PassThroughChunker();

    [Fact]
    public void Chunk_SingleContent_ReturnsOneChunk()
    {
        var result = _chunker.Chunk("MyDoc", "# Hello\nSome content.");

        Assert.Equal(1, result.Count);
    }

    [Fact]
    public void Chunk_ChunkTextMatchesInput()
    {
        const string content = "# Hello\nSome content.";

        var result = _chunker.Chunk("MyDoc", content);

        Assert.Equal(content, result[0].Text);
    }

    [Fact]
    public void Chunk_ChunkIdContainsTitle()
    {
        var result = _chunker.Chunk("MyDoc", "content");

        Assert.StartsWith("MyDoc", result[0].ChunkId);
    }

    [Fact]
    public void Chunk_DocumentTitleSetCorrectly()
    {
        var result = _chunker.Chunk("MyDoc", "content");

        Assert.Equal("MyDoc", result[0].DocumentTitle);
    }

    [Fact]
    public void Chunk_EmptyContent_ReturnsOneChunk()
    {
        var result = _chunker.Chunk("EmptyDoc", string.Empty);

        Assert.Single(result);
    }
}
