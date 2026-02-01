using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Overlay orchestration.
/// Canonical:
/// - overlay manifest JSON MUST validate against specs/overlay.schema.json
/// - overlay manifest JSON MUST be stored in ObjectStore (sha256 identity)
/// - events MUST reference overlay object sha256 in outputs
/// </summary>
public interface IOverlayOrchestrator
{
    Task<OverlayOutcome> IngestAsync(OverlayIngestRequest req, CancellationToken ct);
    Task<OverlayOutcome> UpdateAsync(OverlayIngestRequest req, CancellationToken ct);
}

public sealed record OverlayIngestRequest(
    OperationContext Context,
    string ImporterName,
    string ImporterVersion,

    /// <summary>
    /// Raw overlay manifest JSON that MUST validate against specs/overlay.schema.json.
    /// Canonical: MUST store in ObjectStore and reference by sha256 in events.
    /// </summary>
    string OverlayManifestJson,

    IReadOnlyList<string> RequestedCapabilities,
    IReadOnlyDictionary<string, object>? Attributes
);

public sealed record OverlayOutcome(
    ObjectRef OverlayManifestObject,
    PolicyDecision PolicyDecision,
    EventRecord Event
);
