using OverwatchStats.Common.Data.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchStats.WCF.Test.ProfileServiceTests
{
   internal class ProfileServiceTestBase
    {
        internal Profile TestProfileOne = new Profile
        {
            Platform = Common.Data.General.Enums.Platform.PC,
            Region = Common.Data.General.Enums.Region.EU,
            UserName = "TestUserNameOne"
        };

        internal Profile TestProfileTwo = new Profile
        {
            Platform = Common.Data.General.Enums.Platform.PC,
            Region = Common.Data.General.Enums.Region.EU,
            UserName = "TestUserNameTwo"
        };

        internal void CleanUp()
        {
            using (var CleanUpService = new CleanUpService.CleanUpServiceClient())
            {
                if (TestProfileOne.ProfileGuid != Guid.Empty)
                    CleanUpService.DeleteUser(TestProfileOne.ProfileGuid);
                if (TestProfileTwo.ProfileGuid != Guid.Empty)
                    CleanUpService.DeleteUser(TestProfileTwo.ProfileGuid);
            }
        }
    }
}
