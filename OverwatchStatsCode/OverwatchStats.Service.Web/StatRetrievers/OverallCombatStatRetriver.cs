﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OverwatchStats.Service.Web.StatRetrievers
{
    public class OverallCombatStatRetriever
    {
        private const int _statNameIndex = 0;
        private const int _statValueIndex = 1;
        private Dictionary<string, long> _allHeroStats = new Dictionary<string, long>();
        private HtmlNodeCollection _combatNodeCollection;
        private string _combatStatsXpath = "//*[@id='competitive']/section[3]/div/div[2]/div[1]/div/table/tbody";

        public OverallCombatStatRetriever(HtmlDocument _doc)
        {
            if (_doc == null)
                throw new ArgumentNullException("_doc");

            var combatStatParentNode = _doc.DocumentNode.SelectSingleNode(_combatStatsXpath);

            if (combatStatParentNode != null && combatStatParentNode.ChildNodes.Any())
                _combatNodeCollection = combatStatParentNode.ChildNodes;
            else
                throw new InvalidOperationException("Combat stats could not be found in HTML Document at the Xpath");
        }

        public Dictionary<string, long> ExtractCombatStat()
        {
            foreach(HtmlNode combatNode in _combatNodeCollection)
            {
                ExtractCombatIndividualStat(combatNode);
            }

            return _allHeroStats;
        }

        private void ExtractCombatIndividualStat(HtmlNode combatNode)
        {
            string statName = combatNode.ChildNodes[_statNameIndex].InnerText;
            long statValue = 0;

            //To deal with returns which have commas in them (e.g 1,242,111) we must remove the non numeric characters
            string extractedValue = new string(combatNode.ChildNodes[_statValueIndex].InnerText.Where(c => char.IsDigit(c)).ToArray());

            long.TryParse(extractedValue, out statValue);
            _allHeroStats.Add(statName, statValue);
        }

    }
}
