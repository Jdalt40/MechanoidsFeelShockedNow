using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;

namespace MFTSN
{
    public class GameCondition_SolarFlare : GameCondition
    {

        public override void GameConditionTick()
        {
            List<Map> affectedMaps = base.AffectedMaps;
            if (Find.TickManager.TicksGame % 60 == 0)
            {
                for (int i = 0; i < affectedMaps.Count; i++)
                {
                    this.DoMechanoidDamage(affectedMaps[i]);
                }
            }
        }
        public void DoMechanoidDamage(Map map)
        {
            List<Pawn> allPawnsSpawned = map.mapPawns.AllPawnsSpawned;
            for (int i = 0; i < allPawnsSpawned.Count; i++)
            {
                Pawn pawn = allPawnsSpawned[i];
                if (pawn.def.race.IsMechanoid)
                {
                    float num = 0.005f;
                    if (num != 0f)
                    {
                        float num2 = Mathf.Lerp(0.85f, 1.15f, Rand.ValueSeeded(pawn.thingIDNumber ^ 74374237));
                        num *= num2;
                        HealthUtility.AdjustSeverity(pawn, MechanoidHediffDefOf.MechanoidShock, num);
                    }
                }
            }
        }
    }
}
