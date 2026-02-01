# Data Model (Conceptual)

## Core entities
- Object
  - object_id (stable internal ID)
  - sha256 (identity)
  - size, type signals, timestamps
  - observed_from (device/mount/path metadata)
  - current_health_status

- Tree
  - tree_id
  - tree_hash (Merkle)
  - entries (object/tree references + names)
  - deterministic ordering rule

- Collection
  - user-defined grouping (albums, libraries, device sets)

- Device
  - stable identifiers (serial where possible), mount history

- Mount
  - mount_id, filesystem type, read/write capability, session metadata

- Event
  - event_id
  - event_type
  - actor
  - inputs[], outputs[]
  - transformer_ref (optional)
  - parameters (validated)
  - verification results
  - event_hash (for sealing)

This document defines the model. Implementation tables come after language/runtime selection.
