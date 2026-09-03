# The Ultimate Insult 1.6 — attribution

Update to RimWorld 1.6 of **终极侮辱 - The Ultimate Insult**
(https://steamcommunity.com/sharedfiles/filedetails/?id=2982576556), by **MoFish**.
The original stays on 1.5.

Original `packageId`: `MF.UltimateInsult.V01`.

**The whole design and the whole code are MoFish's.** This repository adds no feature.

## Licence

**No licence is declared**: there is no `LICENSE` file in the mod, and the Steam description is
a single line. The mod is republished under the usual practice for abandoned mods — explicit
credit, a link to the original, and removal on request. That is stated in the mod's own
description, not only here.

If MoFish asks for this to be taken down, it comes down.

## What was taken

The nine def files (ritual, precept, pattern, behaviour, outcomes, attachable outcome, thoughts,
interaction, and the two props), the two prop textures, the Simplified Chinese translations, and
four classes: `Mod_UltimateInsult`, `ModSettings_UltimateInsult`,
`RitualOutcomeEffectWorker_Channeling_UInsult` and
`RitualAttachableOutcomeEffectWorker_UInsult_ResistanceReduce`.

**Where the C# came from.** The mod ships its own sources, in `Source/PartyHard/`. They were not
used as-is: they are 1.4-era and no longer match the assembly actually shipped. Their signatures
still take `OutcomeChance`, the type RimWorld renamed to `RitualOutcomePossibility`, so they do
not describe the `1.5/Assemblies/UltimateInsult.dll` the update had to start from. The four
classes were therefore decompiled from that 1.5 assembly, with the shipped sources read alongside
as a cross-check on naming and intent — which is where the original field names and the
`Settings` alias come from.

**The `MFRitual` namespace and the `UltimateInsult` assembly name are kept**: the defs point at
`MFRitual.*`, and the settings are stored under the `Mod` class name. Only the display name and
the `packageId` change.

The defs live at the root in MoFish's layout — only the assemblies were sorted into version
folders — which is why there is no version folder here and no `LoadFolders.xml`.

## What 1.6 required

**Nothing in the code.** The assembly compiles unchanged against `Krafs.Rimworld.Ref` 1.6: not one
API it uses has moved. Every def reference was cross-checked against the 1.6 game files — rituals,
precepts, patterns, behaviours, outcomes, thoughts, interactions: all of them resolve.

## Two problems fixed around the mod

- **Harmony was not declared as a dependency.** `Mod_UltimateInsult` calls
  `new Harmony(...).PatchAll()` from its constructor all the same. RimWorld does not ship Harmony
  (checked: no `0Harmony.dll` in `RimWorldWin64_Data/Managed`), so on an install without the
  Harmony mod this one failed to load with no useful message. The dependency is now declared.
  Note that this `PatchAll()` does nothing — the assembly contains no patch class. It was kept
  as-is rather than removed, so that this stays an update.
- **The mod shipped a copy of `UnityEngine.CoreModule.dll`** next to its own assembly, in `1.4/`
  as well as `1.5/`. That is one of the game's own libraries: it has no business travelling with
  a mod and can confuse loading. It was left out. The Visual Studio `.vs/` folder, also published
  by mistake, was left out too.

## Original defects left as they are

So that this stays an update and not a rewrite:

- **The failed outcome amputates anyway.** On anything but the best outcome the prisoner loses an
  arm and has their will zeroed exactly as on a success; only the resistance drop is smaller.
  Failure is therefore barely less rewarding than success.
- **`guest.resistance -= 0.5f` is not clamped**: resistance can go negative.
- **`RitualOutcomeEffectWorker_Channeling_UInsult.ApplyExtraOutcome` is gated on
  `ModsConfig.RoyaltyActive`**, although resistance and will are not Royalty features. Without
  Royalty installed, that worker does nothing. The ritual still works, because the visible effect
  comes from the attachable outcome worker, which is not gated.
- **Two messages are hardcoded in English** in the code ("Prisoner resistance reduced to 0.",
  "Prisoner resistance reduced a lot.") instead of going through a translation key: they stay in
  English whatever the game's language.
