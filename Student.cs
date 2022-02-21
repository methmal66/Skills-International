using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skills_International
{
    internal class Student
    {
        int regNo;
        string firstName;
        string lastName;
        DateTime dateOfBirth;
        string gender;
        string address;
        string email;
        string mobilePhone;
        string homePhone;
        string parentName;
        string nic;
        string contactNo;

        public Student setRegNo(int x)
        {
            regNo = x;
            return this;
        }

        public Student setFirstName(string x)
        {
            firstName = x;
            return this;
        }

        public Student setLastName(string x)
        {
            lastName = x;
            return this;
        }

        public Student setDateOfBirth(DateTime x)
        {
            dateOfBirth = x;
            return this;
        }

        public Student setGender(string x)
        {
            gender = x;
            return this;
        }

        public Student setAddress(string x)
        {
            address = x;
            return this;
        }

        public Student setEmail(string x)
        {
            email = x;
            return this;
        }

        public Student setMobilePhone(string x)
        {
            mobilePhone = x;
            return this;
        }

        public Student setHomePhone(string x)
        {
            homePhone = x;
            return this;
        }

        public Student setParentName(string x)
        {
            parentName = x;
            return this;
        }

        public Student setNic(string x)
        {
            nic = x;
            return this;
        }

        public Student setContactNo(string x)
        {
            contactNo = x;
            return this;
        }

        public void register()
        {
            DB db = new DB();
            string sql = "INSERT INTO Registration VALUES(" +
                "" + regNo + ", '"+firstName+"', '"+lastName+"', '"+dateOfBirth+"', '"+gender+"', " +
                "'"+address+"', '"+email+"', '"+mobilePhone+"', '"+homePhone+"', '"+parentName+"', '"+nic+"', '"+contactNo+"'" +
                ")";
            db.execute(sql);
            db.close();
        }

        public void update()
        {
            DB db = new DB();
            string sql = "UPDATE Registration SET " +
                "firstName='" + firstName + "', lastName='" + lastName + "', dateOfBirth='" + dateOfBirth + "'," +
                " gender='" + gender + "', address='" + address + "', email='" + email + "', mobilePhone='" + mobilePhone + "'," +
                " homePhone='" + homePhone + "', parentName='" + parentName + "', nic='" + nic + "', contactNo='" + contactNo + "'" +
                " WHERE regNo ="+regNo;
            db.execute(sql);
            db.close();
        }

        public void delete()
        {
            DB db = new DB();
            string sql = "DELETE FROM Registration WHERE regNo=" + regNo;
            db.execute(sql);
            db.close();
        }
    }
}
