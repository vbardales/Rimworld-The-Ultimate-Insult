using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MFRitual;

[StaticConstructorOnStartup]
internal class RitualOutcomeEffectWorker_Channeling_UInsult : RitualOutcomeEffectWorker_FromQuality
{
	public RitualOutcomeEffectWorker_Channeling_UInsult()
	{
	}

	public RitualOutcomeEffectWorker_Channeling_UInsult(RitualOutcomeEffectDef def)
		: base(def)
	{
	}

	protected override void ApplyExtraOutcome(Dictionary<Pawn, int> totalPresence, LordJob_Ritual jobRitual, RitualOutcomePossibility outcome, out string extraOutcomeDesc, ref LookTargets letterLookTargets)
	{
		extraOutcomeDesc = null;
		if (ModsConfig.RoyaltyActive && outcome.Positive)
		{
			Pawn pawn = jobRitual.PawnWithRole("target");
			if (ModSettings_UltimateInsult.reducewill)
			{
				pawn.guest.will = 0f;
			}
			pawn.guest.resistance = 0f;
		}
	}
}
