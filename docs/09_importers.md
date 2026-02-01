# Importers (Lawful)

## Rule
Importers may ingest:
- metadata
- library organization (playlists, collections)
- references/links/IDs
- user-exported archives

Importers must not:
- bypass DRM
- download protected streams
- defeat platform protections

## Examples
- Spotify: import playlists as collection manifests (metadata + references)
- YouTube: import playlist metadata + links via official APIs/exports

If the user provides a lawful, DRM-free file, ingestion proceeds through standard import + hashing.
