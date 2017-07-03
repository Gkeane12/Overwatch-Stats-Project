using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OverwatchStats.Common.Data.General;

namespace OverwatchStats.MVC.Service
{
    public class CombatServiceAccess : ICombatServiceAccess
    {
        public List<OverallCombat> GetAllCompetitveCombatStats(Guid profileGuid)
        {
            List<OverallCombat> combatList = new List<OverallCombat>();

            using (var _combatService = new CombatService.CombatServiceClient())
            {
                try
                {
                    combatList = _combatService.GetAllCompetitiveCombatStats(profileGuid).ToList();
                }
                catch(Exception e)
                {

                }
            }

            return combatList;
        }

        public OverallCombat GetLatestCombatStats(Guid profileGuid)
        {
            OverallCombat combatStats = new OverallCombat();

            using (var _combatService = new CombatService.CombatServiceClient())
            {
                try
                {
                    combatStats = _combatService.GetLatestCompetitiveCombatStats(profileGuid);
                }
                catch(Exception e)
                {

                }
            }

            return combatStats;
        }
    }
}