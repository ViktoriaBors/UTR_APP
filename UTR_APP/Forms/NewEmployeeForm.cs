using MySqlX.XDevAPI.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTR_APP.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UTR_APP.Forms
{
    public partial class NewEmployeeForm : Form
    {
        public NewEmployeeForm()
        {
            InitializeComponent();
            errorLbl.Text = string.Empty;

            ComboBox_Data_Upload();

        }

        private void ComboBox_Data_Upload()
        {
            emplTypeCB.DataSource = null;
            emplTypeCB.DataSource = new BindingSource(StaticDataClass.employmentTypes, null);
            if (StaticDataClass.employmentTypes.Count > 0)
            {
                emplTypeCB.DisplayMember = "Value"; // selectedvalue going to use the ID
                emplTypeCB.ValueMember = "Key";
            }

            departmentCB.DataSource = null;
            departmentCB.DataSource = new BindingSource(StaticDataClass.departmentTypes, null);
            if (StaticDataClass.departmentTypes.Count > 0)
            {
                departmentCB.DisplayMember = "Value";
                departmentCB.ValueMember = "Key";
            }


            roleTypesCB.DataSource = null;
            roleTypesCB.DataSource = new BindingSource(StaticDataClass.roleTypes, null);
            if (StaticDataClass.roleTypes.Count > 0)
            {
                roleTypesCB.DisplayMember = "Value";
                roleTypesCB.ValueMember = "Key";
            }
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            if (Full_Name_Valid())
            {
                emplyeeIDTB.Text = Generate_EmployeeID();
                passwordTB.Text = Generate_Password();
            } else
            {
                errorLbl.Text = "Full name is not valid (must be minimum 5 character and contain space)";
            }
        }

        private string Generate_Password()
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            char[] chars = new char[8];
            for (int i = 0; i < 8; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        private string Generate_EmployeeID()
        {
            string ID = string.Empty;

            string[] nameArray = fullNameTB.Text.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < nameArray.Length; i++)
            {
                ID += nameArray[i].Substring(0,2);
            }
            return ID;            
        }

        private bool Full_Name_Valid()
        {
            return fullNameTB.Text != string.Empty && fullNameTB.Text.Contains(' ') && fullNameTB.Text.Length >= 5;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               UserClass newUser = new UserClass(emplyeeIDTB.Text, passwordTB.Text, (int)roleTypesCB.SelectedValue, fullNameTB.Text, (int)departmentCB.SelectedValue, (int)emplTypeCB.SelectedValue);
                FunctionResult registerNewUser = DatabaseHandlerClass.RegistrationOfNewEmployee(newUser);
                if (registerNewUser.Result)
                {
                    DialogResult = DialogResult.OK;
                } else
                {
                    errorLbl.Text = "The new user could not be created because of the following: " + Environment.NewLine + registerNewUser.Message;
                }
            }
            catch (Exception ex)
            {
                errorLbl.Text = string.Empty;
                errorLbl.Text = "The new user could not be created because of the following: " + Environment.NewLine + ex.Message;
            }


        }
    }
}
