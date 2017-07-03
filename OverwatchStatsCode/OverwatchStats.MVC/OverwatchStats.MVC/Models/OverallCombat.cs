using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OverwatchStats.MVC.Models
{
    public class OverallCombatModel
    {
        private readonly Common.Data.General.OverallCombat _stats;
        [DisplayName("Damage Done")]
        public long DamageDone { get { return _stats.DamageDone; } }
        [DisplayName("Solo Kills")]
        public int SoloKills { get { return _stats.SoloKills; } }
        [DisplayName("Melee Final Blows")]
        public int MeleeFinalBlows { get { return _stats.MeleeFinalBlows; } }
        [DisplayName("Objective Kills")]
        public int ObjectiveKills { get { return _stats.ObjectiveKills; } }
        [DisplayName("Final Blows")]
        public int FinalBlows { get { return _stats.FinalBlows; } }
        [DisplayName("Eliminations")]
        public int Eliminations { get { return _stats.Eliminations; } }
        [DisplayName("Environmental Kills")]
        public int EnvironmentalKills { get { return _stats.EnvironmentalKills; } }
        [DisplayName("Multi Kills")]
        public int MultiKills { get { return _stats.MultiKills; } }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RecordDate { get { return _stats.RecordDate; } }
        [DisplayName("Season Rating")]
        public int SR { get { return _stats.SR; } }

        public OverallCombatModel(Common.Data.General.OverallCombat combat)
        {
            _stats = combat;
        }
    }
}