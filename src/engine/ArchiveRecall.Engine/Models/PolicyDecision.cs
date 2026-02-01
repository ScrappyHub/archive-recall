namespace ArchiveRecall.Engine.Models;

public sealed record PolicyDecision(
    string Decision,            // "ALLOW" | "DENY"
    string PolicyId,
    IReadOnlyList<string> ReasonCodes,
    IReadOnlyList<string> GrantedCapabilities // empty if DENY
);
