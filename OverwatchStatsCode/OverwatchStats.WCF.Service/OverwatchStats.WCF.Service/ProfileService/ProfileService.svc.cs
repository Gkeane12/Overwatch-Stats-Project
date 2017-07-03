using OverwatchStats.Common.Data.General;
using System.Collections.Generic;

namespace OverwatchStats.WCF.Service.ProfileService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProfileService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProfileService.svc or ProfileService.svc.cs at the Solution Explorer and start debugging.
    public class ProfileService : IProfileService
    {
        public Profile GetOrCreateProfile(string userName, int regionId, int platformId)
        {
            return new ProfileManager()
                .GetOrCreateProfile(
                    userName: userName,
                    regionId: regionId,
                    platformId: platformId);
        }

        public List<Profile> RetieveAllProfiles()
        {
            return new ProfileManager().
                    RetrieveAllProfiles();
        }

        public Profile RetrieveProfile(string userName, int regionId, int platformId)
        {
            return new ProfileManager()
                .RetrieveProfile(
                    userName: userName,
                    regionId: regionId,
                    platformId: platformId);
        }
    }
}
