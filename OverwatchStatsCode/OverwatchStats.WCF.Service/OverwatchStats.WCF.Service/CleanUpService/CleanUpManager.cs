using OverwatchStats.Store.Service.CleanUp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OverwatchStats.WCF.Service.CleanUpService
{
    public class CleanUpManager
    {
        private readonly string _connectionString;

        public CleanUpManager()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public CleanUpManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DeleteUser(Guid profileGuid)
        {
           new CleanUpStore(_connectionString).DeleteUser(profileGuid: profileGuid);
        }
       
    }
}