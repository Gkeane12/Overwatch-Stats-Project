using OverwatchStats.Common.Data.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OverwatchStats.MVC.Service
{
    public class ProfileServiceAccess : IProfileServiceAccess
    {
        public List<Profile> RetrieveAllProfiles()
        {
            var profileList = new List<Profile>();

            using (var _profileService = new ProfileService.ProfileServiceClient())
            {
                try
                {
                    profileList = _profileService.RetieveAllProfiles().OrderBy(profile => profile.UserName).ToList();
                }
                catch(Exception e)
                { }
            }

            return profileList;
        }
    }
}