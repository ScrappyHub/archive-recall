# Archive Recall — Canonical Policy

## Absolute constraints
- No DRM bypass.
- No platform protection circumvention.
- No hidden network actions.
- No writes without transactional staging + verification.
- No unapproved transformers.

## Required logging
Every operation must emit events sufficient to reproduce:
- inputs (object/tree IDs)
- parameters
- transformer manifest reference (if any)
- outputs (object/tree IDs)
- verification results
