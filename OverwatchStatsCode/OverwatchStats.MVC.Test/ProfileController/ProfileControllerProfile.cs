using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OverwatchStats.Common.Data.General;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OverwatchStats.MVC.Test.ProfileController
{
    [TestClass]
    public class ProfileControllerProfile
    {
        [TestMethod]
        public void Profile_CombatStatLatestComparison_CreatesOverallCombatStatModels()
        {
            Mock<OverwatchStats.MVC.Service.ICombatServiceAccess> combatService = new Mock<Service.ICombatServiceAccess>();
            var combatList = GenerateListOfOverallCombatStats();
            combatService.Setup(m => m.GetAllCompetitveCombatStats(It.IsAny<Guid>())).Returns(combatList);

            var result = new Controllers.ProfileController(
                profileService: null,
                combatService: combatService.Object).CombatStatLatestComparison(It.IsAny<Guid>()) as PartialViewResult;

            int actualComparisonCounter = 1;
            var actualResult = result.Model as Models.OverallCombatComparisonModel;

            Assert.AreEqual(expected: actualResult._combatDifferences.Count, actual: actualComparisonCounter, message: "Comparison should always be one less that the count of combat models");
        }

        private List<OverallCombat> GenerateListOfOverallCombatStats()
        {
            return new List<OverallCombat>
            {
                new OverallCombat
                {
                    DamageDone = 123123,
                    Eliminations = 1243,
                    EnvironmentalKills = 21,
                    FinalBlows = 1,
                    MeleeFinalBlows = 100,
                    MultiKills = 57,
                    ObjectiveKills = 200,
                    RecordDate = DateTime.Now,
                    SoloKills  =50
                },
                new OverallCombat
                {
                    DamageDone = 2,
                    Eliminations = 1,
                    EnvironmentalKills = 2,
                    FinalBlows = 1,
                    MeleeFinalBlows = 1,
                    MultiKills = 1,
                    ObjectiveKills = 1,
                    RecordDate = DateTime.Today.AddDays(-1),
                    SoloKills  =50
                },
            };
        }
    }
}
