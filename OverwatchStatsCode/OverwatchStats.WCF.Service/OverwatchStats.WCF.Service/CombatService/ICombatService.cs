using OverwatchStats.Common.Data.General;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace OverwatchStats.WCF.Service.CombatService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICombatService" in both code and config file together.
    [ServiceContract]
    public interface ICombatService
    {
        [OperationContract]
        Common.Data.General.OverallCombat GetLatestCompetitiveCombatStats(Guid profileGuid);

        [OperationContract]
        List<Common.Data.General.OverallCombat> GetAllCompetitiveCombatStats(Guid profileGuid);

        [OperationContract]
        void InsertLatestCombatStats(Guid profileGuid, OverallCombat combatRecord);
    }
}
