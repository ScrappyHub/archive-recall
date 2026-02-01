namespace ArchiveRecall.Engine.Contracts;

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

    ISnapshotOrchestrator SnapshotOps { get; }
    ILoadOrchestrator LoadOps { get; }
    IOverlayOrchestrator OverlayOps { get; }
    IFolderPolicyOrchestrator FolderPolicyOps { get; }
    IQuarantineManager Quarantine { get; }
    IHealthEngine Health { get; }
    IReplayVerifier Replay { get; }
}
