# Archive Recall — Canonical Definition (Locked)

## Name
Archive Recall

## Definition
Archive Recall is a canonical library preservation and deterministic restore system that:
1) archives user assets and device backups with cryptographic identity (SHA-256),
2) records every operation as an append-only event journal,
3) enables deterministic replay of approved transformations,
4) loads/restores assets onto any mounted target through reversible, transactional pipelines,
5) classifies library health and integrity without ambiguity.

## Non-negotiable invariants
- Every library object has a stable cryptographic identity (SHA-256).
- Folder identity is representable as a deterministic tree hash (Merkle model).
- All actions are recorded as append-only events (no history rewrites).
- Transformers are approved, versioned, and validated against schemas.
- Every load/restore is staged + verified before commit (transactional).
- Rollback/restore states are first-class (no "best effort" restores).
- Importers must not bypass DRM or violate platform terms; metadata and references are allowed.

## Promise
"If it mounts, we can load it" — provided the requested action is allowed by policy and the target mount provider supports the required capability.

## Compatibility
Archive Recall is designed to integrate with:
- Clarity (sealed artifacts/logs, validation authority)
- Covenant Gate (policy overlays and allow/deny decisions)
- Atlas Artifact (artifact execution/update control where appropriate)
- Legacy Doctor (device interaction and mount paths)
- Rebound (verified communications of manifests/logs when needed)
