using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebHR.Controllers
{
    public class EmployeeDashboardController : Controller
    {
        // GET: EmployeeDashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeDashboard()
        {
            return View();
        }
    }
}