using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCRTasksTool.AppCode;

namespace DCRTasksTool
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            //RoundButton start = new RoundButton();
            //start.Name = "rb1";
            //start.Location = new System.Drawing.Point(50, 100);
            //start.Size = new System.Drawing.Size(50, 50);
            //start.BackColor = System.Drawing.Color.Green;
            //this.Controls.Add(start);
        }



        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginCall();
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginCall();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void LoginCall()
        {
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;
            if (string.IsNullOrWhiteSpace(userName) == true || string.IsNullOrWhiteSpace(password) == true)
            {
                MessageBox.Show("Username or Password cannot be empty, please eneter both");
                textBoxPassword.Text = "";
                if (string.IsNullOrWhiteSpace(userName) == true)
                {
                    textBoxUserName.Focus();
                }
                else
                {
                    textBoxPassword.Focus();
                }
            }
            else
            {
                string error = string.Empty;
                bool access = FunctionalityFromRepository.GetAccess(userName, password,ref error);
                if (access)
                {
                    CommonSetting.UserName = userName;
                    CommonSetting.Password = password;
                    this.Hide();
                    var choice = new Choice();
                    choice.Closed += (s, args) => this.Close();
                    choice.Show();
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(error) == true)
                    {
                        MessageBox.Show("Username or Password is not correct , please try again");
                        
                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                    textBoxPassword.Text = "";

                }
            }
        }
    }
}
