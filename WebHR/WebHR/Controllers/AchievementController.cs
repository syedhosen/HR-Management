using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebHR.Gateway;
using WebHR.Manager;
using WebHR.Models;

namespace WebHR.Controllers
{
    public class AchievementController : Controller
    {
        AchievementManager achievementManager = new AchievementManager();
        // GET: Achievement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Msg = achievementManager.Save(achievement) > 0 ? "Saved Succesfully" : "Save Failed";
            }
            
            ModelState.Clear();
            return View();
        }

        public ViewResult Show(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            List<Achievement> achievements = achievementManager.GetAll().ToList();

            var achievement = from s in achievements
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                achievement = achievement.Where(s => s.EmployeeName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    achievement = achievement.OrderByDescending(s => s.EmployeeName);
                    break;
                default:  // Name ascending 
                    achievement = achievement.OrderBy(s => s.EmployeeName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(achievement.ToPagedList(pageNumber, pageSize));
        }
    }
}