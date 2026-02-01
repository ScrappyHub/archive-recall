# Archive Recall

Archive Recall is a canonical library preservation + deterministic restore system.

It provides:
- Content-addressed library storage (SHA-256 identity)
- Integrity verification and health classification
- Append-only action journal (canonical recall of all operations)
- Approved, versioned transformers (deterministic + replayable)
- Transactional load pipelines ("if it mounts, we can load it")
- Lawful importers (metadata-first; no DRM bypass)

Archive Recall is designed to be:
- Ethical (consumer-safe, non-hacker framing)
- Deterministic (replayable outcomes)
- Auditable (sealed event history)
- Reversible (rollback/restore checkpoints)
- Policy-governed (overlay restrictions compatible with Covenant Gate)

## Canonical documents
See `docs/00_canonical_definition.md` for the locked definition and invariants.

## Status
Early canonical/spec phase. Implementations will be added only after the spec surfaces are stable.
