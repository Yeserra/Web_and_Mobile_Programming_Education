using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManualQuery.Connection
{
    public class DbConnect
    {
        static SqlConnection con;
        public static SqlConnection GetConnection()
        {
            if (con == null)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            }
            return con;
        }
    }
}
