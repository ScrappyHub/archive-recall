# Event Journal

## Rule
Events are append-only. No edits. Corrections are new events.

## Event types (initial)
- IMPORT_DISCOVERED
- IMPORT_INGESTED
- TRANSFORM_APPLIED
- LOAD_PLANNED
- LOAD_STAGED
- LOAD_COMMITTED
- VERIFY_PASSED
- VERIFY_FAILED
- HEALTH_STATUS_CHANGED
- CHECKPOINT_CREATED
- ROLLBACK_RESTORED
- QUARANTINE_SET
- QUARANTINE_CLEARED

## Sealing
Events may be sealed into a hash chain:
- each event references prior_event_hash
- seal artifacts can be produced per session

## Snapshot event payloads (Canonical)
Snapshot operations MUST:
- store snapshot request JSON as library objects (sha256 identity)
- store snapshot result JSON as library objects (sha256 identity)
- reference them in Event inputs/outputs with sha256 set

Exported snapshot artifact hashes are optional:
- if an export artifact is materialized, it MUST be stored as a library object and may be referenced in outputs.

