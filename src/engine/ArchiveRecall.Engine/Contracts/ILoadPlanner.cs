using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Load planning: staged plans that validate against specs/load_plan.schema.json.
/// Commit must be transactional: stage -> verify -> commit.
/// </summary>
public interface ILoadPlanner
{
    /// <summary>
    /// Create a load plan (recommended: store the plan JSON as a canonical object).
    /// </summary>
    Task<LoadPlanRef> CreatePlanAsync(LoadPlanRequest request, CancellationToken ct);

    /// <summary>
    /// Stage plan execution (no target mutation outside staging area).
    /// </summary>
    Task StageAsync(OperationContext ctx, LoadPlanRef plan, CancellationToken ct);

    /// <summary>
    /// Verify staged outputs (hashes + structure).
    /// </summary>
    Task VerifyAsync(OperationContext ctx, LoadPlanRef plan, CancellationToken ct);

    /// <summary>
    /// Commit staged outputs to target.
    /// </summary>
    Task CommitAsync(OperationContext ctx, LoadPlanRef plan, CancellationToken ct);

    /// <summary>
    /// Roll back a staged/committed plan if supported via checkpoints or staged rollback.
    /// </summary>
    Task RollbackAsync(OperationContext ctx, LoadPlanRef plan, CancellationToken ct);
}

public sealed record LoadPlanRequest(
    OperationContext Context,
    string TargetMountId,
    IReadOnlyList<string> RequestedCapabilities,
    IReadOnlyDictionary<string, object> PlanJson // canonical JSON to validate against schema
);
