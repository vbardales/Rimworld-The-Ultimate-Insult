using HarmonyLib;
using UnityEngine;
using Verse;

namespace MFRitual;

public class Mod_UltimateInsult : Mod
{
	public Mod_UltimateInsult(ModContentPack content)
		: base(content)
	{
		// Ce PatchAll ne patche rien : l'assemblage ne contient aucune classe de patch.
		// Conserve tel quel plutot que supprime, pour rester une mise a jour.
		new Harmony(base.Content.PackageIdPlayerFacing).PatchAll();
		GetSettings<ModSettings_UltimateInsult>();
	}

	public override void DoSettingsWindowContents(Rect inRect)
	{
		// L'original enveloppait cette unique case dans un Widgets.BeginScrollView dont le
		// contenu faisait inRect.height * 1.2f : toujours plus haut que la fenetre, donc un
		// ascenseur permanent pour une seule option. Retire.
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
