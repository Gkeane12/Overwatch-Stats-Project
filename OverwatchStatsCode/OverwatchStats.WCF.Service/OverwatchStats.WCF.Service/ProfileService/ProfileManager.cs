using System;
using System.Collections.Generic;
using System.Configuration;

namespace OverwatchStats.WCF.Service.ProfileService
{
    public class ProfileManager
    {
        private readonly string _connectionString;

        public ProfileManager()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public ProfileManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Common.Data.General.Profile GetOrCreateProfile(string userName, int regionId, int platformId)
        {
            var profile = new Common.Data.General.Profile();

            ProfileStoreAccess storeAccess = new ProfileStoreAccess(_connectionString);

            profile = TryRetriveProfile(userName, regionId, platformId, storeAccess);

            if(profile.ProfileGuid == null || profile.ProfileGuid == Guid.Empty)
            {
                storeAccess.InsertProfile(
                    userName: userName,
                    regionId: regionId,
                    platformId: platformId);

                profile = TryRetriveProfile(userName, regionId, platformId, storeAccess);
            }

            return profile;
        }

        public Common.Data.General.Profile RetrieveProfile(string userName, int regionId, int platformId)
        {
            return TryRetriveProfile(userName, regionId, platformId, new ProfileStoreAccess(_connectionString));
        }

        public List<Common.Data.General.Profile> RetrieveAllProfiles()
        {
            return new ProfileStoreAccess(_connectionString).RetrieveAllProfiles();
        }


        private Common.Data.General.Profile TryRetriveProfile(string userName, int regionId, int platformId, ProfileStoreAccess storeAccess)
        {
            var profile = new Common.Data.General.Profile();

            profile = storeAccess.GetProfile(
                userName: userName,
                regionId: regionId,
                platformId: platformId);

            return profile;
        }
    }
}