using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Computes event_hash deterministically from a canonical serialization.
/// Implementations must define a canonical JSON serialization form and hash it with SHA-256.
/// </summary>
public interface IEventHasher
{
    Sha256 ComputeHash(EventRecord evt);
}
