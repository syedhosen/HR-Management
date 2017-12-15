using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHR.Gateway;
using WebHR.Models;

namespace WebHR.Manager
{
    public class EmployeeManager
    {
        EmployeeGateway employeeGateway = new EmployeeGateway();

        public int Save(Employee employee)
        {
            return employeeGateway.Save(employee);
        }
        public List<Employee> GetAll()
        {
            return employeeGateway.GetAll();
        }

        public enum EmployeeCategory
        {
            Permanent,
            Contractual,
            Temporary
        }

        public double CalculateBonus(double amount,EmployeeCategory employeeCategory)
        {
            if (employeeCategory == EmployeeCategory.Permanent)
            {
                amount = amount + amount*.5;
            }
            else if (employeeCategory == EmployeeCategory.Contractual)
            {
                amount = amount + amount*.3;
            }
            else if (employeeCategory == EmployeeCategory.Temporary)
            {
                amount = amount + amount*.2;
            }
            return amount;
        }

    }
}