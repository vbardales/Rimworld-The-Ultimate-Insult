# The Ultimate Insult 1.6

Update of MoFish's **终极侮辱 - The Ultimate Insult** to RimWorld 1.6.

**I am not the author of this mod.** The idea, the design and the original code are entirely
MoFish's — all I did was the work needed to make it run on 1.6. Credit goes to them; mistakes in
the update are mine.

Original mod: https://steamcommunity.com/sharedfiles/filedetails/?id=2982576556 (stays on 1.5)

## What the mod does

It adds an Ideology ritual, the **Ultimate Insult**, performed on a prisoner to break their
resistance — or simply to destroy what is left of their dignity.

A speaker gives an awakening speech over a bound prisoner while the colony watches. On the best
outcome the prisoner's resistance drops to zero; on a lesser one it falls sharply. Either way the
prisoner loses an arm. A mod setting decides whether their will is broken as well.

It also adds the two ritual props the ceremony is held around: a large durian and a pair of
Sea Tiger blasting pliers.

Requires **Ideology**. Requires **Harmony**.

Available in English, Simplified Chinese (MoFish's own) and French.

Safe to add to an ongoing save. Removing it mid-save removes the ritual and its two props.

## What changed in the 1.6 update

Nothing in the mod's own logic. Every API it uses still exists in 1.6, so the assembly was rebuilt
against 1.6 unchanged, and every def reference was checked against the 1.6 game files — rituals,
precepts, patterns, outcomes, thoughts and interactions all still resolve.

Two things were fixed around the mod rather than in it:

- **Harmony is now declared as a dependency.** The original called into Harmony from its `Mod`
  constructor without listing it, so on a setup without Harmony the mod failed to load with no
  useful message. RimWorld does not ship Harmony itself.
- **The copy of `UnityEngine.CoreModule.dll` was dropped.** The original shipped one of the game's
  own libraries next to its assembly; that should never travel with a mod.

One thing was fixed inside it: the settings window used to scroll. Its single checkbox sat in a
scroll view whose content was always taller than the window, so a scrollbar showed permanently
for one option.

Known defects inherited from the original are listed in [ATTRIBUTION.md](ATTRIBUTION.md), left in
place on purpose so this stays an update rather than a rewrite.

## Terms

The original mod declares no licence. This update is published under the usual practice for
abandoned mods: **explicit credit to MoFish, a link to the original, and removal on request.**
If MoFish comes back to the mod, or asks for this to be taken down, it comes down.

If I do not answer within a reasonable time after being contacted, anyone may freely update this
or any other of my mods, including publishing a continuation of it. All credit must be preserved.

## Building

```
dotnet build Source/UltimateInsult.csproj -c Release
```

Reference assemblies come from NuGet (`Krafs.Rimworld.Ref`), so no RimWorld install is needed to
compile. The output goes to `Assemblies/`; build intermediates are kept out of the mod folder by
`Source/Directory.Build.props`, because the Workshop uploader publishes the mod folder as-is with
no way to exclude anything.

## Credits

- **MoFish** — the mod itself, in full.
- Andreas Pardeike, for Harmony.
- 1.6 update by nelim. Written with the help of Claude (Anthropic).
