using UnityEngine;
using Verse;

namespace MFRitual;

public class ModSettings_UltimateInsult : ModSettings
{
	public static bool reducewill = true;

	public static Vector2 scrollPos = Vector2.zero;

	public static float entryScale = 1f;

	public static int entriesPerRow = 20;

	public static int maxRows = 2;

	public override void ExposeData()
	{
		Scribe_Values.Look(ref reducewill, "reducewill", defaultValue: true);
		base.ExposeData();
	}
}
