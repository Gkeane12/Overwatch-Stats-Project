using OverwatchStats.MVC.Models;
using OverwatchStats.MVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OverwatchStats.MVC.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileServiceAccess _profileService;
        private ICombatServiceAccess _combatService;
        public ProfileController(IProfileServiceAccess profileService, ICombatServiceAccess combatService)
        {
            _profileService = profileService;
            _combatService = combatService;
        }
        // GET: Profile
        public ActionResult Index()
        {
            var profileList = new List<Common.Data.General.Profile>();

            profileList = _profileService.RetrieveAllProfiles();

            var profileModelList = new List<ProfileModel>();

            foreach(var prof in profileList)
            {
                profileModelList.Add(new ProfileModel(prof));
            }

            return View(profileModelList);
        }

        public new ActionResult Profile(Guid profileGuid, string userName)
        {
            var tuple = new Tuple<Guid, string>(profileGuid, userName);

            return View(tuple);
        }

        public ActionResult CombatStatLatestComparison(Guid profileGuid)
        {
            OverallCombatComparisonModel combatStats;
            var combatObjects = new List<Common.Data.General.OverallCombat>();

            combatObjects = _combatService.GetAllCompetitveCombatStats(profileGuid);

            combatStats = new OverallCombatComparisonModel(combatObjects);

            return PartialView(combatStats);
        }
    }
}