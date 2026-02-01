using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Deterministic load orchestration.
/// Enforces:
/// - validate load plan JSON against specs/load_plan.schema.json
/// - policy gating
/// - store plan JSON as ObjectStore object (canonical)
/// - stage -> verify -> commit
/// - append-only events with sha256 refs
/// </summary>
public interface ILoadOrchestrator
{
    Task<LoadOperationOutcome> PlanAsync(LoadOperationRequest op, CancellationToken ct);
    Task<LoadOperationOutcome> StageAsync(LoadOperationRequest op, CancellationToken ct);
    Task<LoadOperationOutcome> VerifyAsync(LoadOperationRequest op, CancellationToken ct);
    Task<LoadOperationOutcome> CommitAsync(LoadOperationRequest op, CancellationToken ct);
    Task<LoadOperationOutcome> RollbackAsync(LoadOperationRequest op, CancellationToken ct);
}

public sealed record LoadOperationRequest(
    OperationContext Context,
    string TargetMountId,

    /// <summary>
    /// Raw JSON plan that MUST validate against specs/load_plan.schema.json.
    /// Canonical: orchestrator MUST store this JSON in ObjectStore and use that object as the plan identity.
    /// </summary>
    string LoadPlanJson,

    IReadOnlyList<string> RequestedCapabilities,
    IReadOnlyDictionary<string, object>? Attributes
);

public sealed record LoadOperationOutcome(
    LoadPlanRef Plan,
    PolicyDecision PolicyDecision,
    EventRecord Event
);
