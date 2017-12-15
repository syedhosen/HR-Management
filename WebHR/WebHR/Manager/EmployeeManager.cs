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

        // Enamouration
        public enum Category
        {
            Permanent,
            Contractual,
            Temporary
        }

        public double CalculateBonus(double amount,Category category)
        {
            // Enamouration value
            if (category == Category.Permanent)
            {
                amount = amount + amount*.5;
            }
            else if (category == Category.Contractual)
            {
                amount = amount + amount*.3;
            }
            else if (category == Category.Temporary)
            {
                amount = amount + amount*.2;
            }
            return amount;
        }

    }
}