namespace Core.Models;

/// <summary>
/// Represents the result of a document ingestion request.
/// </summary>
/// <param name="Status">HTTP-style status code (200 = accepted).</param>
/// <param name="Message">Human-readable description of the outcome.</param>
public record IngestResult(int Status, string Message);
