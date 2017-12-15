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
    public class EmployeeController : Controller
    {
        EmployeeManager employeeManager = new EmployeeManager();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // Store Employee information
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Msg = employeeManager.Save(employee) > 0 ? "Saved Succesfully" : "Save Failed";
            }
            ModelState.Clear();
            return View();
            
        }

        // Employee data view
        public ViewResult Show(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            // Employee data search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            List<Employee> employees = employeeManager.GetAll().ToList();

            var employee = from s in employees
                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                employee = employee.Where(s => s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    employee = employee.OrderByDescending(s => s.FirstName);
                    break;
                default:  // Name ascending 
                    employee = employee.OrderBy(s => s.FirstName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(employee.ToPagedList(pageNumber, pageSize));
        }
    }
}