using System;
using System.Collections.Generic;

namespace OverwatchStats.WCF.Service.CombatService
{
    public class CombatStoreAccess
    {
        private readonly string _connectionString;
        public CombatStoreAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Common.Data.General.OverallCombat GetLatestCompetitiveCombatStats(Guid profileGuid)
        {
            var combatStat = new Common.Data.General.OverallCombat();

            try
            {
                combatStat = new Store.Service.Combat.CombatStore(_connectionString).GetLatestCompetitiveCombatStats(profileGuid);
            }
            catch(Exception e)
            { }

            return combatStat;
        }

        public List<Common.Data.General.OverallCombat> GetAllCombatCompetitiveStats(Guid profileGuid)
        {
            var combatStats = new List<Common.Data.General.OverallCombat>();

            try
            {
                combatStats = new Store.Service.Combat.CombatStore(_connectionString).GetAllCompetitiveCombatStats(profileGuid);
            }
            catch(Exception e)
            { }

            return combatStats;
        }

        public void InsertUpdateLatestCompetitiveCombatStat(Guid profileGuid, Common.Data.General.OverallCombat combatStat)
        {
            try
            {
                new Store.Service.Combat
                    .CombatStore(_connectionString)
                    .InsertUpdateLatestCompetitiveCombatStat(
                        profileGuid, 
                        combatStat);
            }
            catch(Exception e)
            { }
        }
    }
}