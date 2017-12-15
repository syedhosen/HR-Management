using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHR.Models
{
    public class Transfer
    {
        public int Id { set; get; }
        public string EmployeeToTransfer { set; get; }
        public string ForwardApplicationTo { set; get; }
        public DateTime TransferDate { set; get; }
        public string TransferToDepartment { set; get; }
        public string TransferToStation { set; get; }
    }
}