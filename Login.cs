using System;
using System.Windows.Forms;

namespace Parking
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void PictureExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                if (UNameTb.Text == "Admin" && PasswordTb.Text == "Admin")
                {
                    Cars obj = new Cars();
                    obj.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Wrong UserName or Password!!");
                    UNameTb.Text = "";
                    PasswordTb.Text = "";
                }
            }
        }
    }
}
