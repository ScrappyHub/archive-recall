namespace ArchiveRecall.Engine.Contracts;

public interface ISnapshotProviderRegistry
{
    /// <summary>
    /// Returns a provider by provider_id. Policy decides whether it is usable.
    /// </summary>
    Task<ISnapshotProvider?> GetByIdAsync(string providerId, CancellationToken ct);

    Task<IReadOnlyList<ISnapshotProvider>> ListAsync(CancellationToken ct);
}
