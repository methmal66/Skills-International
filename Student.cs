using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skills_International
{
    internal class Student
    {
        int _regNo;
        string _firstName;
        string _lastName;
        DateTime _dateOfBirth;
        string _gender;
        string _address;
        string _email;
        string _mobilePhone;
        string _homePhone;
        string _parentName;
        string _nic;
        string _contactNo;

        public Student regNo(int x)
        {
            _regNo = x;
            return this;
        }

        public Student setFirstName(string x)
        {
            _firstName = x;
            return this;
        }

        public Student lastName(string x)
        {
            _lastName = x;
            return this;
        }

        public Student dateOfBirth(DateTime x)
        {
            _dateOfBirth = x;
            return this;
        }

        public Student gender(string x)
        {
            _gender = x;
            return this;
        }

        public Student address(string x)
        {
            _address = x;
            return this;
        }

        public Student email(string x)
        {
            _email = x;
            return this;
        }

        public Student mobilePhone(string x)
        {
            _mobilePhone = x;
            return this;
        }

        public Student homePhone(string x)
        {
            _homePhone = x;
            return this;
        }

        public Student parentName(string x)
        {
            _parentName = x;
            return this;
        }

        public Student nic(string x)
        {
            _nic = x;
            return this;
        }

        public Student contactNo(string x)
        {
            _contactNo = x;
            return this;
        }

        public bool register()
        {
            DB db = new DB();
            string sql = "INSERT INTO Registration VALUES(" +
                "" + _regNo + ", '"+_firstName+"', '"+_lastName+"', '"+_dateOfBirth+"', '"+_gender+"', " +
                "'"+_address+"', '"+_email+"', '"+_mobilePhone+"', '"+_homePhone+"', '"+_parentName+"', '"+_nic+"', '"+_contactNo+"'" +
                ")";
            bool status = db.execute(sql);
            db.close();
            return status;
        }

        public bool update()
        {
            DB db = new DB();
            string sql = "UPDATE Registration SET " +
                "firstName='" + _firstName + "', lastName='" + _lastName + "', dateOfBirth='" + _dateOfBirth + "'," +
                " gender='" + _gender + "', address='" + _address + "', email='" + _email + "', mobilePhone='" + _mobilePhone + "'," +
                " homePhone='" + _homePhone + "', parentName='" + _parentName + "', nic='" + _nic + "', contactNo='" + _contactNo + "'" +
                " WHERE regNo ="+_regNo;
            bool status = db.execute(sql);
            db.close();
            return status;
        }

        public bool delete()
        {
            DB db = new DB();
            string sql = "DELETE FROM Registration WHERE regNo=" + _regNo;
            bool status = db.execute(sql);
            db.close();
            return status;
        }
    }
}
