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
/// CANONICAL (locked):
/// Snapshot Request and Result JSON MUST be stored as objects in IObjectStore (sha256 identity).
/// Events MUST reference them in inputs/outputs with sha256 set.
/// </summary>
public sealed record SnapshotRequestRef(
    string RequestId,
    ObjectRef StoredObject
);

public sealed record SnapshotResultRef(
    string ResultId,
    ObjectRef StoredObject
);

public sealed record SnapshotTarget(
    string VmId,
    string? VmName
);

/// <summary>
/// Optional: some providers can materialize/export a snapshot into an artifact file.
/// If exported, that artifact MUST be stored in IObjectStore (sha256 identity) and may be referenced by events.
/// </summary>
public sealed record SnapshotExport(
    ObjectRef ExportedArtifact,
    string? Notes
);
