using System;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Skills_International
{
    internal class User
    {
        public string username;
        public string password;

        public bool login()
        {
            DB db = new DB();
            string sql = "SELECT * FROM Users WHERE username='" + username + "'";
            SqlDataReader reader = db.query(sql);
            if (reader.Read())
            {
                SHA1 sha1Hash = SHA1.Create();
                byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-",String.Empty);
                if(hash == (string)reader["password"])
                {
                    db.close();
                    return true;
                }
                db.close();
                return false;
            }
            db.close();
            return false;
        }   
    }
}
