# Copilot Instructions for MCP Server example
## Goal
The goal of this project is to create a simple MCP server that can handle requests from clients and perform semantic search on a collection of documents. The server will ingest documents, generate embeddings for them using a local ONNX model, and store the documents and their embeddings in a local SQLite database. The server will then be able to perform semantic search on the documents based on the embeddings.
The document will be in .MD format
The chunks of the document will be separated by  # H1 headers.
The Blazor WebAssembly frontend will allow users to upload documents, view the ingested documents, and perform semantic search on the documents. The frontend will acts as an MCP client that sends requests to the MCP server and displays the results to the user.

## Stack
This codebase is written in C# and use dotnet 10.0 SDK.
The frontend is written in Blazor WebAssembly and use dotnet 10.0 SDK.

To implement MCP functionality you will use ModelContextProtocol package by Microsoft, which is available on NuGet. You can find the documentation for the package here: https://learn.microsoft.com/en-us/dotnet/api/microsoft.modelcontextprotocol?view=net-10.0

To implement the Semantic saerch of documents you will use Microsoft.SemanticKernel along with a local ONNX embedding model. You can find the documentation for the package here: https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel?view=net-10.0

To store the documents and their embeddings you will use a local SQLite database. You can use the Microsoft.Data.Sqlite package to interact with the SQLite database. You can find the documentation for the package here: https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=net-10.0

We will use sqlite-vector extension to store the embeddings in the SQLite database. You can find the documentation for the extension here: https://github.com/pgvector/sqlite-vector

You will use xUnit for unit testing the codebase. You can find the documentation for the package here: https://xunit.net/

You will use Markdig to parse and render Markdown content. You can find the documentation for the package here: https://github.com/lunet-io/markdig

## Solution structure
The solution will consist of the following projects:
- MCPServer: This project will contain the implementation of the MCP server and the semantic search functionality
- Web: This project will contain the Blazor WebAssembly frontend that will interact with the MCP server
- Tests: This project will contain unit tests for the MCP server and the semantic search functionality
- Core: This project will contain the domain logic: chunking, embedding, vector store, and semantic search.

## Constraints
- No dockerization or containerization of the application is required.
- No external server process the database is tored on a local .db file.
- Embeddings are generated using a local ONNX model, no calls to external APIs for embedding generation.
- The native sqllite-vector extension is used to store the embeddings in the SQLite database, no external vector databases are used.
- Blazor must not duplicate Core's logic, it should only call the MCP server to perform operations and display results.

## Instructions
- Before writing code, propose a plan and the list of files you will touch;
wait for confirmation. 
- One feature at a time. Small, focused diffs: if the changes grow too large, stop
and propose narrowing the scope.
- Generate the tests together with the code, not afterwards.
- After every significant change, state how to verify it (command + expected
result).
- Do not introduce new dependencies without flagging it and explaining why.
- If an instruction conflicts with this file, flag it instead of proceeding.