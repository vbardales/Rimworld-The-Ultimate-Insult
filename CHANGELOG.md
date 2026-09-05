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
- A French translation, 59 keys, covering everything the mod displays. The one key that targets a
  `MayRequire="Ludeon.RimWorld.Royalty"` field lives in a `Royalty/` folder, loaded through a new
  `LoadFolders.xml` only when the DLC is active.

### Fixed

- The settings window no longer scrolls. Its single checkbox was wrapped in a scroll view whose
  content was always taller than the window, so a scrollbar showed permanently for one option.
- The Simplified Chinese translation now actually reaches the player. No Chinese text was changed:
  eight files were duplicated where RimWorld does not look, three more held untranslated English
  that collided with the real Chinese for the ritual roles and all four outcomes, eight thought
  keys were addressed by list index instead of by stage handle, and two more aimed at fields that
  do not exist. See `ATTRIBUTION.md` for the detail.


### Removed

- The copy of `UnityEngine.CoreModule.dll` the original shipped next to its assembly. It is one
  of the game's own libraries.
- The Visual Studio `.vs/` folder, published by mistake in the original.
- The `1.4/` and `1.5/` version folders and the `LoadFolders.xml` that served them: this build
  targets 1.6 only. A new `LoadFolders.xml` was added for a different reason, listed above.

### Notes

Defects inherited from the original are left in place on purpose and documented in
`ATTRIBUTION.md`.
