using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebHR.Models;

namespace WebHR.Gateway
{
    public class AchievementGateway : CommonGateway
    {
        public int Save(Achievement achievement)
        {
            Query = "INSERT INTO Achievement(EmployeeName,ForwardApplicationTo,AchievementTitle,AchievementDate)" +
                    " VALUES(@EmployeeName,@ForwardApplicationTo,@AchievementTitle,@AchievementDate)";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("EmployeeName", SqlDbType.VarChar);
            Command.Parameters["EmployeeName"].Value = achievement.EmployeeName;

            Command.Parameters.Add("ForwardApplicationTo", SqlDbType.VarChar);
            Command.Parameters["ForwardApplicationTo"].Value = achievement.ForwardApplicationTo;

            Command.Parameters.Add("AchievementTitle", SqlDbType.VarChar);
            Command.Parameters["AchievementTitle"].Value = achievement.AchievementTitle;

            Command.Parameters.Add("AchievementDate", SqlDbType.Date);
            Command.Parameters["AchievementDate"].Value = achievement.AchievementDate;

            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<Achievement> GetAll()
        {
            Query = "SELECT EmployeeName, ForwardApplicationTo, AchievementTitle, AchievementDate FROM Achievement";
            SqlCommand Command = new SqlCommand(Query, Connection);
            List<Achievement> achievementList = new List<Achievement>();
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                Achievement achievement = new Achievement();

                achievement.EmployeeName = reader["EmployeeName"].ToString();
                achievement.ForwardApplicationTo = reader["ForwardApplicationTo"].ToString();
                achievement.AchievementTitle = reader["AchievementTitle"].ToString();
                achievement.AchievementDate = Convert.ToDateTime(reader["AchievementDate"].ToString());
                achievementList.Add(achievement);
            }

            reader.Close();
            return achievementList;
        }
    }
}