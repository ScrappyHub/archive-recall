using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Snapshot providers are pluggable.
/// CANONICAL (locked):
/// - Snapshot request JSON MUST be stored in IObjectStore (sha256 identity).
/// - Snapshot result JSON MUST be stored in IObjectStore (sha256 identity).
/// - Events MUST reference request/result objects in inputs/outputs with sha256 set.
/// - Exported artifact hashes are optional, but if present MUST be stored in IObjectStore.
/// </summary>
public interface ISnapshotProvider
{
    string ProviderId { get; }
    string ProviderKind { get; } // "virtualbox" | "hyperv" | "vmware" | ...

    SnapshotProviderManifestRef ManifestRef { get; }

    Task<SnapshotResultRef> CreateSnapshotAsync(
        OperationContext ctx,
        SnapshotTarget target,
        SnapshotRequestRef request,
        CancellationToken ct
    );

    Task<SnapshotResultRef> RestoreSnapshotAsync(
        OperationContext ctx,
        SnapshotTarget target,
        SnapshotRequestRef request,
        CancellationToken ct
    );

    /// <summary>
    /// Optional: export/materialize snapshot into an artifact.
    /// If export is supported and executed, exported artifact MUST be stored in IObjectStore and returned here.
    /// </summary>
    Task<(SnapshotResultRef Result, SnapshotExport? Export)> ExportSnapshotAsync(
        OperationContext ctx,
        SnapshotTarget target,
        SnapshotRequestRef request,
        CancellationToken ct
    );
}
