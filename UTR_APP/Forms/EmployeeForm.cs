using System;
using System.Linq;
using System.Windows.Forms;
using UTR_APP.Classes;

namespace UTR_APP.Forms
{
    public partial class EmployeeForm : Form
    {
        bool forgottenPassword = false;
        public UserClass User { get; private set; }
        public EmployeeForm() // new employee
        {
            InitializeComponent();
            this.Text = "Add new employee";
            errorLbl.Text = string.Empty;
            deleteBtn.Enabled = false;
            deleteBtn.Visible = false;
            ComboBox_Data_Upload();
        }

        public EmployeeForm(UserClass user) // existed employee
        {
            InitializeComponent();
            errorLbl.Text = string.Empty;
            User = user;
            this.Text = "Modify employee: " + User.Name;
            ComboBox_Data_Upload();
            UI_Update();
        }

        private void UI_Update()
        {
            emplTypeCB.SelectedValue = User.EmploymentId;
            departmentCB.SelectedValue = User.DeparmentId;
            roleTypesCB.SelectedValue = User.RoleId;
            fullNameTB.Text = User.Name;
            fullNameTB.Enabled = false;           
            emplyeeIDTB.Text = User.EmployeeID;
            emplyeeIDTB.Enabled = false;
            passwordTB.Enabled = false;
            passwordTB.Text = string.Empty;
            generateBtn.Enabled = false;
            numericUpDown1.Value = (decimal)User.HoursFromPrevSystem;
            numericUpDown1.Enabled = false;
        }

        private void ComboBox_Data_Upload()
        {
            emplTypeCB.DataSource = null;
            emplTypeCB.DataSource = StaticDataClass.employmentTypes; // new BindingSource(StaticDataClass.employmentTypes, null);
            if (StaticDataClass.employmentTypes.Count > 0)
            {
                emplTypeCB.DisplayMember = "Name"; // selectedvalue going to use the ID
                emplTypeCB.ValueMember = "ID";
            }

            departmentCB.DataSource = null;
            departmentCB.DataSource = StaticDataClass.departmentTypes; // new BindingSource(StaticDataClass.departmentTypes, null);
            if (StaticDataClass.departmentTypes.Count > 0)
            {
                departmentCB.DisplayMember = "Name";
                departmentCB.ValueMember = "ID";
            }


            roleTypesCB.DataSource = null;
            roleTypesCB.DataSource = StaticDataClass.roleTypes; // new BindingSource(StaticDataClass.roleTypes, null);
            if (StaticDataClass.roleTypes.Count > 0)
            {
                roleTypesCB.DisplayMember = "Name";
                roleTypesCB.ValueMember = "ID";
            }
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            errorLbl.Text = string.Empty;
            if (Full_Name_Valid())
            {
                emplyeeIDTB.Text = Generate_EmployeeID();
                passwordTB.Text = Generate_Password();
                if (checkBox1.Checked)
                {
                    forgottenPassword = true;
                }
            } else
            {
                errorLbl.Text = "Full name is not valid (must be minimum 5 character and contain space)";
            }
        }

        private string Generate_Password()
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string validNum = "1234567890";
            string validSpecChar = "!@#$%^&*?_-";
            Random random = new Random();

            char[] chars = new char[8];
            for (int i = 0; i < 6; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            chars[6] = validNum[random.Next(0, validNum.Length)];
            chars[7] = validSpecChar[random.Next(0, validSpecChar.Length)];
            Console.WriteLine(chars.Length);
            return new string(chars);
        }

        private string Generate_EmployeeID()
        {
            string ID = string.Empty;

            string[] nameArray = fullNameTB.Text.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < nameArray.Length; i++)
            {
                if (nameArray[i].Length >= 2)
                {
                    ID += nameArray[i].Substring(0, 2);
                } else
                {
                    ID += nameArray[i].Substring(0, 1);
                }
                
            }
            return ID;            
        }

        private bool Full_Name_Valid()
        {
            return fullNameTB.Text != string.Empty && fullNameTB.Text.Contains(' ') && fullNameTB.Text.Length >= 5;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorLbl.Text = string.Empty;
            if (User == null) // new employee registration
            {
                try
                {
                    User = new UserClass(emplyeeIDTB.Text, passwordTB.Text, (int)roleTypesCB.SelectedValue, fullNameTB.Text, (int)departmentCB.SelectedValue, (int)emplTypeCB.SelectedValue, (float)numericUpDown1.Value);
                    FunctionResult existingEmplID = DatabaseHandlerClass.UserExists(emplyeeIDTB.Text);
                    if (existingEmplID.Result)
                    {
                        errorLbl.Text = "This employeeId is alredy exist. Add an extra charachter to the name field.";
                        return;
                    }

                    FunctionResult registerNewUser = DatabaseHandlerClass.RegistrationOfNewEmployee(User);
                    if (registerNewUser.Result)
                    {
                        StaticDataClass.users = DatabaseHandlerClass.AllUsers();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        errorLbl.Text = "The new user could not be created because of the following: " + Environment.NewLine + registerNewUser.Message;
                    }
                }
                catch (Exception ex)
                {
                    errorLbl.Text = string.Empty;
                    errorLbl.Text = "The new user could not be created because of the following: " + Environment.NewLine + ex.Message;
                }
            } else // a given employee data is changed
            {
                try
                {
                    User.DeparmentId = (int)departmentCB.SelectedValue;
                    User.EmploymentId = (int)emplTypeCB.SelectedValue;
                    User.RoleId = (int)roleTypesCB.SelectedValue;
                    User.Password = forgottenPassword ? passwordTB.Text : User.Password;

                    if (forgottenPassword && MessageBox.Show("Are you sure you want to change the employee´s password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        forgottenPassword = true;
                    } else
                    {
                        forgottenPassword = false;
                    }

                    FunctionResult updateUser = DatabaseHandlerClass.Update_EmployeeData(forgottenPassword, User, true);
                    if (updateUser.Result)
                    {
                        StaticDataClass.users = DatabaseHandlerClass.AllUsers();
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    errorLbl.Text = string.Empty;
                    errorLbl.Text = "The user could not be updated because of the following: " + Environment.NewLine + ex.Message;
                }
            }  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorLbl.Text = string.Empty;
            if (StaticDataClass.loggedInUser.Id == User.Id)
            {
                errorLbl.Text = "You cannot delete the current user: " + User.Name;
                return;
            }
            // popup wndow - are you sure you want to delete the worker yes or no - if yes then delete form db
            if (MessageBox.Show("Are you sure, you want to delete the " + User.Name + " with employee ID: " + User.EmployeeID, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                FunctionResult deleteUser = DatabaseHandlerClass.DeleteUser(User);
                if (!deleteUser.Result)
                {
                    errorLbl.Text = "Employee could not be deleted because of the following: " + Environment.NewLine + deleteUser.Message;
                } else
                {
                    StaticDataClass.users = DatabaseHandlerClass.AllUsers();
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            generateBtn.Enabled = checkBox1.Checked;
            passwordTB.Enabled = checkBox1.Checked;
            generateBtn.Enabled = checkBox1.Checked;
        }
    }
}
