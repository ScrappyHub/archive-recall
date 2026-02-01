# Architecture

## Primary subsystems
1) Library Store
   - Content-addressed objects keyed by SHA-256
   - Optional tree objects for folders (Merkle model)
   - Deduplication by hash

2) Index
   - Database mapping objects, trees, collections, devices, mounts, and relationships
   - Maintains provenance (observed-from metadata)

3) Event Journal
   - Append-only event records
   - Each event references inputs, outputs, actor, transformer manifest (if applicable), and verification results
   - Events are sealable

4) Transformer Registry
   - Approved transformer manifests (name, version, schema, determinism policy)
   - Parameter validation and capability declarations
   - Output constraints + rollback requirements

5) Mount & Load Engine
   - Mount providers normalize devices/targets into a common interface
   - Load plans are staged, verified, then committed
   - Rollback supported via checkpoints

6) Integrity & Health Engine
   - Periodic/triggered verification
   - Health statuses: CLEAN, NEEDS_ATTENTION, MAINTENANCE_REQUIRED, QUARANTINED, UNSUPPORTED

## Boundary principle
All writes happen through a transactional plan:
- Stage -> Verify -> Commit
No direct "write and hope."
