using System;
using System.Windows.Forms;

namespace Skills_International
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void clearForm()
        {
            regNoBox.Clear();
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

        private void registerBtn_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.regNo = int.Parse(regNoBox.Text);
            student.firstName = firstNameBox.Text;
            student.lastName = lastNameBox.Text;
            student.dateOfBirth = dateOfBirthBox.Value;
            student.gender = maleBtn.Checked ? "Male" : femaleBtn.Checked ? "Female" : "Not provided";
            student.address = addressBox.Text;
            student.email = emailBox.Text;
            student.mobilePhone = mobilePhoneBox.Text;
            student.homePhone = homePhoneBox.Text;
            student.parentName = parentNameBox.Text;
            student.nic = nicBox.Text;
            student.contactNo = contactNoBox.Text;

            string caption = "Register Student";
            string message;
            MessageBoxIcon icon;
            if (student.register())
            {
                message = "Record Added Successfully";
                icon = MessageBoxIcon.Information;
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
                if (result == DialogResult.OK)
                    clearForm();
            }
            else
            {
                message = "Failed to add record";
                icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
                
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}
