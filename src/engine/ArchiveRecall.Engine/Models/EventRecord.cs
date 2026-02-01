namespace ArchiveRecall.Engine.Models;

/// <summary>
/// Canonical event record representation (contract-level).
/// Implementations MUST serialize/validate against specs/event_record.schema.json.
/// </summary>
public sealed record EventRecord(
    string SchemaVersion,         // "v1"
    string EventId,
    string EventType,
    DateTimeOffset OccurredAtUtc,

    EventActor Actor,

    IReadOnlyList<EventRef> Inputs,
    IReadOnlyList<EventRef> Outputs,

    PolicyDecision Policy,

    IReadOnlyList<string> Capabilities,

    EventIntegrity Integrity,

    Sha256 PrevEventHash,
    Sha256 EventHash,

    IReadOnlyDictionary<string, object>? Details
);

public sealed record EventActor(
    string Kind,   // "user" | "automation" | "system"
    string Id,
    string? Display
);

public sealed record EventRef(
    string Kind,   // "object" | "tree" | "overlay" | "policy" | "plan" | "snapshot" | "mount" | "health_report"
    string Id,
    Sha256? Sha256
);

public sealed record EventIntegrity(
    string DeterminismClass,  // "D0" | "D1" | "D2"
    bool ExpectedReplay,
    EventVerification Verification
);

public sealed record EventVerification(
    bool HashesVerified,
    bool StructureVerified,
    IReadOnlyDictionary<string, object>? MismatchDetails
);
