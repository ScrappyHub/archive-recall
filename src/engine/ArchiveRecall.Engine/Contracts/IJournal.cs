using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Append-only event journal.
/// - No edits. Corrections are new events.
/// - Events are hash-chained for sealing.
/// </summary>
public interface IJournal
{
    /// <summary>
    /// Get the latest event hash (head). Returns null if journal is empty.
    /// </summary>
    Task<Sha256?> GetHeadHashAsync(CancellationToken ct);

    /// <summary>
    /// Append an event. Implementation MUST enforce append-only semantics.
    /// Implementation MUST validate that event.PrevEventHash matches current head (or empty journal rules).
    /// </summary>
    Task AppendAsync(EventRecord evt, CancellationToken ct);

    /// <summary>
    /// Read events starting from a given hash (or from beginning if null).
    /// </summary>
    IAsyncEnumerable<EventRecord> ReadAsync(Sha256? fromExclusive, CancellationToken ct);
}
