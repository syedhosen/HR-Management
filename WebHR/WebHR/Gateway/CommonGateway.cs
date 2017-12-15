using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebHR.Gateway
{
    public class CommonGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["WebHR"].ConnectionString;
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public string Query { get; set; }

        public CommonGateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}