using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Quarantine/isolation manager.
/// Canonical: quarantine changes MUST emit events; no silent state flips.
/// </summary>
public interface IQuarantineManager
{
    Task<QuarantineOutcome> QuarantineAsync(QuarantineRequest req, CancellationToken ct);
    Task<QuarantineOutcome> ReleaseAsync(QuarantineReleaseRequest req, CancellationToken ct);
}

public sealed record QuarantineRequest(
    OperationContext Context,
    Sha256 TargetSha256,
    string ReasonCode,
    IReadOnlyList<string> RequestedCapabilities,
    IReadOnlyDictionary<string, object>? Attributes
);

public sealed record QuarantineReleaseRequest(
    OperationContext Context,
    Sha256 TargetSha256,
    string ReasonCode,
    IReadOnlyList<string> RequestedCapabilities,
    IReadOnlyDictionary<string, object>? Attributes
);

public sealed record QuarantineOutcome(
    PolicyDecision PolicyDecision,
    EventRecord Event
);
