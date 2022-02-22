using System;
using System.Data.SqlClient;

namespace Skills_International
{
    internal class Student
    {
        public int regNo;
        public string firstName;
        public string lastName;
        public DateTime dateOfBirth;
        public string gender;
        public string address;
        public string email;
        public string mobilePhone;
        public string homePhone;
        public string parentName;
        public string nic;
        public string contactNo;

        public bool register()
        {
            DB db = new DB();
            string sql = "INSERT INTO Registration VALUES(" +
                "" + regNo + ", '"+firstName+"', '"+lastName+"', '"+dateOfBirth+"', '"+gender+"', " +
                "'"+address+"', '"+email+"', '"+mobilePhone+"', '"+homePhone+"', '"+parentName+"', '"+nic+"', '"+contactNo+"'" +
                ")";
            bool status = db.execute(sql);
            db.close();
            return status;
        }

        public bool update()
        {
            DB db = new DB();
            string sql = "UPDATE Registration SET " +
                "firstName='" + firstName + "', lastName='" + lastName + "', dateOfBirth='" + dateOfBirth + "'," +
                " gender='" + gender + "', address='" + address + "', email='" + email + "', mobilePhone='" + mobilePhone + "'," +
                " homePhone='" + homePhone + "', parentName='" + parentName + "', nic='" + nic + "', contactNo='" + contactNo + "'" +
                " WHERE regNo ="+regNo;
            bool status = db.execute(sql);
            db.close();
            return status;
        }

        public bool delete()
        {
            DB db = new DB();
            string sql = "DELETE FROM Registration WHERE regNo=" + regNo;
            bool status = db.execute(sql);
            db.close();
            return status;
        }

        public static SqlDataReader findAllRegNo()
        {
            DB dB = new DB();
            string sql = "SELECT regNo from Registration";
            SqlDataReader reader = dB.query(sql);
            return reader;
        }
    }
}
