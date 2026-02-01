using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Content-addressed store. SHA-256 identity is canonical.
/// </summary>
public interface IObjectStore
{
    /// <summary>
    /// Put bytes and return canonical reference (sha256 identity).
    /// Implementations MUST compute sha256 from content.
    /// </summary>
    Task<ObjectRef> PutAsync(Stream content, CancellationToken ct);

    /// <summary>
    /// Open a read stream for an object by sha256.
    /// </summary>
    Task<Stream> OpenReadAsync(Sha256 sha256, CancellationToken ct);

    /// <summary>
    /// Check existence.
    /// </summary>
    Task<bool> ExistsAsync(Sha256 sha256, CancellationToken ct);
}
