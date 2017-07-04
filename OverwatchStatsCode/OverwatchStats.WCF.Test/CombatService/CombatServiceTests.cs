using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace OverwatchStats.WCF.Test.CombatService
{
    [TestClass]
    public class CombatServiceTests
    {
        internal CombatServiceTestBase combatServiceBase = new CombatServiceTestBase();
        [TestInitialize]
        public void TestInitialize()
        {
            combatServiceBase.AddProfiles();
        }

        [TestMethod]
        public void ProfileServiceEnsureTwoProfileInsertedInSameDayOverwriteEachOther()
        {
            var expectCombat = combatServiceBase.combatTestTwo;
            var actualCombat = new List<OverallCombat>();

            using (var combatService = new CombatService.CombatServiceClient())
            {
                combatService.InsertLatestCombatStats(combatServiceBase.profilebase.TestProfileOne.ProfileGuid, combatServiceBase.combatTestOne);
                combatService.InsertLatestCombatStats(combatServiceBase.profilebase.TestProfileOne.ProfileGuid, combatServiceBase.combatTestTwo);

                actualCombat = combatService.GetAllCompetitiveCombatStats(combatServiceBase.profilebase.TestProfileOne.ProfileGuid).ToList();
            }

            var actualIndivdualCombat = actualCombat.FirstOrDefault();

            Assert.AreEqual(expected: 1, actual: actualCombat.Count);

            Assert.AreEqual(expected: expectCombat.DamageDone, actual: actualIndivdualCombat.DamageDone, message: "Damage Done does not match what is expected");
            Assert.AreEqual(expected: expectCombat.Eliminations, actual: actualIndivdualCombat.Eliminations, message: "Eliminations does not match what is expected");
            Assert.AreEqual(expected: expectCombat.EnvironmentalKills, actual: actualIndivdualCombat.EnvironmentalKills, message: "Environmental Kills does not match what is expected");
            Assert.AreEqual(expected: expectCombat.FinalBlows, actual: actualIndivdualCombat.FinalBlows, message: "Final Blows does not match what is expected");
            Assert.AreEqual(expected: expectCombat.MeleeFinalBlows, actual: actualIndivdualCombat.MeleeFinalBlows, message: "Melee Final Blows does not match what is expected");
            Assert.AreEqual(expected: expectCombat.MultiKills, actual: actualIndivdualCombat.MultiKills, message: "Multi Kills does not match what is expected");
            Assert.AreEqual(expected: expectCombat.ObjectiveKills, actual: actualIndivdualCombat.ObjectiveKills, message: "Objective Kills does not match what is expected");
            Assert.AreEqual(expected: expectCombat.SoloKills, actual: actualIndivdualCombat.SoloKills, message: "Solo Kills does not match what is expected");
            Assert.AreEqual(expected: expectCombat.SR, actual: actualIndivdualCombat.SR, message: "SR does not match what is expected");
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            combatServiceBase.profilebase.CleanUp();
        }
    }
}
