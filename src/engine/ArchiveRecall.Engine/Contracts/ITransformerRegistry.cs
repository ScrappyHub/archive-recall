using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Approved transformer registry. Manifests are canonical artifacts (sha256 identity).
/// </summary>
public interface ITransformerRegistry
{
    Task<TransformerManifestRef?> GetAsync(string name, string version, CancellationToken ct);
    Task<IReadOnlyList<TransformerManifestRef>> ListAsync(CancellationToken ct);
}

public sealed record TransformerManifestRef(
    string Name,
    string Version,
    Sha256 ManifestSha256,
    Sha256? BinarySha256,
    string DeterminismClass
);
