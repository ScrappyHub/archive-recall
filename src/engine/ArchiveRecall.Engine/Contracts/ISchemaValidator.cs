namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Contract-only schema validation interface.
/// Implementation will validate JSON payloads against the canonical schemas in /specs.
/// </summary>
public interface ISchemaValidator
{
    Task ValidateAsync(string schemaName, string json, CancellationToken ct);
}
