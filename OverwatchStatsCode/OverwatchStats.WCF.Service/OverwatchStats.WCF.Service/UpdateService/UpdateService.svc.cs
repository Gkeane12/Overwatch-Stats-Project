namespace OverwatchStats.WCF.Service.UpdateService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UpdateService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UpdateService.svc or UpdateService.svc.cs at the Solution Explorer and start debugging.
    public class UpdateService : IUpdateService
    {
        public void UpdateLatestCompetitiveStat(string userName, int platformId, int regionId)
        {
            new UpdateManager(userName, regionId, platformId).UpdateAllStats();
        }
    }
}
