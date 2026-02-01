using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Health engine produces canonical health reports.
/// Canonical: reports SHOULD be stored as ObjectStore objects (sha256 identity) for sealing/replay.
/// </summary>
public interface IHealthEngine
{
    Task<HealthOutcome> ScanAsync(HealthScanRequest req, CancellationToken ct);
}

public sealed record HealthScanRequest(
    OperationContext Context,
    IReadOnlyList<Sha256> Targets,
    IReadOnlyList<string> RequestedCapabilities,
    IReadOnlyDictionary<string, object>? Attributes
);

public sealed record HealthOutcome(
    ObjectRef HealthReportObject,
    PolicyDecision PolicyDecision,
    EventRecord Event
);
