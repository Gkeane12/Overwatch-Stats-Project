using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchStats.Service.Web.StatRetrievers
{
    public class AverageStatRetriever
    {
        private const int _statNameIndex = 0;
        private const int _statValueIndex = 1;
        private HtmlNodeCollection _averageNodeCollection;
        private string _averageStatXPath = "//*[@id='competitive']/section[3]/div/div[2]/div[4]/div/table/tbody";

        public AverageStatRetriever(HtmlDocument doc)
        {
            if (doc == null)
                throw new ArgumentNullException("doc");

            var parentAverageNode = doc.DocumentNode.SelectSingleNode(_averageStatXPath);

            if (parentAverageNode != null && parentAverageNode.ChildNodes.Any())
                _averageNodeCollection = parentAverageNode.ChildNodes;
            else
                throw new InvalidOperationException("Average stats could not be found");
        }

        public List<Tuple<string,string>> ExtractAverageStats()
        {
            List<Tuple<string, string>> extractedStats = new List<Tuple<string, string>>();

            foreach(var node in _averageNodeCollection)
            {
                extractedStats.Add(ExtractIndividualStat(node));
            }

            return extractedStats;
        }

        private Tuple<string,string> ExtractIndividualStat(HtmlNode averageNode)
        {
            string statName = averageNode.ChildNodes[_statNameIndex].InnerText;
            string statValue = averageNode.ChildNodes[_statValueIndex].InnerText;

            return Tuple.Create(statName, statValue);
        }
    }
}
