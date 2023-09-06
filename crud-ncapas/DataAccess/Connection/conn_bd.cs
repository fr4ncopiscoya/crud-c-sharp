using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Connection
{
    public class conn_bd
    {
        private SqlConnection conn = new SqlConnection("Data Source=Admin\\SQLEXPRESS;Initial Catalog=crud-ncapas;Integrated Security=True");
        
        public SqlConnection OpenConnection()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            return conn;
        }

        public SqlConnection CloseConnection()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            return conn;
        }
    }
}
