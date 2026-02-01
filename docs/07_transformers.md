# Transformers

## Definition
A Transformer is an approved, versioned operation that produces outputs from inputs under validated parameters.

## Requirements
- Manifest is immutable once approved (name + version)
- Parameters validated against schema
- Capability declarations are explicit (filesystem read/write, network, device access)
- Determinism declared and enforced:
  - deterministic: same inputs + params => same outputs (hashes)
  - non-deterministic transformers must be explicitly labeled and constrained by policy

## Rollback
Transformers that modify targets must supply a rollback strategy:
- staged outputs + commit
- or checkpoint + restore
