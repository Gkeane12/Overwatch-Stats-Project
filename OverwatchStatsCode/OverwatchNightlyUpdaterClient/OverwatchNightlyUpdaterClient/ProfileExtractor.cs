using OverwatchStats.Common.Data.General;
using OverwatchStats.Common.Data.General.Enums;
using System.Xml;

namespace OverwatchNightlyUpdaterClient
{

    internal class ProfileExtractor
    {
        internal XmlDocument _doc = new XmlDocument();
        internal int Count = 0;
        internal ProfileExtractor(XmlDocument doc)
        {
            _doc = doc;
            Count = _doc.SelectNodes("/PlayerList/Player").Count;
        }

        internal Profile GetIndividualProfile(int index)
        {
            var profile = new Profile();

            profile.UserName = _doc.SelectNodes("/PlayerList/Player").Item(index).SelectSingleNode("Username").InnerText;
            profile.Region = StringToRegion(_doc.SelectNodes("/PlayerList/Player").Item(index).SelectSingleNode("Region").InnerText);
            profile.Platform = StringToPlatform(_doc.SelectNodes("/PlayerList/Player").Item(index).SelectSingleNode("Platform").InnerText);

            return profile;
        }

        private Region StringToRegion(string region)
        {
            switch (region)
            {
                case "EU":
                    return Region.EU;
                case "NA":
                    return Region.NA;
                case "KR":
                    return Region.KR;
                default:
                    return Region.NONE;
            }
        }
        private Platform StringToPlatform(string platform)
        {
            switch(platform)
            {
                case "PC":
                    return Platform.PC;
                case "PSN":
                    return Platform.PSN;
                case "XBL":
                    return Platform.XLB;
                default:
                    return Platform.PC;
            }
        }
    }
}
