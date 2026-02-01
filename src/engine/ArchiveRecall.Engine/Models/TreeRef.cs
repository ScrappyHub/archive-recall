namespace ArchiveRecall.Engine.Models;

public sealed record TreeRef(
    string TreeId,
    Sha256 TreeHash
);
