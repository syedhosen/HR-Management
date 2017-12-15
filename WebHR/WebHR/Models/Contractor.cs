using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHR.Models
{
    public class Contractor : Employee
    {
        public int contractDuration { set; get; }

        public int ContractDuration()
        {
            return contractDuration;
        }

        public int GetEmployeeId()
        {
            return Id;
        }
    }
}