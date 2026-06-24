using Core.Models;
using MCPServer.Tools;

namespace Tests;

public sealed class DocumentIngestionToolTests
{
    [Fact]
    public void Ingest_ReturnsStatus200()
    {
        var result = DocumentIngestionTool.Ingest(title: "Any Title", content: "# Heading\nSome content.");

        Assert.Equal(200, result.Status);
    }

    [Fact]
    public void Ingest_ReturnsNonEmptyMessage()
    {
        var result = DocumentIngestionTool.Ingest(title: "Any Title", content: "# Heading\nSome content.");

        Assert.False(string.IsNullOrWhiteSpace(result.Message));
    }
}
