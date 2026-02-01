# Folder Policies (Allowed Types, Transform, Isolate)

## Goal
Users can select a folder and declare:
- what data types are allowed inside
- how files should be structured/named
- what transforms are permitted
- what happens to disallowed or suspicious content (reject vs quarantine vs isolate)

Folder policies are canonical artifacts:
- validated by schema (`specs/folder_policy.schema.json`)
- stored with sha256 identity
- enforced via events and load/transform plans

## Definitions
- Data Type: a declared category (music, image, rom, save, document, video, software, archive, unknown)
- Allowed Rule: a rule that matches files by extension, mime signal, and/or detector signature
- Enforcement Mode:
  - WARN: allow but mark NEEDS_ATTENTION
  - BLOCK: reject operation
  - ISOLATE: move/copy into isolation/quarantine area (policy-defined)
  - TRANSFORM: run approved transformer(s) to convert/normalize

## Canonical enforcement points
Folder policies must be enforced in:
- Import (ingest)
- Transform
- Load (writes)
- Maintenance scans

## Path handling (no footguns)
Folder policy paths must be:
- explicit
- normalized
- never dependent on environment variables unless policy explicitly declares them

The system may store a "follow path" pointer for the UI, but identity is never the path:
- identity remains sha256 (object) and tree_hash (folder)
- paths are metadata for user navigation only

## Example use-cases
- "This folder is MUSIC only (mp3/flac/wav). Anything else isolates."
- "This folder is ROMS + SAVES only; zips allowed; unknown isolates."
- "This folder is PHOTOS; allow jpg/png/tiff; normalize names; quarantine unknown."
