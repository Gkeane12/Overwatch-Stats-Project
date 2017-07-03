using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OverwatchStats.Common.Data.General;
using OverwatchStats.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OverwatchStats.MVC.Test.ProfileController
{
    [TestClass]
    public class ProfileControllerIndex
    {
        private readonly Guid _profOneGuid = Guid.Parse("17873D60-2599-4B9C-823B-B5ABC01B4EDD");
        private const string _profOneName = "User1";

        private readonly Guid _profTwoGuid = Guid.Parse("180B3173-944E-486A-9616-A84B90D9FD02");
        private const string _profTwoName = "User2";

        [TestMethod]
        public void Index_DisplayCompleteList()
        {
            Mock<OverwatchStats.MVC.Service.IProfileServiceAccess> profService = new Mock<Service.IProfileServiceAccess>();
            var profList = GenerateProfileList();

            profService.Setup(m => m.RetrieveAllProfiles()).Returns(profList);

            MVC.Controllers.ProfileController profController = new Controllers.ProfileController(profService.Object, null);

            var result = profController.Index() as ViewResult;
            var actualcount = (result.Model as IEnumerable<object>).Cast<object>().ToList().Count;
            

            Assert.IsInstanceOfType(
                value: result.Model, 
                expectedType: typeof(List<ProfileModel>), 
                message:"View Should be working with a List of ProfileModels");

            Assert.AreEqual(
                expected: profList.Count, 
                actual: actualcount,
                message: "Count should be equal to the count of Common Profile Objects supplied");

        }

        private List<Profile> GenerateProfileList()
        {
            var profList = new List<Profile>();

            var prof = new Profile
            {
                Platform = Common.Data.General.Enums.Platform.PSN,
                ProfileGuid = _profOneGuid,
                Region = Common.Data.General.Enums.Region.NA,
                UserName = _profOneName
            };

            profList.AddRange(new Profile[]
                {
                    new Profile
                    {
                        Platform = Common.Data.General.Enums.Platform.PSN,
                        ProfileGuid = _profOneGuid,
                        Region = Common.Data.General.Enums.Region.NONE,
                        UserName = _profOneName
                    },
                    new Profile
                    {
                        Platform = Common.Data.General.Enums.Platform.PC,
                        ProfileGuid = _profTwoGuid,
                        Region = Common.Data.General.Enums.Region.EU,
                        UserName = _profTwoName
                    }
                });

            return profList;

        }
    }
}
