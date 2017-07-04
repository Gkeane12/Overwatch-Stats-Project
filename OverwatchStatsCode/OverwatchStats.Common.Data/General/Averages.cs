using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchStats.Common.Data.General
{
    public class Averages
    {
        public float MeleeFinalBlows { get; set; }
        public TimeSpan TimeSpentOnFire { get; set; }
        public float SoloKills { get; set; }
        public TimeSpan ObjectiveTime { get; set; }
        public float ObjectiveKills { get; set; }
        public int HealingDone { get; set; }
        public float FinalBlows { get; set; }
        public float Deaths { get; set; }
        public float Eliminations { get; set; }
    }
}
