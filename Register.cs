using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Skills_International
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            SqlDataReader reader = Student.findAllRegNo();
            while (reader.Read())
                regNoBox.Items.Add(reader.GetInt32(0).ToString());
        }

        private void clearForm()
        {
            regNoBox.Items.Clear();
            SqlDataReader reader = Student.findAllRegNo();
            while (reader.Read())
                regNoBox.Items.Add(reader.GetInt32(0).ToString());

            firstNameBox.Clear();
            lastNameBox.Clear();
            dateOfBirthBox.Value = DateTime.Now;
            maleBtn.Checked = false;
            femaleBtn.Checked = false;
            addressBox.Clear();
            emailBox.Clear();
            mobilePhoneBox.Clear();
            homePhoneBox.Clear();
            parentNameBox.Clear();
            nicBox.Clear();
            contactNoBox.Clear();
        }

        private Student getFieldValues(Student s)
        {
            s.regNo = int.Parse(regNoBox.Text);
            s.firstName = firstNameBox.Text;
            s.lastName = lastNameBox.Text;
            s.dateOfBirth = dateOfBirthBox.Value;
            s.gender = maleBtn.Checked ? "Male" : femaleBtn.Checked ? "Female" : "Not provided";
            s.address = addressBox.Text;
            s.email = emailBox.Text;
            s.mobilePhone = mobilePhoneBox.Text;
            s.homePhone = homePhoneBox.Text;
            s.parentName = parentNameBox.Text;
            s.nic = nicBox.Text;
            s.contactNo = contactNoBox.Text;
            return s;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            Student student = getFieldValues(new Student());
            string caption = "Register Student";
            MessageBoxIcon icon;

            if (student.register())
            {
                string message = "Record Added Successfully";
                icon = MessageBoxIcon.Information;
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
                if (result == DialogResult.OK)
                    clearForm();
            }
            else
            {
                string message = "Failed to add record";
                icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
                
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Student student = getFieldValues(new Student());
            string message = "Are you sure, Do you really want to Delete this Record...?";
            string caption = "Delete Student";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                if (student.delete())
                {
                    message = "Record Deleted Successfully";
                    result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                        clearForm();
                    return;
                }

                message = "Failed to delete the record";
                MessageBox.Show(message,caption,MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            message = "Record was not deleted";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            Student student = getFieldValues(new Student());
            string caption = "Update Student";
            string message;

            if (student.update())
            {
                message = "Record Updated Successfully";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(result == DialogResult.OK)
                    clearForm();
                return;
            }

            message = "Failed to update record";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
           

        }

        private void exitBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string caption = "Exit";
            string message = "Are you sure, Do you really want to Exit...?";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
                Application.Exit();
        }

        private void logoutBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string caption = "Logot";
            string message = "Are you sure, Do you really want to Logout...?";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }
    }
}
