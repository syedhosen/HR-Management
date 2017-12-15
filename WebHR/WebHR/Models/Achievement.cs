using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebHR.Models
{
    public class Achievement
    {
        public int Id { set; get; }
        public string EmployeeName { set; get; }
        public string ForwardApplicationTo { set; get; }
        public string AchievementTitle { set; get; }
        public DateTime AchievementDate { set; get; }
    }
}