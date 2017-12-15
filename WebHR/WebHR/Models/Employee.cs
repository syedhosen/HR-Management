using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebHR.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string StationName { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeType { get; set; }
        public string EmployeeCategory { get; set; }
        public string Designation { get; set; }
        public string WorkShift { get; set; }
        public string Grade { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int GetEmployeeId()
        {
            return Id;
        }
    }
}