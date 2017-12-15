using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHR.Manager
{
    public abstract class EmployeeSalaryManager
    {
        public abstract double CalculateSalary(double salary);
    }

    public class PermanentEmployeeSalary : EmployeeSalaryManager
    {
        public override double CalculateSalary(double salary)
        {
            return salary;
        }
    }

    public class ContractualEmployeeSalary : EmployeeSalaryManager
    {
        public override double CalculateSalary(double salary)
        {
            return salary;
        }
    }
}