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
    public partial class Dashboard : Form
    {

        int MAX_PANEL_WIDTH, MIN_PANEL_WIDTH;
        bool panelHidden;
        Login login;
        Register register; 

        public Dashboard()
        {
            InitializeComponent();
            MAX_PANEL_WIDTH = 120;
            MIN_PANEL_WIDTH = 0;
            dynamicPanel.Width = MIN_PANEL_WIDTH;
            register = new Register();
            switchBtn.Text = ">>";
            panelHidden = true;
        }

        private void expandPanel()
        {
            if (dynamicPanel.Width < MAX_PANEL_WIDTH)
            {
                dynamicPanel.Width = MAX_PANEL_WIDTH;
                this.Refresh();
            }
            panelHidden = false;
            switchBtn.Text = "<<";
        }

        private void constractPanel()
        {
            if (dynamicPanel.Width >= MAX_PANEL_WIDTH)
            {
                dynamicPanel.Width = MIN_PANEL_WIDTH;
                this.Refresh();
            }
            panelHidden = true;
            switchBtn.Text = ">>";
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            login = new Login();
            login.Show();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
           register = new Register();
           register.Show();   
        }

        private void switchBtn_Click(object sender, EventArgs e)
        {
            if (panelHidden)
            {
                expandPanel();
                return;
            }
            constractPanel();
        }
    }
}
