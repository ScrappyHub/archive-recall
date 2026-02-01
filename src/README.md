# Source (Reserved)

Implementation will be added after the contract surfaces in `specs/` are stable.

Rules:
- All operations must emit Event Records conforming to `specs/event_record.schema.json`.
- All manifests/plans must validate against schema before execution.
- No writes without staged -> verify -> commit.
- No plugins without declared capabilities and binary hash identity.
