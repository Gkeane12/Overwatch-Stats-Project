using System;

namespace OverwatchStats.Common.Data.General
{
    public class OverallCombat
    {
        public int MeleeFinalBlows { get; set; }
        public int SoloKills { get; set; }
        public int ObjectiveKills { get; set; }
        public int FinalBlows { get; set; }
        public long DamageDone { get; set; }
        public int Eliminations { get; set; }
        public int EnvironmentalKills { get; set; }
        public int MultiKills { get; set; }
        public int SR { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
