using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTR_APP.Classes;

namespace UTR_APP.Forms
{
    public partial class LoginForm : Form
    {
        // need user class - save all the user information in that and here as a prop and give it to the main form - so it can be checked adn fill up all data
        public LoginForm()
        {
            InitializeComponent();
            label3.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FunctionResult UserLogin = DatabaseHandlerClass.UserExists(textBox1.Text);
            if (!UserLogin.Result)
            {
                label3.Text = UserLogin.Message;
                return;
            }

            UserLogin = DatabaseHandlerClass.PasswordMatches(textBox1.Text, textBox2.Text);
            if (!UserLogin.Result)
            {
                label3.Text = UserLogin.Message;
                return;
            }

            if (UserLogin.Result)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }        

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }
    }
}
