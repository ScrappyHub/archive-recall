# Integrity & Health Model

## Health statuses
- CLEAN
- NEEDS_ATTENTION
- MAINTENANCE_REQUIRED
- QUARANTINED (optional)
- UNSUPPORTED

## Signals
- Hash verification mismatch
- Read errors / partial copies
- Missing required metadata per policy
- Unsupported formats for a requested operation
- Suspicious/unknown provenance flags (policy-defined)

Health is computed and changes emit HEALTH_STATUS_CHANGED events.
