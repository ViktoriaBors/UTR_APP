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
using UTR_APP.Forms;

namespace UTR_APP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
           
            this.Hide();
            LoginForm ablak = new LoginForm();
            if (ablak.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
         
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            DesignStatic.PB_Enter(sender as PictureBox);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            DesignStatic.PB_Leave(sender as PictureBox);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // save the employee data changes to database
               FunctionResult savingData = DatabaseHandlerClass.Update_EmployeeData(form.passwordChanged, StaticDataClass.loggedInUser, false);
                if (!savingData.Result)
                {
                    MessageBox.Show(savingData.Message,"Error with saving data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new NewEmployeeForm()).ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        { // remember delete saved logged in user before
            this.Hide();
            LoginForm ablak = new LoginForm();
            if (ablak.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }
    }
}
