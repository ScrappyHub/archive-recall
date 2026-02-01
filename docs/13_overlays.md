# Overlays (Canonical)

## Definition
An Overlay is an external library representation imported into Archive Recall as a canonical artifact.

Examples:
- Spotify playlists/collections as metadata + references (no DRM bypass).
- YouTube playlists/subscriptions/history as metadata + references (no protected downloads).
- Any future provider that exports library state in a lawful, documented way.

Overlays are NOT files of the underlying media content unless the user provides lawful, DRM-free files separately.

## Canonical requirements
- Every overlay must be represented as an Overlay Manifest that:
  - validates against `specs/overlay.schema.json`
  - is stored as an object in the library store (sha256 identity)
  - emits events for ingest/update (append-only)
- Overlays are replayable:
  - same provider export + same importer + same params => identical Overlay Manifest hash
  - if provider data changes, new manifest is ingested and linked by events

## Overlay lifecycle events
- OVERLAY_DISCOVERED
- OVERLAY_INGESTED
- OVERLAY_UPDATED
- OVERLAY_VERIFIED
- OVERLAY_REJECTED (policy/schema failure)
- OVERLAY_QUARANTINED (if policy requires isolation)

## Policy integration
Overlay ingestion is allowed only if:
- importer is approved
- overlay manifest validates
- policy allows the provider and declared data domains
- network capability is explicitly allowed (often denied by default)

## Mapping overlays into the library
Overlays may create:
- Collections (e.g., playlist as a collection manifest)
- References (provider IDs/URLs)
- Desired acquisition tasks (optional) that do NOT auto-download protected media

Overlays never weaken canonical constraints.
