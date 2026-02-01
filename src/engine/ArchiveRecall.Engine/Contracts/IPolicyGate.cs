using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Policy gate returns ALLOW/DENY with reason codes and granted capabilities.
/// Compatible with Covenant Gate deny/allow semantics.
/// </summary>
public interface IPolicyGate
{
    Task<PolicyDecision> EvaluateAsync(PolicyRequest request, CancellationToken ct);
}

public sealed record PolicyRequest(
    OperationContext Context,
    string RequestedAction,              // e.g., "SNAPSHOT_CREATE", "LOAD_COMMIT", "IMPORT_OVERLAY"
    IReadOnlyList<string> RequestedCapabilities,
    IReadOnlyDictionary<string, object>? Attributes // provider_kind, mount_id, file types, etc.
);
