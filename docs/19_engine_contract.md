# Engine Contract (Canonical)

This document locks the "contract surface" of Archive Recall.

Implementations MUST conform to:
- JSON schemas in `specs/`
- append-only Event Journal semantics
- deterministic replay semantics
- capability + policy gating semantics
- staged -> verify -> commit semantics for writes
- snapshot provider contract for VM snapshots

## Contract artifacts
- overlay manifests (`specs/overlay.schema.json`)
- folder policies (`specs/folder_policy.schema.json`)
- load plans (`specs/load_plan.schema.json`)
- transformer manifests (`specs/transformer_manifest.schema.json`)
- importer manifests (`specs/importer_manifest.schema.json`)
- snapshot provider manifests (`specs/vm_snapshot_provider.schema.json`)
- event records (`specs/event_record.schema.json`)
- health reports (`specs/health_report.schema.json`)

If an implementation cannot represent an operation as:
- a validated manifest/plan
- and an append-only event stream
then that operation does not exist in Archive Recall.
