using OverwatchStats.Common.Data.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OverwatchNightlyUpdaterClient
{
    class Program
    {
        public static object XmlDoc { get; private set; }

        static void Main(string[] args)
        {
            FileLogger logger = new FileLogger();
            XmlDocument doc = new XmlDocument();
            string path;

            if (args.Any())
                path = args[0];
            else
                path = "PlayerList.xml";


            doc.Load(path);
            ProfileExtractor proExtractor = new ProfileExtractor(doc);

            using (var updateService = new UpdateSerive.UpdateServiceClient())
            {
                for (int i = 0; i < proExtractor.Count; i++)
                {
                    Profile profile = proExtractor.GetIndividualProfile(i);
                    try
                    {
                        updateService.UpdateLatestCompetitiveStat(profile.UserName, (int)profile.Platform, (int)profile.Region);

                        logger.WriteSuccess(profile.UserName);
                        Console.WriteLine(String.Format("Updating: {0} Profile", profile.UserName));
                    }
                    catch (Exception e)
                    {
                        logger.WriteError(profile.UserName);
                        Console.WriteLine(String.Format("Error with: {0}", profile.UserName));
                    }
                }
            }

            logger.WriteReports();
            Console.WriteLine("Completed");
            Console.ReadKey();
        }
    }
}
