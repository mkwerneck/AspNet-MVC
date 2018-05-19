using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogWeb.Infra
{
    public class ConnectionFactory
    {
        public static IDbConnection CriaConexaoAberta()
        {
            var connString = ConfigurationManager.ConnectionStrings["blog"].ConnectionString;
            var cnx = new SqlConnection(connString);
            cnx.Open();
            return cnx;
        }
    }
}