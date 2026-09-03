# Changelog

Format inspired by [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).
This file serves the repository and the writing of Steam patch notes; RimWorld does not display
it in game.

## [1.0.0] — unreleased

On release: create the `v1.0.0` tag and the matching GitHub release.

First release of the 1.6 update. The mod's own logic is unchanged from MoFish's 1.5 version.

### Added

- Support for RimWorld 1.6. The assembly is rebuilt against 1.6 and every def reference was
  checked against the 1.6 game files.
- Harmony declared as a mod dependency. The original called into Harmony without listing it, so
  it failed to load with no useful message on a setup without Harmony.
- `incompatibleWith` on the original `MF.UltimateInsult.V01`, so the two cannot be run together.

### Removed

- The copy of `UnityEngine.CoreModule.dll` the original shipped next to its assembly. It is one
  of the game's own libraries.
- The Visual Studio `.vs/` folder, published by mistake in the original.
- The `1.4/` and `1.5/` version folders and `LoadFolders.xml`: this build targets 1.6 only.

### Notes

Defects inherited from the original are left in place on purpose and documented in
`ATTRIBUTION.md`.
