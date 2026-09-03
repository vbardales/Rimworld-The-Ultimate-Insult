using Verse;

namespace MFRitual;

public class ModSettings_UltimateInsult : ModSettings
{
	public static bool reducewill = true;

	public override void ExposeData()
	{
		Scribe_Values.Look(ref reducewill, "reducewill", defaultValue: true);
		base.ExposeData();
	}
}
