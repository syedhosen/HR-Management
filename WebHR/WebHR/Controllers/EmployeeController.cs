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
        public ActionResult Create(Employee employee)
        {
           /* if (string.IsNullOrEmpty(employee.CompanyName))
            {
                ModelState.AddModelError("ComapnyName", "Comapny name is required:...");
            }

            if (string.IsNullOrEmpty(employee.StationName))
            {
                ModelState.AddModelError("StationName", "Employee station name is required:...");
            }

            if (string.IsNullOrEmpty(employee.DepartmentName))
            {
                ModelState.AddModelError("DepartmentName", "Employee department name is required:...");
            }

            if (string.IsNullOrEmpty(employee.EmployeeType))
            {
                ModelState.AddModelError("EmployeeType", "Employee type is required:...");
            }

            if (string.IsNullOrEmpty(employee.EmployeeCategory))
            {
                ModelState.AddModelError("EmployeeCategory", "Employee category is required:...");
            }

            if (string.IsNullOrEmpty(employee.Designation))
            {
                ModelState.AddModelError("Designation", "Employee designation is required:...");
            }

            if (string.IsNullOrEmpty(employee.WorkShift))
            {
                ModelState.AddModelError("WorkShift", "Employee work shift is required:...");
            }

            if (string.IsNullOrEmpty(employee.Grade))
            {
                ModelState.AddModelError("Grade", "Employee grade is required:...");
            }

            if (string.IsNullOrEmpty(employee.FirstName))
            {
                ModelState.AddModelError("FirstName", "Employee first name is required:...");
            }

            if (string.IsNullOrEmpty(employee.LastName))
            {
                ModelState.AddModelError("LastName", "Employee last name is required:...");
            }

            if (string.IsNullOrEmpty(employee.Username))
            {
                ModelState.AddModelError("Username", "Employee username is required:...");
            }

            if (string.IsNullOrEmpty(employee.Password))
            {
                ModelState.AddModelError("Password", "Employee password is required:...");
            }*/

            if (ModelState.IsValid)
            {
                ViewBag.Msg = employeeManager.Save(employee) > 0 ? "Saved Succesfully" : "Save Failed";
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