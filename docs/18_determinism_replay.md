# Determinism & Replay

## Deterministic claims
Archive Recall must be able to prove:
- what inputs produced what outputs
- under what transformer/importer versions
- with what parameters
- and whether a replay is expected to match

## Determinism classes
- D0: Pure deterministic (hash-stable outputs)
- D1: Deterministic given external fixed dataset (e.g., provider export file pinned)
- D2: Non-deterministic (explicitly labeled; heavily restricted)

## Replay contract
A replay is valid when:
- same input object hashes
- same transformer/importer manifest hash (or version + binary hash)
- same params
- same policy constraints
- same deterministic class expectation

If replay differs, Archive Recall must:
- emit REPLAY_MISMATCH event
- record the differing output hashes
- provide reason codes where possible
