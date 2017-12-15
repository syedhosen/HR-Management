using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHR.Gateway;
using WebHR.Models;

namespace WebHR.Manager
{
    public class AchievementManager
    {
        AchievementGateway achievementGateway = new AchievementGateway();

        public int Save(Achievement achievement)
        {
            return achievementGateway.Save(achievement);
        }
        public List<Achievement> GetAll()
        {
            return achievementGateway.GetAll();
        } 
    }
}