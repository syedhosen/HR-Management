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
    public class PromotionController : Controller
    {
        PromotionManager promotionManager = new PromotionManager();
        // GET: Promotion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // Store Promotion information
        public ActionResult Create(Promotion promotion)
        {
            ViewBag.Msg = promotionManager.Save(promotion) > 0 ? "Saved Succesfully" : "Save Failed";

            if (ViewBag.Msg == "Saved Succesfully")
            {
                return RedirectToAction("Create");
            }
            else
            {
                ViewBag.Msg = "Oops something is wrong.....!!!!";
            }
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

            List<Promotion> promotions = promotionManager.GetAll().ToList();

            var promotion = from s in promotions
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                promotion = promotion.Where(s => s.PromotionFor.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    promotion = promotion.OrderByDescending(s => s.PromotionFor);
                    break;
                default:  // Name ascending 
                    promotion = promotion.OrderBy(s => s.PromotionFor);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(promotion.ToPagedList(pageNumber, pageSize));
        }
    }
}