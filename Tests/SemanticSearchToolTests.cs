using Core.Models;
using MCPServer.Tools;

namespace Tests;

public sealed class SemanticSearchToolTests
{
    [Fact]
    public void Search_ReturnsHardcodedResults_RegardlessOfInput()
    {
        var results = SemanticSearchTool.Search(query: "anything", topK: 10);

        Assert.NotNull(results);
        Assert.Equal(2, results.Count);
    }

    [Fact]
    public void Search_FirstResult_HasExpectedFields()
    {
        var results = SemanticSearchTool.Search(query: "test", topK: 1);

        SearchResult first = results[0];
        Assert.False(string.IsNullOrWhiteSpace(first.ChunkId));
        Assert.False(string.IsNullOrWhiteSpace(first.DocumentTitle));
        Assert.False(string.IsNullOrWhiteSpace(first.ChunkText));
        Assert.InRange(first.Score, 0.0, 1.0);
    }

    [Fact]
    public void Search_ScoresAreDescending()
    {
        var results = SemanticSearchTool.Search(query: "embeddings", topK: 5);

        for (int i = 1; i < results.Count; i++)
            Assert.True(results[i - 1].Score >= results[i].Score,
                $"Expected results[{i - 1}].Score >= results[{i}].Score");
    }
}
