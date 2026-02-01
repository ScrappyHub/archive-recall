using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Replay verification contract.
/// Used to prove whether a replay is expected to match and to emit REPLAY_MISMATCH events when it doesn't.
/// </summary>
public interface IReplayVerifier
{
    Task<ReplayOutcome> VerifyAsync(ReplayRequest req, CancellationToken ct);
}

public sealed record ReplayRequest(
    OperationContext Context,
    Sha256 InputSha256,
    string TransformerName,
    string TransformerVersion,
    IReadOnlyDictionary<string, object> Parameters,
    IReadOnlyList<string> RequestedCapabilities,
    IReadOnlyDictionary<string, object>? Attributes
);

public sealed record ReplayOutcome(
    bool ExpectedMatch,
    bool ObservedMatch,
    PolicyDecision PolicyDecision,
    EventRecord Event
);
