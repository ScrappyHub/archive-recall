# Mount & Load Engine

## Principle
"If it mounts, we can load it" means:
- targets are handled through mount providers
- load operations are transactional

## Mount Provider interface (conceptual)
- Identify()
- Capabilities()
- List()
- Read()
- Write() (if allowed)
- Snapshot() / Checkpoint() (if supported)
- RestoreCheckpoint() (if supported)

## Load pipeline
1) Discover target mount + capabilities
2) Create load plan (paths, transforms, rename rules)
3) Stage writes
4) Verify hashes + structure
5) Commit
6) Emit events + update health
