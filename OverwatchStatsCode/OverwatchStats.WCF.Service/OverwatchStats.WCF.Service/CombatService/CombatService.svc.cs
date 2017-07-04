using OverwatchStats.Common.Data.General;
using System;
using System.Collections.Generic;

namespace OverwatchStats.WCF.Service.CombatService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CombatService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CombatService.svc or CombatService.svc.cs at the Solution Explorer and start debugging.
    public class CombatService : ICombatService
    {
        public List<OverallCombat> GetAllCompetitiveCombatStats(Guid profileGuid)
        {
            return new CombatStatManager()
                .GetAllCompetitiveCombatStats(profileGuid);
        }

        public OverallCombat GetLatestCompetitiveCombatStats(Guid profileGuid)
        {
            return new CombatStatManager()
                .GetLatestCompetitiveCombatStats(profileGuid);
        }

        public void InsertLatestCombatStats(Guid profileGuid, OverallCombat combatRecord)
        {
            new CombatStatManager()
                .CheckandUpdateLatestCompetitiveCombatStats(profileGuid: profileGuid, combatStat: combatRecord);
        }
    }
}
