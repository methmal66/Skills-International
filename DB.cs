using System;
using System.Data.SqlClient;

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

        public bool execute(string sql)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (cmd.ExecuteNonQuery() == 1)
                return true;
            return false;
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
