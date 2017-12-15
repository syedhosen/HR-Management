using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebHR.Models;

namespace WebHR.Gateway
{
    public class PromotionGateway : CommonGateway
    {
        public int Save(Promotion promotion)
        {
            Query = "INSERT INTO Promotion(PromotionFor,ForwardApplicationTo,PromotionTitle,PromotionDate)" +
                    " VALUES(@PromotionFor,@ForwardApplicationTo,@PromotionTitle,@PromotionDate)";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("PromotionFor", SqlDbType.VarChar);
            Command.Parameters["PromotionFor"].Value = promotion.PromotionFor;

            Command.Parameters.Add("ForwardApplicationTo", SqlDbType.VarChar);
            Command.Parameters["ForwardApplicationTo"].Value = promotion.ForwardApplicationTo;

            Command.Parameters.Add("PromotionTitle", SqlDbType.VarChar);
            Command.Parameters["PromotionTitle"].Value = promotion.PromotionTitle;

            Command.Parameters.Add("PromotionDate", SqlDbType.Date);
            Command.Parameters["PromotionDate"].Value = promotion.PromotionDate;

            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<Promotion> GetAll()
        {
            Query = "SELECT PromotionFor, ForwardApplicationTo, PromotionTitle, PromotionDate FROM Promotion";
            SqlCommand Command = new SqlCommand(Query, Connection);
            List<Promotion> promotionList = new List<Promotion>();
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                Promotion promotion = new Promotion();

                promotion.PromotionFor = reader["PromotionFor"].ToString();
                promotion.ForwardApplicationTo = reader["ForwardApplicationTo"].ToString();
                promotion.PromotionTitle = reader["PromotionTitle"].ToString();
                promotion.PromotionDate = Convert.ToDateTime(reader["PromotionDate"].ToString());
                promotionList.Add(promotion);
            }

            reader.Close();
            return promotionList;
        }
    }
}