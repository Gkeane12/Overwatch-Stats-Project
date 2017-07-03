using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OverwatchStats.WCF.Service.CleanUpService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CleanUpService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CleanUpService.svc or CleanUpService.svc.cs at the Solution Explorer and start debugging.
    public class CleanUpService : ICleanUpService
    {
        public void DeleteUser(Guid profileGuid)
        {
            new CleanUpManager().DeleteUser(profileGuid: profileGuid);
        }
    }
}
