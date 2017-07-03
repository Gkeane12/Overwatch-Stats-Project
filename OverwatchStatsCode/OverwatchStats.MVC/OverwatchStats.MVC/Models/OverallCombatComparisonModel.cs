using OverwatchStats.Common.Data.General;
using System.Collections.Generic;

namespace OverwatchStats.MVC.Models
{
    public class OverallCombatComparisonModel
    {
        public List<OverallCombatModel> _combatModels = new List<OverallCombatModel>();
        public List<OverallCombatModel> _combatDifferences = new List<OverallCombatModel>();

        public OverallCombatComparisonModel(List<OverallCombat> combatModels)
        {
            foreach(var combat in combatModels)
            {
                _combatModels.Add(new OverallCombatModel(combat));
            }

            CreateCombatDifferences();
        }

        private void CreateCombatDifferences()
        {
            for(int i = 0; i < _combatModels.Count -1; i++)
            {
                int j = i + 1;

                OverallCombat combatdiff = new OverallCombat()
                {
                    DamageDone = _combatModels[i].DamageDone - _combatModels[j].DamageDone,
                    MeleeFinalBlows = _combatModels[i].MeleeFinalBlows - _combatModels[j].MeleeFinalBlows,
                    SoloKills = _combatModels[i].SoloKills - _combatModels[j].SoloKills,
                    ObjectiveKills = _combatModels[i].ObjectiveKills - _combatModels[j].ObjectiveKills,
                    FinalBlows = _combatModels[i].FinalBlows - _combatModels[j].FinalBlows,
                    Eliminations = _combatModels[i].Eliminations - _combatModels[j].Eliminations,
                    EnvironmentalKills = _combatModels[i].EnvironmentalKills - _combatModels[j].EnvironmentalKills,
                    MultiKills = _combatModels[i].MultiKills - _combatModels[j].MultiKills
                };

                _combatDifferences.Add(new OverallCombatModel(combatdiff));
            }
        }
    }
}