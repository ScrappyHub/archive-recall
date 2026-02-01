# VM Provider Agnosticism (Locked)

Archive Recall treats VM snapshots as a generic checkpoint capability.

## Rule
No Archive Recall contract depends on any single hypervisor vendor.

## How this is enforced
- Snapshot providers are plugins implementing the same capability contract.
- Requests and results validate against canonical schemas.
- Events record snapshot operations identically regardless of provider.
- Policy decides which providers are allowed.

## Consequence
VirtualBox, Hyper-V, and VMware can all be supported without changing:
- the event record schema
- the snapshot request/result schema
- the load/transform contracts
