using HarmonyLib;
using UnityEngine;
using Verse;

namespace MFRitual;

public class Mod_UltimateInsult : Mod
{
	public Mod_UltimateInsult(ModContentPack content)
		: base(content)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		new Harmony(base.Content.PackageIdPlayerFacing).PatchAll();
		GetSettings<ModSettings_UltimateInsult>();
	}

	public override void DoSettingsWindowContents(Rect inRect)
	{
		inRect.yMin += 20f;
		inRect.yMax -= 20f;
		Listing_Standard listing_Standard = new Listing_Standard();
		Rect outRect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
		Rect rect = new Rect(0f, 0f, inRect.width - 30f, inRect.height * 1.2f);
		Widgets.BeginScrollView(outRect, ref ModSettings_UltimateInsult.scrollPos, rect);
		listing_Standard.Begin(rect);
		listing_Standard.CheckboxLabeled("MF.reducewill".Translate(), ref ModSettings_UltimateInsult.reducewill, "MF.reducewill.Desc".Translate());
		listing_Standard.End();
		Widgets.EndScrollView();
	}

	public override string SettingsCategory()
	{
		return "Ultimate Insult";
	}

	public override void WriteSettings()
	{
		base.WriteSettings();
	}
}
