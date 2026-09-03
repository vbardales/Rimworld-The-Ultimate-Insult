using HarmonyLib;
using UnityEngine;
using Verse;

namespace MFRitual;

public class Mod_UltimateInsult : Mod
{
	public Mod_UltimateInsult(ModContentPack content)
		: base(content)
	{
		// This PatchAll patches nothing: the assembly contains no patch class. Kept as-is
		// rather than removed, so that this stays an update.
		new Harmony(base.Content.PackageIdPlayerFacing).PatchAll();
		GetSettings<ModSettings_UltimateInsult>();
	}

	public override void DoSettingsWindowContents(Rect inRect)
	{
		// The original wrapped this single checkbox in a Widgets.BeginScrollView whose content
		// rect was inRect.height * 1.2f: always taller than the window holding it, so the
		// scrollbar showed permanently for one option. Removed.
		inRect.yMin += 20f;
		inRect.yMax -= 20f;
		Listing_Standard listing_Standard = new Listing_Standard();
		listing_Standard.Begin(inRect);
		listing_Standard.CheckboxLabeled("MF.reducewill".Translate(), ref ModSettings_UltimateInsult.reducewill, "MF.reducewill.Desc".Translate());
		listing_Standard.End();
	}

	public override string SettingsCategory()
	{
		return "Ultimate Insult";
	}
}
