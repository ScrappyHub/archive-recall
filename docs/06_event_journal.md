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

- ## Snapshot event payloads
Snapshot operations MUST reference:
- inputs: snapshot request object sha256 (if stored) or request_id
- outputs: snapshot result object sha256 (if stored) or result_id
- store snapshot request/result JSON as library objects (sha256 identity)
- reference them in Event inputs/outputs with sha256 set

