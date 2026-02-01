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
