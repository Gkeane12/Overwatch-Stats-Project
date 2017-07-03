using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OverwatchStats.WCF.Service.CleanUpService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICleanUpService" in both code and config file together.
    [ServiceContract]
    public interface ICleanUpService
    {
        [OperationContract]
        void DeleteUser(Guid profileGuid);
    }
}
