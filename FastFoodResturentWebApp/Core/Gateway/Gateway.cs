using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FastFoodResturentWebApp.Core.Gateway
{
    public class Gateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["FastFoodResturentConnection"].ConnectionString;
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }
 
        public Gateway()
        {
           Connection=new SqlConnection(connectionString);
            Command=new SqlCommand();
            Command.Connection = Connection;
        }
    }
}