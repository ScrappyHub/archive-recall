namespace ArchiveRecall.Engine.Models;

public sealed record OperationContext(
    string OperationId,         // stable caller-provided id
    string ActorKind,           // "user" | "automation" | "system"
    string ActorId,
    string? ActorDisplay,
    DateTimeOffset OccurredAtUtc
);
