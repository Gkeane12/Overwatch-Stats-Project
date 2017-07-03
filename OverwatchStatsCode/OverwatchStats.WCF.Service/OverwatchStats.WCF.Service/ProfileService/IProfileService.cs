using System.Collections.Generic;
using System.ServiceModel;

namespace OverwatchStats.WCF.Service.ProfileService
{
    [ServiceContract]
    public interface IProfileService
    {
        [OperationContract]
        Common.Data.General.Profile GetOrCreateProfile(string userName, int regionId, int platformId);

        [OperationContract]
        Common.Data.General.Profile RetrieveProfile(string userName, int regionId, int platformId);

        [OperationContract]
        List<Common.Data.General.Profile> RetieveAllProfiles();
    }
}
