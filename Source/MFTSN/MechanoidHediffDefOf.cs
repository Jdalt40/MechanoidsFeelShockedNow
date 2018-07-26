using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MFTSN
{
	[DefOf]
    public static class MechanoidHediffDefOf
    {
        static MechanoidHediffDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(HediffDefOf));
        }
        public static HediffDef MechanoidShock;
    }
}