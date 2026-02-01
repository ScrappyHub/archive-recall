# Quarantine & Isolation

## Purpose
Some content must be isolated to protect:
- the library integrity
- the target device
- the user’s policy expectations

Isolation is not moral judgment; it's operational safety.

## Quarantine states
- QUARANTINED: content exists but is restricted from transforms/loads
- ISOLATED: content moved/copied into a dedicated isolation store, separate from normal library browsing
- REJECTED: content not ingested (event still recorded with reason)

## Canonical invariants
- Isolation/quarantine actions emit events
- Quarantine state changes are append-only (corrections are new events)
- Quarantined items can be re-reviewed and released by policy-approved operation

## Typical triggers
- policy disallowed file types in a folder policy scope
- failed integrity check
- unknown type where policy requires known types
- suspected harmful content (optional integrations)

## Rollback
If isolation involved a move/write:
- it must be staged + verified
- a rollback path must exist (restore prior tree state)
