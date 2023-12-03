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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            form.ShowDialog();
        }
    }
}
