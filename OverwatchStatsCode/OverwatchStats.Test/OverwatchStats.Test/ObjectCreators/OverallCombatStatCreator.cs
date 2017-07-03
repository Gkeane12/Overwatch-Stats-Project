using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OverwatchStats.Service.Web.ObjectCreator;
using HtmlAgilityPack;
using System.IO;
using OverwatchStats.Service.Web.StatRetrievers;

namespace OverwatchStats.Test.ObjectCreators
{
    /// <summary>
    /// Summary description for OverallCombatStatCreator
    /// </summary>
    [TestClass]
    public class OverallCombatStatCreator
    {
        public OverallCombatStatCreator()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CombatStatRetrieverIncorrectWebpageThrowsExceptiot()
        {
            HtmlDocument emptyDoc = new HtmlDocument();
            var StatRetriever = new OverallCombatStatRetriever(emptyDoc);
        }

        [TestMethod]
        public void CreatePartialCombatStatClassIgnoringAllIncorrectInfo()
        {
            var expectedCombatStats = new Common.Data.General.OverallCombat
            {
                DamageDone = 1000,
                Eliminations = 10,
                EnvironmentalKills = 4
            };

            var actualCombatStats = new OverallCombatStats().ConstructCombatStats(CreateTestData(1000, 10, 4));

            Assert.AreEqual(expectedCombatStats.DamageDone, actualCombatStats.DamageDone, "Damage Done");
            Assert.AreEqual(expectedCombatStats.Eliminations, actualCombatStats.Eliminations, "Eliminations");
            Assert.AreEqual(expectedCombatStats.SoloKills, actualCombatStats.SoloKills, "SoloKills");
            Assert.AreEqual(expectedCombatStats.ObjectiveKills, actualCombatStats.ObjectiveKills, "ObjectiveKills");
            Assert.AreEqual(expectedCombatStats.FinalBlows, actualCombatStats.FinalBlows, "FinalBlows");
            Assert.AreEqual(expectedCombatStats.MultiKills, actualCombatStats.MultiKills, "MultiKills");
            Assert.AreEqual(expectedCombatStats.MeleeFinalBlows, actualCombatStats.MeleeFinalBlows, "MeleeFinalBlows");
            Assert.AreEqual(expectedCombatStats.SR, actualCombatStats.SR, "SR");
        }

        [TestMethod]
        public void TestLoadingCombatStatsFromStaticWebsite()
        {
            string docURI = string.Format(@"{0}/Resources/StaticSnapShot.html", Directory.GetCurrentDirectory());
            HtmlDocument doc = new HtmlDocument();
            doc.Load(docURI);
            var StatRetriever = new OverallCombatStatRetriever(doc);
            var initialExtractedvalues = StatRetriever.ExtractCombatStat();

            Assert.AreEqual(initialExtractedvalues[CombatStrings.DamageDone], Resources.StaticSnapShotCombatStatInfo.DamageDone, "Damage Done stat not correctly being retrieved");
            Assert.AreEqual(initialExtractedvalues[CombatStrings.MeleeFinalBlows], Resources.StaticSnapShotCombatStatInfo.MeleeFinalBlows, "Melee Final Blows stat not correctly being retrieved");
            Assert.AreEqual(initialExtractedvalues[CombatStrings.SoloKills], Resources.StaticSnapShotCombatStatInfo.SoloKills, "Solo kills stat not correctly being retrieved");
            Assert.AreEqual(initialExtractedvalues[CombatStrings.ObjectiveKills], Resources.StaticSnapShotCombatStatInfo.ObjectiveKills, "Objective kills stat not correctly being retrieved");
            Assert.AreEqual(initialExtractedvalues[CombatStrings.FinalBlows], Resources.StaticSnapShotCombatStatInfo.FinalBlows, "Final Blows stat not correctly being retrieved");
            Assert.AreEqual(initialExtractedvalues[CombatStrings.Eliminations], Resources.StaticSnapShotCombatStatInfo.Eliminations, "Eliminations stat not correctly being retrieved");
            Assert.AreEqual(initialExtractedvalues[CombatStrings.EnvironmentalKills], Resources.StaticSnapShotCombatStatInfo.EnvironmentalKills, "Environmental kills stat not correctly being retrieved");
            Assert.AreEqual(initialExtractedvalues[CombatStrings.MultKills], Resources.StaticSnapShotCombatStatInfo.MultiKills, "Multi kills stat not correctly being retrieved");
            Assert.AreEqual(initialExtractedvalues[CombatStrings.SR], Resources.StaticSnapShotCombatStatInfo.SR, "SR stat not correctly extracted");

        }

        [TestMethod]
        public void TestExtractingSR()
        {
            string docURI = string.Format(@"{0}/Resources/StaticSnapShot.html", Directory.GetCurrentDirectory());
            HtmlDocument doc = new HtmlDocument();
            doc.Load(docURI);

            var StatRetriever = new OverallCombatStatRetriever(doc);
            var initialExtractedvalues = StatRetriever.ExtractCombatStat();

            Assert.IsNotNull(initialExtractedvalues[CombatStrings.SR], "Sr was not extracted");
        }

        private Dictionary<string, long> CreateTestData(long damageDone, long Eliminations, long environmentalKills)
        {
            return new Dictionary<string, long>
            {
                {CombatStrings.DamageDone, damageDone },
                {CombatStrings.Elimination, Eliminations },
                {CombatStrings.EnvironmentalKills, environmentalKills }
            };
        }
    }
}
