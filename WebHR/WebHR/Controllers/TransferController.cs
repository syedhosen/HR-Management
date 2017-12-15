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
    public class TransferController : Controller
    {
        TransferManager transferManager = new TransferManager();
        // GET: Transfer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Transfer transfer)
        {
            ViewBag.Msg = transferManager.Save(transfer) > 0 ? "Saved Succesfully" : "Save Failed";

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

            List<Transfer> transfers = transferManager.GetAll().ToList();

            var transfer = from s in transfers
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                transfer = transfer.Where(s => s.EmployeeToTransfer.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    transfer = transfer.OrderByDescending(s => s.EmployeeToTransfer);
                    break;
                default:  // Name ascending 
                    transfer = transfer.OrderBy(s => s.EmployeeToTransfer);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(transfer.ToPagedList(pageNumber, pageSize));
        }
    }
}