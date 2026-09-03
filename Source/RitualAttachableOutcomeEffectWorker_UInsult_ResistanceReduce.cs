using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace MFRitual;

[StaticConstructorOnStartup]
public class RitualAttachableOutcomeEffectWorker_UInsult_ResistanceReduce : RitualAttachableOutcomeEffectWorker
{
	public override void Apply(Dictionary<Pawn, int> totalPresence, LordJob_Ritual jobRitual, RitualOutcomePossibility outcome, out string extraOutcomeDesc, ref LookTargets letterLookTargets)
	{
		extraOutcomeDesc = def.letterInfoText;
		if (outcome.BestPositiveOutcome(jobRitual))
		{
			foreach (Pawn key in totalPresence.Keys)
			{
				if (key != null && (key.IsPrisoner || (key.IsPrisonerOfColony && key != null)))
				{
					key.guest.resistance = 0f;
					if (ModSettings_UltimateInsult.reducewill)
					{
						key.guest.will = 0f;
					}
					BodyPartRecord bodyPartRecord = key.health.hediffSet.GetNotMissingParts().FirstOrDefault((BodyPartRecord x2) => x2.def == BodyPartDefOf.Arm);
					if (bodyPartRecord != null)
					{
						key?.health.AddHediff(HediffDefOf.MissingBodyPart, bodyPartRecord);
					}
					Messages.Message("Prisoner resistance reduced to 0.", key, MessageTypeDefOf.PositiveEvent);
				}
			}
			return;
		}
		foreach (Pawn key2 in totalPresence.Keys)
		{
			if (key2.IsPrisoner || (key2.IsPrisonerOfColony && key2 != null))
			{
				key2.guest.resistance -= 0.5f;
				if (ModSettings_UltimateInsult.reducewill)
				{
					key2.guest.will = 0f;
				}
				BodyPartRecord bodyPartRecord2 = key2.health.hediffSet.GetNotMissingParts().FirstOrDefault((BodyPartRecord x2) => x2.def == BodyPartDefOf.Arm);
				if (bodyPartRecord2 != null)
				{
					key2?.health.AddHediff(HediffDefOf.MissingBodyPart, bodyPartRecord2);
				}
				Messages.Message("Prisoner resistance reduced a lot.", key2, MessageTypeDefOf.PositiveEvent);
			}
		}
	}
}
