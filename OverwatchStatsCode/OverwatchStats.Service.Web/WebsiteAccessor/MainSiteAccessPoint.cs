using System;

namespace OverwatchStats.Service.Web.WebsiteAccessor
{
    public class MainSiteAccessPoint
    {
        private Common.Data.General.Profile _userProfile;
        private string _mainProfileURL;
        private HtmlAgilityPack.HtmlDocument _doc;
        public bool DoesProfileExist;
        public MainSiteAccessPoint(Common.Data.General.Profile profile)
        {
            _userProfile = profile;
            string urlUserNameString = profile.UserName.Replace('#', '-');

            _mainProfileURL = String.Format(WebsiteStringURL.MainWebsiteURL, PlatformEnumToString(profile.Platform), RegionEnumToString(profile.Region), urlUserNameString);
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            _doc = web.Load(_mainProfileURL);
        }

        public OverwatchStats.Common.Data.General.OverallCombat ExtractCombatStatsFromSite()
        {
            Common.Data.General.OverallCombat combat = new Common.Data.General.OverallCombat();
            try
            {
                var stats = new StatRetrievers.OverallCombatStatRetriever(_doc).ExtractCombatStat();
                if(stats.Count > 0)
                    combat = new ObjectCreator.OverallCombatStats().ConstructCombatStats(stats);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return combat;
        }
        private string RegionEnumToString(Common.Data.General.Enums.Region region)
        {
            switch (region)
                {
                case Common.Data.General.Enums.Region.EU:
                    return "eu/";
                case Common.Data.General.Enums.Region.KR:
                    return "kr/";
                case Common.Data.General.Enums.Region.NA:
                    return "us/";
                default:
                    return string.Empty;    
                }
        }

        private string PlatformEnumToString(Common.Data.General.Enums.Platform platform)
        {
            switch (platform)
            {
                case Common.Data.General.Enums.Platform.PC:
                    return "pc/";
                case Common.Data.General.Enums.Platform.PSN:
                    return "pcn/";
                case Common.Data.General.Enums.Platform.XLB:
                    return "xbl/";
                default:
                    return string.Empty;
            }
        }
    }
}
