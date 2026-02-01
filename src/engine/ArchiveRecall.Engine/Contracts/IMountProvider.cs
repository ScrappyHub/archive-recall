using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Mount provider normalizes a mounted target into a stable interface.
/// "If it mounts, we can load it" is built on these providers.
/// </summary>
public interface IMountProvider
{
    string ProviderId { get; }
    string ProviderKind { get; } // e.g. "filesystem", "ipod", "mtp", etc.

    Task<IReadOnlyList<MountDescriptor>> ListMountsAsync(CancellationToken ct);

    Task<MountDescriptor> DescribeAsync(string mountId, CancellationToken ct);

    Task<IReadOnlyList<MountPath>> ListAsync(string mountId, string path, CancellationToken ct);

    Task<Stream> OpenReadAsync(string mountId, string path, CancellationToken ct);

    /// <summary>
    /// Writes must be used only by staged/verified load flows.
    /// Provider implementations may enforce write scopes.
    /// </summary>
    Task WriteAsync(string mountId, string path, Stream content, CancellationToken ct);

    Task DeleteAsync(string mountId, string path, CancellationToken ct);
}
