namespace ArchiveRecall.Engine.Models;

public readonly record struct Sha256(string Hex)
{
    public override string ToString() => Hex;
}
