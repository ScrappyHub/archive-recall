# Capability Model

Archive Recall actions require explicit capabilities.
Capabilities are evaluated by policy before execution.

## Core capabilities (minimum)
- filesystem.read
- filesystem.write
- device.mount
- device.write
- network.access
- vm.snapshot
- vm.restore
- quarantine.manage

## Rule
No action may execute capabilities it did not declare.

## Where capabilities are declared
- Importer manifest
- Transformer manifest
- Snapshot provider manifest
- Load plan (derived requirement)

## Default posture
- Deny network by default (policy can enable)
- Deny vm.restore by default (high impact)
- Allow filesystem.read in most cases
- Allow filesystem.write only via staged load plans
