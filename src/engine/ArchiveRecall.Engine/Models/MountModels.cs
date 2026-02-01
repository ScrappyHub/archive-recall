namespace ArchiveRecall.Engine.Models;

public sealed record MountDescriptor(
    string MountId,
    string DisplayName,
    string FilesystemType,
    bool Readable,
    bool Writable,
    long? TotalBytes,
    long? FreeBytes,
    IReadOnlyDictionary<string, string>? ProviderDetails
);

public sealed record MountPath(string Path);
