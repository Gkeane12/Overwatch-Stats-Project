using System;
using System.Collections.Generic;
using System.Configuration;

namespace OverwatchStats.WCF.Service.CombatService
{
    public class CombatStatManager
    {
        private readonly string _connectionString;

        public CombatStatManager()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public CombatStatManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Common.Data.General.OverallCombat CheckandUpdateLatestCompetitiveCombatStats(Guid profileGuid, Common.Data.General.OverallCombat combatStat)
        {
            if (combatStat.RecordDate != null && combatStat.RecordDate == DateTime.Now)
                return combatStat;
            else
            {
                InsertUpdateLatestCompetitiveCombatStat(profileGuid, combatStat);
                combatStat = GetLatestCompetitiveCombatStats(profileGuid);
            }

            return combatStat;
        }

        public Common.Data.General.OverallCombat GetLatestCompetitiveCombatStats(Guid profileGuid)
        {
            var combatStat = new Common.Data.General.OverallCombat();

            combatStat = new CombatStoreAccess(_connectionString).GetLatestCompetitiveCombatStats(profileGuid);

            return combatStat;
        }

        public List<Common.Data.General.OverallCombat> GetAllCompetitiveCombatStats(Guid profileGuid)
        {
            var allCombatStats = new List<Common.Data.General.OverallCombat>();

            allCombatStats = new CombatStoreAccess(_connectionString).GetAllCombatCompetitiveStats(profileGuid);
            return allCombatStats;
        }

        public void InsertUpdateLatestCompetitiveCombatStat(Guid profileGuid, Common.Data.General.OverallCombat combatStat)
        {
            new CombatStoreAccess(_connectionString).InsertUpdateLatestCompetitiveCombatStat(profileGuid, combatStat);
        }
    }
}