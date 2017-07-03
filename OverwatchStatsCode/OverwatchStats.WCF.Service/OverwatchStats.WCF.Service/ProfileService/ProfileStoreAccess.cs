using System;
using System.Collections.Generic;

namespace OverwatchStats.WCF.Service.ProfileService
{
    public class ProfileStoreAccess
    {
        private string _connectionString;

        public ProfileStoreAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Common.Data.General.Profile GetProfile(string userName, int regionId, int platformId)
        {
            var profile = new Common.Data.General.Profile();
            try
            {
                profile = new Store.Service.Profile.ProfileStore(_connectionString).GetProfileByUsername(userName, regionId, platformId);
            }
            catch(Exception e)
            {

            }

            return profile;
        }

        public void InsertProfile(string userName, int regionId, int platformId)
        {
            try
            {
                new Store.Service.Profile.ProfileStore(_connectionString).
                    InsertNewProfile(
                        userName: userName,
                        regionId: regionId,
                        platformId: platformId);
            }
            catch(Exception e)
            {
            }
        }

        public List<Common.Data.General.Profile> RetrieveAllProfiles()
        {
            var profileList = new List<Common.Data.General.Profile>();

            try
            {
                profileList = new Store.Service.Profile.ProfileStore(_connectionString).GetAllProfiles();
            }
            catch(Exception e)
            { }

            return profileList;
        }
    }
}