using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OverwatchStats.MVC.Models
{
    public class ProfileModel
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        public Common.Data.General.Enums.Platform Platform { get; set; }
        public Common.Data.General.Enums.Region Region { get; set; }

        [Display]
        public Guid ProfileGuid { get; set; }
        public ProfileModel(Common.Data.General.Profile profile)
        {
            int index = profile.UserName.IndexOf('#');
            if (index > 0)
                UserName = profile.UserName.Substring(0, index);
            else
                UserName = profile.UserName;

            Platform = profile.Platform;
            Region = profile.Region;
            ProfileGuid = profile.ProfileGuid;
        }
    }
}