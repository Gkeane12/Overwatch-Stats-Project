using System.ServiceModel;

namespace OverwatchStats.WCF.Service.UpdateService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUpdateService" in both code and config file together.
    [ServiceContract]
    public interface IUpdateService
    {
        [OperationContract]
        void UpdateLatestCompetitiveStat(string userName, int platformId, int regionId);
    }
}
