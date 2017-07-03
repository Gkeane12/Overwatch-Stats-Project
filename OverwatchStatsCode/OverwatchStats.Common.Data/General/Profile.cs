using OverwatchStats.Common.Data.General.Enums;
using System;

namespace OverwatchStats.Common.Data.General
{
    public class Profile
    {
        public Guid ProfileGuid { get; set; }
        public string UserName { get; set; }
        public Region Region { get; set; }
        public Platform Platform { get; set; }
    }
}
