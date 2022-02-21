using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Skills_International
{
    internal class DB
    {
        string connectionString;
        SqlConnection con;
        public DB()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[1].ToString();
            con = new SqlConnection(connectionString);
        }

        public void close()
        {
            con.Close();
        }

        public void execute(string sql)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader query(string sql)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
