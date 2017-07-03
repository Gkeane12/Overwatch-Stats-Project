using OverwatchStats.Common.Data.General;
using System.Collections.Generic;

namespace OverwatchStats.MVC.Service
{
    public interface IProfileServiceAccess
    {
        List<Profile> RetrieveAllProfiles();
    }
}
