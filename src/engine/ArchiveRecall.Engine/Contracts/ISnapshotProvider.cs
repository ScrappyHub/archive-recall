using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Snapshot providers are pluggable.
/// Snapshot request/result are canonical JSON artifacts (recommended: stored as objects in ObjectStore).
/// Provider selection is policy-controlled.
/// </summary>
public interface ISnapshotProvider
{
    string ProviderId { get; }
    string ProviderKind { get; } // "virtualbox" | "hyperv" | "vmware" | ...

    /// <summary>
    /// Provider manifest reference (canonical artifact sha256).
    /// </summary>
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
    /// Optional: materialize/export snapshot to an artifact and return its object ref.
    /// If export is supported, exported artifact hashes must be recorded (canonical optional).
    /// </summary>
    Task<(SnapshotResultRef Result, SnapshotExport? Export)> ExportSnapshotAsync(
        OperationContext ctx,
        SnapshotTarget target,
        SnapshotRequestRef request,
        CancellationToken ct
    );
}
