using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OverwatchStats.Common.Data.General;
using System.Linq;

namespace OverwatchStats.WCF.Test.ProfileServiceTests
{
    [TestClass]
    public class ProfileCreateGetTests 
    {
        private ProfileServiceTestBase testBase = new ProfileServiceTestBase();

        [TestMethod]
        public void GetOrCreateProfileShouldReturnNewProfile()
        {
            using (var profileService = new ProfileService.ProfileServiceClient())
            {
               var profile =  profileService.GetOrCreateProfile(
                    userName: testBase.TestProfileOne.UserName,
                    regionId: (int)testBase.TestProfileOne.Region,
                    platformId: (int)testBase.TestProfileOne.Region);

                testBase.TestProfileOne.ProfileGuid = profile.ProfileGuid;
            }

            Assert.AreNotEqual(notExpected: Guid.Empty, actual: testBase.TestProfileOne.ProfileGuid);
        }

        [TestMethod]
        public void CleanUpProfileScriptShouldDeleteTestUserOne()
        {
            using (var profileService = new ProfileService.ProfileServiceClient())
            {
                var profile = profileService.GetOrCreateProfile(
                     userName: testBase.TestProfileOne.UserName,
                     regionId: (int)testBase.TestProfileOne.Region,
                     platformId: (int)testBase.TestProfileOne.Region);

                testBase.TestProfileOne.ProfileGuid = profile.ProfileGuid;
            }

            using (var cleanUpService = new CleanUpService.CleanUpServiceClient())
            {
                cleanUpService.DeleteUser(testBase.TestProfileOne.ProfileGuid);
            }

            using (var profileService = new ProfileService.ProfileServiceClient())
            {
                var profile = profileService.RetrieveProfile(
                     userName: testBase.TestProfileOne.UserName,
                     regionId: (int)testBase.TestProfileOne.Region,
                     platformId: (int)testBase.TestProfileOne.Region);

                testBase.TestProfileOne.ProfileGuid = (profile == null) ? profile.ProfileGuid : Guid.Empty;
            }

        }

        [TestMethod]
        public void GetAllProfilesReturnTwoTestUsers()
        {
            using (var profileService = new ProfileService.ProfileServiceClient())
            {
                var profile = profileService.GetOrCreateProfile(
                     userName: testBase.TestProfileOne.UserName,
                     regionId: (int)testBase.TestProfileOne.Region,
                     platformId: (int)testBase.TestProfileOne.Region);

                testBase.TestProfileOne.ProfileGuid = profile.ProfileGuid;

                profile = profileService.GetOrCreateProfile(
                     userName: testBase.TestProfileTwo.UserName,
                     regionId: (int)testBase.TestProfileTwo.Region,
                     platformId: (int)testBase.TestProfileTwo.Region);

                testBase.TestProfileTwo.ProfileGuid = profile.ProfileGuid;
            }

            var profList = new List<Profile>();

            using (var profileService = new ProfileService.ProfileServiceClient())
            {
                profList = profileService.RetieveAllProfiles().ToList();
            }

            var testProfileOneExists = profList.Any(p => p.ProfileGuid == testBase.TestProfileOne.ProfileGuid);
            var testProfileTwoExists = profList.Any(p => p.ProfileGuid == testBase.TestProfileTwo.ProfileGuid);

            Assert.IsTrue(testProfileOneExists, "Test Profile One was not returned");
            Assert.IsTrue(testProfileTwoExists, "Test Profile Two was not returned");
        }

        [TestCleanup]
        public void CleanUp()
        {
            testBase.CleanUp();
        }
    }
}
