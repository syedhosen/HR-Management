using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebHR.Models;

namespace WebHR.Gateway
{
    public class TransferGateway : CommonGateway
    {
        public int Save(Transfer transfer)
        {
            Query = "INSERT INTO Transfer(EmployeeToTransfer,ForwardApplicationTo,TransferDate,TransferToDepartment,TransferToStation)" +
                    " VALUES(@EmployeeToTransfer,@ForwardApplicationTo,@TransferDate,@TransferToDepartment,@TransferToStation)";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("EmployeeToTransfer", SqlDbType.VarChar);
            Command.Parameters["EmployeeToTransfer"].Value = transfer.EmployeeToTransfer;

            Command.Parameters.Add("ForwardApplicationTo", SqlDbType.VarChar);
            Command.Parameters["ForwardApplicationTo"].Value = transfer.ForwardApplicationTo;

            Command.Parameters.Add("TransferDate", SqlDbType.Date);
            Command.Parameters["TransferDate"].Value = transfer.TransferDate;

            Command.Parameters.Add("TransferToDepartment", SqlDbType.VarChar);
            Command.Parameters["TransferToDepartment"].Value = transfer.TransferToDepartment;

            Command.Parameters.Add("TransferToStation", SqlDbType.VarChar);
            Command.Parameters["TransferToStation"].Value = transfer.TransferToStation;

            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<Transfer> GetAll()
        {
            Query = "SELECT EmployeeToTransfer, ForwardApplicationTo, TransferDate, TransferToDepartment, TransferToStation FROM Transfer";
            SqlCommand Command = new SqlCommand(Query, Connection);
            List<Transfer> transferList = new List<Transfer>();
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                Transfer transfer = new Transfer();

                transfer.EmployeeToTransfer = reader["EmployeeToTransfer"].ToString();
                transfer.ForwardApplicationTo = reader["ForwardApplicationTo"].ToString();
                transfer.TransferDate = Convert.ToDateTime(reader["TransferDate"].ToString());
                transfer.TransferToDepartment = reader["TransferToDepartment"].ToString();
                transfer.TransferToStation = reader["TransferToStation"].ToString();
                transferList.Add(transfer);
            }

            reader.Close();
            return transferList;
        }
    }
}