using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Sealer can produce session seal artifacts from journal hash chains.
/// Clarity can later own/verify these seals.
/// </summary>
public interface ISealer
{
    Task<SealArtifact> SealAsync(SealRequest request, CancellationToken ct);
}

public sealed record SealRequest(
    string SealId,
    Sha256 HeadEventHash,
    DateTimeOffset SealedAtUtc,
    IReadOnlyDictionary<string, string>? Notes
);

public sealed record SealArtifact(
    string SealId,
    ObjectRef ArtifactObject,
    Sha256 HeadEventHash
);
