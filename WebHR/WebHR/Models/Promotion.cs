using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHR.Models
{
    public class Promotion
    {
        public int Id { set; get; }
        public string PromotionFor { set; get; }
        public string ForwardApplicationTo { set; get; }
        public string PromotionTitle { set; get; }
        public DateTime PromotionDate { set; get; }
    }
}