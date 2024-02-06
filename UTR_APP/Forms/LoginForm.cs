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
using UTR_APP.Properties;

namespace UTR_APP.Forms
{
    public partial class LoginForm : Form
    {
        bool hidePassword = true;
        
        public LoginForm()
        {
            InitializeComponent();
            label3.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            hidePassword = !hidePassword;
            pictureBox2.Image = hidePassword ? Resources.view : Resources.hide;
            textBox2.UseSystemPasswordChar = hidePassword;
        }

        private void Login()
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }
    }
}
