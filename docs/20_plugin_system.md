# Plugin System (Canonical)

Archive Recall is designed to integrate into GOS as a plugin, without changing the core contract.

## Rule
Core engine is standalone and headless.
Plugins add providers and surfaces, not new semantics.

## Plugin types
- Importer Plugin: produces overlay manifests and/or ingests user export objects
- Transformer Plugin: applies approved transforms
- Mount Provider Plugin: normalizes mounted targets
- Snapshot Provider Plugin: VM snapshot/create/restore/export
- Health Signal Plugin: computes extra integrity/maintenance signals

## Plugin boundary
Plugins MUST:
- declare capabilities
- be versioned
- be hash-identifiable (binary hash)
- validate all outputs against schemas
- emit events via the core journal API

Plugins MUST NOT:
- directly mutate index state outside journaled operations
- bypass staging/verification on writes
- bypass policy gating
