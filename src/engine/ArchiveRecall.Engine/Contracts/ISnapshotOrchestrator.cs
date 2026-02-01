using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Deterministic snapshot orchestration.
/// Enforces canonical rules:
/// - validate request/result JSON against schemas
/// - policy gate allow/deny
/// - store request/result JSON as objects (sha256 identity) (CANONICAL)
/// - journal events with request/result inputs/outputs and sha256 set (CANONICAL)
/// </summary>
public interface ISnapshotOrchestrator
{
    Task<SnapshotOperationOutcome> CreateAsync(SnapshotOperationRequest op, CancellationToken ct);
    Task<SnapshotOperationOutcome> RestoreAsync(SnapshotOperationRequest op, CancellationToken ct);
    Task<SnapshotOperationOutcome> ExportAsync(SnapshotOperationRequest op, CancellationToken ct);
}

public sealed record SnapshotOperationRequest(
    OperationContext Context,
    string ProviderId,
    string ProviderKind,                 // "virtualbox"|"hyperv"|"vmware"|...
    SnapshotTarget Target,

    /// <summary>
    /// The raw JSON request payload that MUST validate against specs/vm_snapshot_request.schema.json.
    /// The orchestrator MUST store this JSON in IObjectStore and use it as the canonical request object.
    /// </summary>
    string SnapshotRequestJson,

    /// <summary>
    /// Policy capability set requested by this operation.
    /// e.g. ["vm.snapshot"] or ["vm.restore"] or ["vm.snapshot","filesystem.write"] for export
    /// </summary>
    IReadOnlyList<string> RequestedCapabilities
);

public sealed record SnapshotOperationOutcome(
    SnapshotRequestRef Request,
    SnapshotResultRef Result,
    SnapshotExport? Export,
    PolicyDecision PolicyDecision,
    EventRecord Event
);
