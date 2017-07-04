using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OverwatchStats.Common.Data.General;
using OverwatchStats.Service.Web.ObjectCreator;
using OverwatchStats.Service.Web.StatRetrievers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OverwatchStats.Test.ObjectCreators
{
    [TestClass]
    public class AverageStatCreator
    {
        [TestMethod]
        public void TestLoadingAveragesFromStaticWebsite()
        {
            string docURI = string.Format(@"{0}/Resources/StaticSnapShot.html", Directory.GetCurrentDirectory());
            HtmlDocument doc = new HtmlDocument();
            doc.Load(docURI);

            var StatRetriever = new AverageStatRetriever(doc);
            var initialExtractedValues = StatRetriever.ExtractAverageStats();

            Assert.AreEqual(initialExtractedValues.First(s => s.Item1 == Service.Web.ObjectCreator.AverageStrings.Deaths).Item2, Resources.StaticSnapShotAverageStatInfo.Deaths, "Death Stat not correctly being retrieved");
            Assert.AreEqual(initialExtractedValues.First(s => s.Item1 == Service.Web.ObjectCreator.AverageStrings.MeleeFinalBlows).Item2, Resources.StaticSnapShotAverageStatInfo.MeleeFinalBlows, "Melee Final Blows not correctly being retrieved");
            Assert.AreEqual(initialExtractedValues.First(s => s.Item1 == Service.Web.ObjectCreator.AverageStrings.TimeSpentOnFire).Item2, Resources.StaticSnapShotAverageStatInfo.TimeSpentOnFire, "Time Spent On Fire not correctly being retrieved");
            Assert.AreEqual(initialExtractedValues.First(s => s.Item1 == Service.Web.ObjectCreator.AverageStrings.SoloKills).Item2, Resources.StaticSnapShotAverageStatInfo.SoloKills, "Solo Kills not correctly being retrieved");
            Assert.AreEqual(initialExtractedValues.First(s => s.Item1 == Service.Web.ObjectCreator.AverageStrings.ObjectiveTime).Item2, Resources.StaticSnapShotAverageStatInfo.ObjectiveTime, "Objective Time not correctly being retrieved");
            Assert.AreEqual(initialExtractedValues.First(s => s.Item1 == Service.Web.ObjectCreator.AverageStrings.ObjectiveKills).Item2, Resources.StaticSnapShotAverageStatInfo.ObjectiveKills, "Objective Kills not correctly being retrieved");
            Assert.AreEqual(initialExtractedValues.First(s => s.Item1 == Service.Web.ObjectCreator.AverageStrings.HealingDone).Item2, Resources.StaticSnapShotAverageStatInfo.HealingDone, "Objective Kills not correctly being retrieved");
            Assert.AreEqual(initialExtractedValues.First(s => s.Item1 == Service.Web.ObjectCreator.AverageStrings.FinalBlows).Item2, Resources.StaticSnapShotAverageStatInfo.FinalBlows, "Final Blows not correctly being retrieved");
            Assert.AreEqual(initialExtractedValues.First(s => s.Item1 == Service.Web.ObjectCreator.AverageStrings.Eliminations).Item2, Resources.StaticSnapShotAverageStatInfo.Eliminations, "Eliminations not correctly being retrieved");
        }

        [TestMethod]
        public void ConstructTestFromExtractedValueTest()
        {
            string docURI = string.Format(@"{0}/Resources/StaticSnapShot.html", Directory.GetCurrentDirectory());
            HtmlDocument doc = new HtmlDocument();
            doc.Load(docURI);

            var StatRetriever = new AverageStatRetriever(doc);
            var initialExtractedValues = StatRetriever.ExtractAverageStats();

            var actualObject = new AverageStats().ConstructAverageStats(initialExtractedValues); 
            var expectedObject = createTestAverageObject();

            Assert.AreEqual(expectedObject.MeleeFinalBlows, actualObject.MeleeFinalBlows, "Melee Final Blows not correctly mapped");
            Assert.AreEqual(expectedObject.TimeSpentOnFire, actualObject.TimeSpentOnFire, "Time Spent On Fire not correctly mapped");
            Assert.AreEqual(expectedObject.SoloKills, actualObject.SoloKills, "Solo Kills not correctly mapped");
            Assert.AreEqual(expectedObject.ObjectiveKills, actualObject.ObjectiveKills, "Objective Kills not correctly mapped");
            Assert.AreEqual(expectedObject.ObjectiveTime, actualObject.ObjectiveTime, "Objective Time not correctly mapped");
            Assert.AreEqual(expectedObject.HealingDone, actualObject.HealingDone, "Healing Done not correctly mapped");
            Assert.AreEqual(expectedObject.FinalBlows, actualObject.FinalBlows, "Final Blows not correctly mapped");
            Assert.AreEqual(expectedObject.Deaths, actualObject.Deaths, "Deaths not correctly mapped");
            Assert.AreEqual(expectedObject.Eliminations, actualObject.Eliminations, "Eliminations not correctly mapped");
        }

        private Averages createTestAverageObject()
        {
            return new Averages
            {
                MeleeFinalBlows = 0.18f,
                TimeSpentOnFire = new TimeSpan(hours: 0, minutes: 2, seconds: 2),
                SoloKills = 1.25f,
                ObjectiveTime = new TimeSpan(hours: 0, minutes: 2, seconds: 1),
                ObjectiveKills = 10.92f,
                HealingDone = 6820,
                FinalBlows = 7.49f,
                Deaths = 11.12f,
                Eliminations = 21.77f
            };
        }
    }
}
