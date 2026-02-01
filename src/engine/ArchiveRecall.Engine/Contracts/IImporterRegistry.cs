using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Approved importer registry. Importers produce canonical overlay manifests and/or objects.
/// </summary>
public interface IImporterRegistry
{
    Task<ImporterManifestRef?> GetAsync(string name, string version, CancellationToken ct);
    Task<IReadOnlyList<ImporterManifestRef>> ListAsync(CancellationToken ct);
}

public sealed record ImporterManifestRef(
    string Name,
    string Version,
    Sha256 ManifestSha256,
    Sha256? BinarySha256,
    string ProviderKind,
    string DeterminismClass
);
