using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Skills_International
{
    internal class User
    {
        string username;
        string password;

        public User setUserName(string x)
        {
            username = x;
            return this;
        }

        public User setPassword(string x)
        {
            password = x;
            return this;
        }
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
