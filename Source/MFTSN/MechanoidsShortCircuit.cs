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
            foreach (Pawn mechanoid in map.mapPawns.AllPawnsSpawned.Where(p => p.RaceProps.IsMechanoid))
                HealthUtility.AdjustSeverity(mechanoid, HediffDef.Named("MechanoidShock"), 0.005f * Mathf.Lerp(0.85f, 1.15f, Rand.ValueSeeded(mechanoid.thingIDNumber ^ 74374237)));
            //Code golf challenge between Mehni and Xeo, TDLR: Mehni Wins
        }
    }
}
