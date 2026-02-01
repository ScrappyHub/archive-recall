namespace ArchiveRecall.Engine.Models;

/// <summary>
/// Snapshot Provider Manifest is a canonical artifact validated against specs/vm_snapshot_provider.schema.json.
/// Stored as an object in the library store and referenced by sha256 in events.
/// </summary>
public sealed record SnapshotProviderManifestRef(
    string ProviderId,
    string ProviderKind,
    Sha256 ManifestSha256
);

/// <summary>
/// Snapshot Request/Result are canonical JSON artifacts:
/// - validate against specs/vm_snapshot_request.schema.json and specs/vm_snapshot_result.schema.json
/// - store as objects in the library store (sha256 identity)
/// - reference as inputs/outputs in events with sha256 set (canonical)
/// </summary>
public sealed record SnapshotRequestRef(
    string RequestId,
    ObjectRef? StoredObject // optional: present when stored as object (canonical recommended)
);

public sealed record SnapshotResultRef(
    string ResultId,
    ObjectRef? StoredObject // optional: present when stored as object (canonical recommended)
);

public sealed record SnapshotTarget(
    string VmId,
    string? VmName
);

public sealed record SnapshotExport(
    ObjectRef ExportedArtifact,
    string? Notes
);
