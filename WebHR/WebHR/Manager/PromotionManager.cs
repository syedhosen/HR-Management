using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHR.Gateway;
using WebHR.Models;

namespace WebHR.Manager
{
    public class PromotionManager : IPromotion
    {
        
        PromotionGateway promotionGateway = new PromotionGateway();

        public int Save(Promotion promotion)
        {
            return promotionGateway.Save(promotion);
        }

        public List<Promotion> GetAll()
        {
            return promotionGateway.GetAll();
        }

        // Implementing IPromotion interface
        public void UpPromotion()
        {
            
        }

        public void DryPromotion()
        {
            
        }

        public void PaperPromotion()
        {
            
        }
    }
}