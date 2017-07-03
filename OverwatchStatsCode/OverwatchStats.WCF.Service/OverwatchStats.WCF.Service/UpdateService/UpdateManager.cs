using OverwatchStats.Service.Web.WebsiteAccessor;
using OverwatchStats.WCF.Service.CombatService;
using OverwatchStats.WCF.Service.ProfileService;

namespace OverwatchStats.WCF.Service.UpdateService
{
    public class UpdateManager
    {
        private Common.Data.General.Profile profile;
        private ProfileManager _profileManager;
        private CombatStatManager _combatStatManager;

        public UpdateManager(string userName, int regionId, int platformId)
        {
            profile = new Common.Data.General.Profile
            {
                Platform = (Common.Data.General.Enums.Platform)platformId,
                Region = (Common.Data.General.Enums.Region)regionId,
                UserName = userName
            };
        }

        public void UpdateAllStats()
        {
            GetOrCreateUserProfile(new ProfileManager());
            UpdateLatestCombatStat(new CombatStatManager());
        }

        private void GetOrCreateUserProfile(ProfileManager profileManager)
        {
            _profileManager = profileManager;
            profile = _profileManager
                .GetOrCreateProfile(
                    userName: profile.UserName,
                    platformId: (int)profile.Platform,
                    regionId: (int)profile.Region
                );
        }

        private void UpdateLatestCombatStat(CombatStatManager combataStatManager)
        {
            _combatStatManager = combataStatManager;

            var dictionaryCombatStats = new MainSiteAccessPoint(profile).ExtractCombatStatsFromSite();
            _combatStatManager.CheckandUpdateLatestCompetitiveCombatStats(profile.ProfileGuid, dictionaryCombatStats);
        }
    }
}