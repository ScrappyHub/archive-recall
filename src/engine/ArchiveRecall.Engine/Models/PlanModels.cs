namespace ArchiveRecall.Engine.Models;

/// <summary>
/// Load plan is a canonical JSON artifact validated against specs/load_plan.schema.json.
/// Recommended canonical storage: store as object in library store and reference by sha256 in events.
/// </summary>
public sealed record LoadPlanRef(
    string PlanId,
    ObjectRef? StoredObject // optional: present when stored as object (recommended canonical)
);

public sealed record CheckpointRef(
    string CheckpointId,
    ObjectRef? StoredObject // optional: if represented as canonical object
);
