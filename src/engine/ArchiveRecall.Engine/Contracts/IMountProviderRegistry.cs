namespace ArchiveRecall.Engine.Contracts;

public interface IMountProviderRegistry
{
    Task<IMountProvider?> GetByIdAsync(string providerId, CancellationToken ct);
    Task<IReadOnlyList<IMountProvider>> ListAsync(CancellationToken ct);
}
