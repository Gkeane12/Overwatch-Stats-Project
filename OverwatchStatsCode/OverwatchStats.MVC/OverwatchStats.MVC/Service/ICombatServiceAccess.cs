using OverwatchStats.Common.Data.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchStats.MVC.Service
{
    public interface ICombatServiceAccess
    {
        List<OverallCombat> GetAllCompetitveCombatStats(Guid profileGuid);
        OverallCombat GetLatestCombatStats(Guid profileGuid);
    }
}
