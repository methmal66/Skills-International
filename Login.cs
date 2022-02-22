using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skills_International
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void clearForm()
        {
            username.Clear();
            password.Clear();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
           
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            User user = new User();
            user
                .userName(username.Text)
                .password(password.Text);

            if (user.login())
            {
                Register register = new Register();
                register.Show();
                this.Hide();
                return;
            }

            string message = "Invalid Login credentials, please check Username and Password and try again";
            string caption = "Invalid login Details";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (result == DialogResult.OK)
                clearForm();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}
