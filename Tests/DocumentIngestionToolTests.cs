using Core.Models;
using Core.VectorStore;
using MCPServer.Tools;

namespace Tests;

public sealed class DocumentIngestionToolTests
{
    private readonly DocumentIngestionTool _tool = new(new InMemoryVectorStore());

    [Fact]
    public void Ingest_ReturnsStatus200()
    {
        var result = _tool.Ingest(title: "Any Title", content: "# Heading\nSome content.");

        Assert.Equal(200, result.Status);
    }

    [Fact]
    public void Ingest_ReturnsNonEmptyMessage()
    {
        var result = _tool.Ingest(title: "Any Title", content: "# Heading\nSome content.");

        Assert.False(string.IsNullOrWhiteSpace(result.Message));
    }
}
