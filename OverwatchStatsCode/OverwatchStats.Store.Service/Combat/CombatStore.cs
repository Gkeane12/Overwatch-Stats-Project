using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OverwatchStats.Store.Service.Combat
{
    public class CombatStore
    {
        private string _connectionString;

        public CombatStore(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Common.Data.General.OverallCombat GetLatestCompetitiveCombatStats(Guid profileGuid)
        {
            var combatStat = new Common.Data.General.OverallCombat();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("Competitive.GetLatestCombatStatsForProfileGuid", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(
                        new SqlParameter(
                            "@profileGuid", profileGuid
                            ));

                    SqlDataReader rdr = command.ExecuteReader();

                    int profileGuidOrdinal = rdr.GetOrdinal("ProfileGuid");
                    int meleeFinalBlowsOrdinal = rdr.GetOrdinal("MeleeFinalBlows");
                    int objectiveKillsOrdinal = rdr.GetOrdinal("ObjectiveKills");
                    int soloKillsOrdinal = rdr.GetOrdinal("SoloKills");
                    int finalBlowsOrdinal = rdr.GetOrdinal("FinalBlows");
                    int damageDoneOrdinal = rdr.GetOrdinal("DamageDone");
                    int eliminationsOrdinal = rdr.GetOrdinal("Eliminations");
                    int multiKillsOrdinal = rdr.GetOrdinal("MultiKills");
                    int recordDateOrdinal = rdr.GetOrdinal("RecordDate");
                    int environmentalOrdinal = rdr.GetOrdinal("EnvironmentalKills");
                    int srOrdinal = rdr.GetOrdinal("SR");

                    while(rdr.Read())
                    {
                        combatStat.MeleeFinalBlows = rdr.GetInt32(meleeFinalBlowsOrdinal);
                        combatStat.ObjectiveKills = rdr.GetInt32(objectiveKillsOrdinal);
                        combatStat.SoloKills = rdr.GetInt32(soloKillsOrdinal);
                        combatStat.FinalBlows = rdr.GetInt32(finalBlowsOrdinal);
                        combatStat.DamageDone = rdr.GetInt64(damageDoneOrdinal);
                        combatStat.Eliminations = rdr.GetInt32(eliminationsOrdinal);
                        combatStat.MultiKills = rdr.GetInt32(multiKillsOrdinal);
                        combatStat.RecordDate = rdr.GetDateTime(recordDateOrdinal);
                        combatStat.EnvironmentalKills = rdr.GetInt32(environmentalOrdinal);
                        combatStat.SR = rdr.GetInt32(srOrdinal);
                    }
                }
            }
            catch(SqlException Sqle)
            { }

            return combatStat;
        }

        public List<Common.Data.General.OverallCombat> GetAllCompetitiveCombatStats(Guid profileGuid)
        {
            List<Common.Data.General.OverallCombat> combatStats = new List<Common.Data.General.OverallCombat>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("Competitive.GetAllCombatStatsForProfileGuid", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(
                        new SqlParameter(
                            "@profileGuid", profileGuid
                            ));

                    SqlDataReader rdr = command.ExecuteReader();

                    int profileGuidOrdinal = rdr.GetOrdinal("ProfileGuid");
                    int meleeFinalBlowsOrdinal = rdr.GetOrdinal("MeleeFinalBlows");
                    int objectiveKillsOrdinal = rdr.GetOrdinal("ObjectiveKills");
                    int soloKillsOrdinal = rdr.GetOrdinal("SoloKills");
                    int finalBlowsOrdinal = rdr.GetOrdinal("FinalBlows");
                    int damageDoneOrdinal = rdr.GetOrdinal("DamageDone");
                    int eliminationsOrdinal = rdr.GetOrdinal("Eliminations");
                    int multiKillsOrdinal = rdr.GetOrdinal("MultiKills");
                    int recordDateOrdinal = rdr.GetOrdinal("RecordDate");
                    int environmentalOrdinal = rdr.GetOrdinal("EnvironmentalKills");
                    int srOrdinal = rdr.GetOrdinal("SR");

                    while (rdr.Read())
                    {
                        var combatStat = new Common.Data.General.OverallCombat();
                        combatStat.MeleeFinalBlows = rdr.GetInt32(meleeFinalBlowsOrdinal);
                        combatStat.ObjectiveKills = rdr.GetInt32(objectiveKillsOrdinal);
                        combatStat.SoloKills = rdr.GetInt32(soloKillsOrdinal);
                        combatStat.FinalBlows = rdr.GetInt32(finalBlowsOrdinal);
                        combatStat.DamageDone = rdr.GetInt64(damageDoneOrdinal);
                        combatStat.Eliminations = rdr.GetInt32(eliminationsOrdinal);
                        combatStat.MultiKills = rdr.GetInt32(multiKillsOrdinal);
                        combatStat.RecordDate = rdr.GetDateTime(recordDateOrdinal);
                        combatStat.EnvironmentalKills = rdr.GetInt32(environmentalOrdinal);
                        combatStat.SR = rdr.GetInt32(srOrdinal);

                        combatStats.Add(combatStat);
                    }
                }
            }
            catch (SqlException Sqle)
            { }

            return combatStats;
        }

        public void InsertUpdateLatestCompetitiveCombatStat(Guid ProfileGuid, Common.Data.General.OverallCombat combatStat)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("Competitive.InsertUpdateCombatStat", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddRange(new SqlParameter[] {
                        new SqlParameter("@profileGuid", ProfileGuid),
                        new SqlParameter("@meleeFinalBlows", combatStat.MeleeFinalBlows),
                        new SqlParameter("@objectiveKills", combatStat.ObjectiveKills),
                        new SqlParameter("@soloKills", combatStat.SoloKills),
                        new SqlParameter("@finalBlows", combatStat.FinalBlows),
                        new SqlParameter("@damageDone", combatStat.DamageDone),
                        new SqlParameter("@eliminations", combatStat.Eliminations),
                        new SqlParameter("@multiKills", combatStat.MultiKills),
                        new SqlParameter("@environmentalKills", combatStat.EnvironmentalKills),
                        new SqlParameter("@sr", combatStat.SR)
                    });
                    command.ExecuteNonQuery();
                }
            }
            catch(SqlException Sqle)
            { }
        }
    }
}
