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
    public partial class SettingsForm : Form
    {
        bool hidePassword1, hidePassword2, hidePassword3 = true;
        public bool passwordChanged = false;
        public SettingsForm()
        {
            InitializeComponent();
            Fill_Up_UserData();
        }

        private void Fill_Up_UserData()
        {
            errorLbl.Text = string.Empty;
            fullNameTB.Text = StaticDataClass.loggedInUser.Name;
            adressTB.Text = StaticDataClass.loggedInUser.Address;
            emailTB.Text = StaticDataClass.loggedInUser.Email;
            emplyeeIDTB.Text = StaticDataClass.loggedInUser.EmployeeID;
            emplTypeCB.DataSource = new BindingSource(StaticDataClass.employmentTypes, null);
            if (StaticDataClass.employmentTypes.Count > 0)
            {
                emplTypeCB.DisplayMember = "Value"; // selectedvalue going to use the ID
                emplTypeCB.ValueMember = "Key";
            }
            emplTypeCB.SelectedValue = StaticDataClass.loggedInUser.EmploymentId;

            departmentCB.DataSource = new BindingSource(StaticDataClass.departmentTypes, null);
            if (StaticDataClass.departmentTypes.Count > 0)
            {
                departmentCB.DisplayMember = "Value";
                departmentCB.ValueMember = "Key";
            }
            departmentCB.SelectedValue = StaticDataClass.loggedInUser.DeparmentId;

            weeklyNotCheckB.Checked = StaticDataClass.loggedInUser.NotificationOn;
            periodRB.Checked = StaticDataClass.loggedInUser.TimeRegTypeId == 1;
            sumRB.Checked = StaticDataClass.loggedInUser.TimeRegTypeId == 2;

            currentPwdTB.Text = StaticDataClass.loggedInUser.Password;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            hidePassword1 = !hidePassword1;
            pictureBox1.Image = hidePassword1 ? Resources.view : Resources.hide;
            currentPwdTB.UseSystemPasswordChar = hidePassword1;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (newPwd1TB.Text.Length > 0 && newPwd2TB.Text.Length > 0)
            {
                if (newPwd1TB.Text == newPwd2TB.Text)
                {
                    try
                    {
                        StaticDataClass.loggedInUser.Password = newPwd1TB.Text;
                        passwordChanged = true;
                    }
                    catch (Exception ex)
                    {
                        errorLbl.Text = ex.Message;
                        return;
                    }
                }
                else
                {
                    errorLbl.Text = "The new passwords are not the same.";
                    return;
                }
            }

            if (weeklyNotCheckB.Checked && emailTB.Text == string.Empty)
            {
                errorLbl.Text = "Email must be provided for weekly notification.";
                return;
            }


            try
            {
                StaticDataClass.loggedInUser.Name = fullNameTB.Text;
                StaticDataClass.loggedInUser.Address = adressTB.Text;
                StaticDataClass.loggedInUser.Email = emailTB.Text;
                StaticDataClass.loggedInUser.NotificationOn = weeklyNotCheckB.Checked;                
                StaticDataClass.loggedInUser.TimeRegTypeId = periodRB.Checked ? 1 : 2;

            }
            catch (Exception ex)
            {
                errorLbl.Text = ex.Message;
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            hidePassword2 = !hidePassword2;
            pictureBox2.Image = hidePassword2 ? Resources.view : Resources.hide;
            newPwd1TB.UseSystemPasswordChar = hidePassword2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            hidePassword3 = !hidePassword3;
            pictureBox3.Image = hidePassword3 ? Resources.view : Resources.hide;
            newPwd2TB.UseSystemPasswordChar = hidePassword3;
        }
    }
}
