using System.Data.SqlClient;
using OverwatchStats;
using System.Collections.Generic;

namespace OverwatchStats.Store.Service.Profile
{
    public class ProfileStore
    {
        private string _connectionString;

        public ProfileStore(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Common.Data.General.Profile GetProfileByUsername(string userName, int regionId, int platformId)
        {
            var profile = new Common.Data.General.Profile();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("General.GetProfileInfoByName", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddRange(new SqlParameter[] {
                        new SqlParameter("@profileName", userName),
                        new SqlParameter("@platformId", platformId),
                        new SqlParameter("@regionId", regionId)
                    });

                    SqlDataReader rdr = command.ExecuteReader();

                    int profileGuidOrdinal = rdr.GetOrdinal("ProfileGuid");
                    int userNameOrdinal = rdr.GetOrdinal("UserName");
                    int regionIdOrdinal = rdr.GetOrdinal("RegionId");
                    int platformIdOrdinal = rdr.GetOrdinal("PlatformId");

                    while (rdr.Read())
                    {
                        var _profileGuid = rdr.GetGuid(profileGuidOrdinal);
                        var _platformId = rdr.GetInt32(platformIdOrdinal);
                        var _regionId = rdr.GetInt32(regionIdOrdinal);
                        var _name = rdr.GetString(userNameOrdinal);

                        profile = new Common.Data.General.Profile
                        {
                            ProfileGuid = _profileGuid,
                            Platform = (Common.Data.General.Enums.Platform)_platformId,
                            UserName = _name,
                            Region = (Common.Data.General.Enums.Region)_regionId
                        };
                    }
                }
            }
            catch (SqlException Sqle)
            {
            }
            catch (System.Exception e)
            { }
            return profile;
        }

        public void InsertNewProfile(string userName, int regionId, int platformId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    conn.Open();
                    SqlCommand command = new SqlCommand("General.InsertProfile", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddRange(new SqlParameter[] {
                        new SqlParameter("@userName", userName),
                        new SqlParameter("@platformId", platformId),
                        new SqlParameter("@regionId", regionId)
                    });
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException Sqle)
            { }
            catch (System.Exception e)
            { }
        }

        public List<Common.Data.General.Profile> GetAllProfiles()
        {
            var profileList = new List<Common.Data.General.Profile>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("General.GetAllProfiles", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader rdr = command.ExecuteReader();

                    int profileGuidOrdinal = rdr.GetOrdinal("ProfileGuid");
                    int userNameOrdinal = rdr.GetOrdinal("UserName");
                    int regionIdOrdinal = rdr.GetOrdinal("RegionId");
                    int platformIdOrdinal = rdr.GetOrdinal("PlatformId");

                    while (rdr.Read())
                    {
                        var _profileGuid = rdr.GetGuid(profileGuidOrdinal);
                        var _platformId = rdr.GetInt32(platformIdOrdinal);
                        var _regionId = rdr.GetInt32(regionIdOrdinal);
                        var _name = rdr.GetString(userNameOrdinal);
                        var profile = new Common.Data.General.Profile
                        {
                            ProfileGuid = _profileGuid,
                            Platform = (Common.Data.General.Enums.Platform)_platformId,
                            UserName = _name,
                            Region = (Common.Data.General.Enums.Region)_regionId
                        };

                        profileList.Add(profile);
                    }
                }
            }
            catch (SqlException SQLe)
            { }

            return profileList;
        }
    }
}

