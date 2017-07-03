using System.Collections.Generic;

namespace OverwatchStats.Service.Web.ObjectCreator
{
    public class OverallCombatStats
    {
        public Common.Data.General.OverallCombat ConstructCombatStats(Dictionary<string,long> _overallCombataStatDictionary)
        {
            Common.Data.General.OverallCombat overallCombatStats = new Common.Data.General.OverallCombat();

            foreach (KeyValuePair<string, long> CombatStat in _overallCombataStatDictionary)
            {
                switch (CombatStat.Key)
                {
                    case CombatStrings.DamageDone:
                        overallCombatStats.DamageDone = CombatStat.Value;
                        break;
                    case CombatStrings.Eliminations:
                    case CombatStrings.Elimination:
                        overallCombatStats.Eliminations = (int)CombatStat.Value;
                        break;
                    case CombatStrings.EnvironmentalKills:
                    case CombatStrings.EnvironmentalKill:
                        overallCombatStats.EnvironmentalKills = (int)CombatStat.Value;
                        break;
                    case CombatStrings.FinalBlows:
                    case CombatStrings.FinalBlow:
                        overallCombatStats.FinalBlows = (int)CombatStat.Value;
                        break;
                    case CombatStrings.MeleeFinalBlows:
                    case CombatStrings.MeleeFinalBlow:
                        overallCombatStats.MeleeFinalBlows = (int)CombatStat.Value;
                        break;
                    case CombatStrings.MultKills:
                    case CombatStrings.MultKill:
                        overallCombatStats.MultiKills = (int)CombatStat.Value;
                        break;
                    case CombatStrings.ObjectiveKills:
                    case CombatStrings.ObjectiveKill:
                        overallCombatStats.ObjectiveKills = (int)CombatStat.Value;
                        break;
                    case CombatStrings.SoloKills:
                    case CombatStrings.SoloKill:
                        overallCombatStats.SoloKills = (int)CombatStat.Value;
                        break;
                    case CombatStrings.SR:
                        overallCombatStats.SR = (int)CombatStat.Value;
                        break;
                    default:
                        //TODO LOGGING STAT EXTRACTED THATS NOT YET ACCOUNTED FOR
                        break;
                }
            }

            return overallCombatStats;
        }
    }
}
