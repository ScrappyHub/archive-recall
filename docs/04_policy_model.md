# Policy Model

Archive Recall executes actions only under an explicit policy decision.

## Canonical policy layers
1) Canonical Policy (built-in)
   - Defines minimum safety, legality, and determinism requirements

2) Overlay Policies (user/admin)
   - Add constraints
   - Never weaken canonical policy
   - May restrict importers/transformers/capabilities

## Policy decisions
Every requested operation is evaluated as:
- ALLOW with constraints (capabilities, target scopes, transformer allowlist)
- DENY with reason code

Policy evaluation should be compatible with Covenant Gate's deny/allow interface.
