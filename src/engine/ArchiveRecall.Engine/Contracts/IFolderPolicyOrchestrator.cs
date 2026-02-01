using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Folder policy orchestration.
/// Canonical:
/// - folder policy JSON MUST validate against specs/folder_policy.schema.json
/// - folder policy JSON MUST be stored in ObjectStore (sha256 identity)
/// - enforcement is applied during import/transform/load/maintenance
/// </summary>
public interface IFolderPolicyOrchestrator
{
    Task<FolderPolicyOutcome> SetAsync(FolderPolicySetRequest req, CancellationToken ct);
    Task<FolderPolicyOutcome> RemoveAsync(FolderPolicyRemoveRequest req, CancellationToken ct);
}

public sealed record FolderPolicySetRequest(
    OperationContext Context,

    /// <summary>
    /// Raw folder policy JSON that MUST validate against specs/folder_policy.schema.json.
    /// Canonical: MUST store in ObjectStore and reference by sha256 in events.
    /// </summary>
    string FolderPolicyJson,

    IReadOnlyList<string> RequestedCapabilities,
    IReadOnlyDictionary<string, object>? Attributes
);

public sealed record FolderPolicyRemoveRequest(
    OperationContext Context,
    string PolicyId,
    IReadOnlyList<string> RequestedCapabilities,
    IReadOnlyDictionary<string, object>? Attributes
);

public sealed record FolderPolicyOutcome(
    ObjectRef PolicyObject,
    PolicyDecision PolicyDecision,
    EventRecord Event
);
