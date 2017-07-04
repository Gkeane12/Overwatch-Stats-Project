using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchStats.Service.Web.ObjectCreator
{
    public class AverageStats
    {
        public Common.Data.General.Averages ConstructAverageStats(List<Tuple<string,string>> extractedAverageStats)
        {
            Common.Data.General.Averages average = new Common.Data.General.Averages();

            foreach (var extractedStat in extractedAverageStats)
            {
                switch(extractedStat.Item1)
                {
                    case AverageStrings.Deaths:
                        average.Deaths = float.Parse(extractedStat.Item2);
                        break;
                    case AverageStrings.Eliminations:
                        average.Eliminations = float.Parse(extractedStat.Item2);
                        break;
                    case AverageStrings.FinalBlows:
                        average.FinalBlows = float.Parse(extractedStat.Item2);
                        break;
                    case AverageStrings.HealingDone:
                        average.HealingDone = (int)float.Parse(extractedStat.Item2);
                        break;
                    case AverageStrings.ObjectiveKills:
                        average.ObjectiveKills = float.Parse(extractedStat.Item2);
                        break;
                    case AverageStrings.SoloKills:
                        average.SoloKills = float.Parse(extractedStat.Item2);
                        break;
                    case AverageStrings.MeleeFinalBlows:
                        average.MeleeFinalBlows = float.Parse(extractedStat.Item2);
                        break;
                    case AverageStrings.ObjectiveTime:
                        average.ObjectiveTime = ConvertStringToTimeSpan(extractedStat.Item2);
                        break;
                    case AverageStrings.TimeSpentOnFire:
                        average.TimeSpentOnFire = ConvertStringToTimeSpan(extractedStat.Item2);
                        break;
                    default:
                        break;
                }
            }

            return average;
        }

        private TimeSpan ConvertStringToTimeSpan(string sTimeSpan)
        {
            return TimeSpan.ParseExact(sTimeSpan, "mm\\:ss", CultureInfo.InvariantCulture);
        }
    }
}
