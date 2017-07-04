using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchStats.WCF.Test.CombatService
{
    internal class CombatServiceTestBase
    {
        internal ProfileServiceTests.ProfileServiceTestBase profilebase = new ProfileServiceTests.ProfileServiceTestBase();

        internal OverallCombat combatTestOne = new OverallCombat()
        {
            DamageDone = 1221,
            Eliminations = 32,
            EnvironmentalKills = 10,
            FinalBlows = 6,
            MeleeFinalBlows = 5,
            MultiKills = 3,
            ObjectiveKills = 10,
            SoloKills = 5,
            SR = 1000,
            RecordDate = new DateTime()
        };

        internal OverallCombat combatTestTwo = new OverallCombat()
        {
            DamageDone = 211,
            Eliminations = 11,
            EnvironmentalKills = 151,
            FinalBlows = 5,
            MeleeFinalBlows = 1,
            MultiKills = 76,
            ObjectiveKills = 1,
            SoloKills = 1,
            SR = 2000,
            RecordDate = new DateTime()
        };

        internal void AddProfiles()
        {
            using (var profileService = new ProfileService.ProfileServiceClient())
            {
                profilebase.TestProfileOne.ProfileGuid = profileService
                    .GetOrCreateProfile(
                        userName: profilebase.TestProfileOne.UserName,
                        platformId: (int)profilebase.TestProfileOne.Platform,
                        regionId: (int)profilebase.TestProfileOne.Region).ProfileGuid;

                profilebase.TestProfileTwo.ProfileGuid = profileService
                    .GetOrCreateProfile(
                        userName: profilebase.TestProfileTwo.UserName,
                        platformId: (int)profilebase.TestProfileTwo.Platform,
                        regionId: (int)profilebase.TestProfileTwo.Region).ProfileGuid;
            }
        }
    }
}
