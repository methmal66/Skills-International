using System;
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
            usernameBox.Clear();
            passwordBox.Clear();
        }
        private void loginBtn_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.username = usernameBox.Text;
            user.password = passwordBox.Text;

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
