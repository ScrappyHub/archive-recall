namespace ArchiveRecall.Engine.Models;

public sealed record ObjectRef(
    string ObjectId,
    Sha256 Sha256
);
