# VM Snapshots (Capability)

## Why
Archive Recall must support VM snapshots so Clarity can be tested against:
- deterministic restore operations
- repeatable environment recreation
- sealed, auditable state rollbacks

VM snapshots are treated as:
- a first-class "Checkpoint Provider" type
- producing sealable snapshot artifacts
- referenced by events

## Snapshot model
Snapshot operations are transactional and journaled.

Supported snapshot types (conceptual):
- Hypervisor snapshot (VM-level)
- Disk image snapshot (volume-level)
- File-level checkpoint (library-level)

Snapshot providers are pluggable:
- each provider declares capabilities and constraints
- each snapshot result produces a canonical record

## Canonical requirements
- Snapshot requests and results must validate against schema:
  - `specs/vm_snapshot_provider.schema.json`
- Snapshot results must include:
  - stable snapshot ID (provider scope)
  - time
  - target identifiers
  - integrity signals (if provider can supply)
  - optional exported artifact hashes if snapshot is materialized as a file

## Events
- SNAPSHOT_REQUESTED
- SNAPSHOT_CREATED
- SNAPSHOT_RESTORED
- SNAPSHOT_FAILED
- SNAPSHOT_EXPORTED (optional, if materialized into an archive file)

## Safety
Snapshots may be denied by policy:
- if provider requires forbidden capabilities
- if target identifiers are out of allowed scope
