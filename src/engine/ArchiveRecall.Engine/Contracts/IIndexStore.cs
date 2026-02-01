using ArchiveRecall.Engine.Models;

namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Index: maps objects/trees/collections/devices/mounts.
/// Pure contract-level interface; mutations should be journal-driven in implementations.
/// </summary>
public interface IIndexStore
{
    Task UpsertObjectAsync(ObjectMetadata meta, CancellationToken ct);
    Task<ObjectMetadata?> GetObjectBySha256Async(Sha256 sha256, CancellationToken ct);

    Task UpsertTreeAsync(TreeMetadata meta, CancellationToken ct);
    Task<TreeMetadata?> GetTreeByHashAsync(Sha256 treeHash, CancellationToken ct);

    Task UpsertMountAsync(MountDescriptor mount, CancellationToken ct);
    Task<MountDescriptor?> GetMountAsync(string mountId, CancellationToken ct);
}

public sealed record ObjectMetadata(
    string ObjectId,
    Sha256 Sha256,
    long SizeBytes,
    string? DataType, // music/image/rom/save/video/document/software/archive/unknown
    IReadOnlyDictionary<string, string>? ObservedFrom // device/mount/path metadata
);

public sealed record TreeMetadata(
    string TreeId,
    Sha256 TreeHash,
    IReadOnlyDictionary<string, string>? Notes
);
