namespace ArchiveRecall.Engine.Contracts;

/// <summary>
/// Composition root contract. This is what GOS can host later.
/// The Host exposes core services and provider registries.
/// </summary>
public interface IArchiveRecallEngineHost
{
    IJournal Journal { get; }
    IPolicyGate Policy { get; }
    IObjectStore Objects { get; }
    IIndexStore Index { get; }
    ISchemaValidator Schemas { get; }
    ISealer Sealer { get; }

    ISnapshotProviderRegistry Snapshots { get; }
    IMountProviderRegistry Mounts { get; }

    ITransformerRegistry Transformers { get; }
    IImporterRegistry Importers { get; }
}
