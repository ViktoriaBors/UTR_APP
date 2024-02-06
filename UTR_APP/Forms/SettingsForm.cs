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

        List<Project> allProject = new List<Project>();
        List<UserFavoriteProject> favoriteProjects = new List<UserFavoriteProject>();

        public List<UserFavoriteProject> AddedProjects { get; private set; }
        public List<UserFavoriteProject> DeletedProjects { get; private set; }

        public bool FavoriteListChanged { get; private set; }


        public SettingsForm()
        {
            InitializeComponent();
            StaticDataClass.favoriteProjects = DatabaseHandlerClass.AllFavoriteProjects();
            favoriteProjects = DatabaseHandlerClass.AllFavoriteProjects();
            FavoriteListChanged = false;
            Fill_Up_UserData();
        }

        private void Fill_Up_UserData()
        {
            errorLbl.Text = string.Empty;
            fullNameTB.Text = StaticDataClass.loggedInUser.Name;
            adressTB.Text = StaticDataClass.loggedInUser.Address;
            emailTB.Text = StaticDataClass.loggedInUser.Email;
            emplyeeIDTB.Text = StaticDataClass.loggedInUser.EmployeeID;
            emplTypeCB.DataSource = StaticDataClass.employmentTypes;
            if (StaticDataClass.employmentTypes.Count > 0)
            {
                emplTypeCB.DisplayMember = "Name"; // selectedvalue going to use the ID
                emplTypeCB.ValueMember = "ID";
                emplTypeCB.DataSource = StaticDataClass.employmentTypes;
            }
            emplTypeCB.SelectedValue = StaticDataClass.loggedInUser.EmploymentId;

            departmentCB.DataSource = StaticDataClass.departmentTypes;
            if (StaticDataClass.departmentTypes.Count > 0)
            {
                departmentCB.DisplayMember = "Name";
                departmentCB.ValueMember = "ID";
                departmentCB.DataSource = StaticDataClass.departmentTypes;
            }
           

            allProject = StaticDataClass.projects
                    .Where(p => !StaticDataClass.favoriteProjects.Any(fp => fp.ProjectId == p.Id)).ToList();
           
            listBox1.DataSource = allProject;

            listBox2.DataSource = StaticDataClass.projects
                    .Where(p => favoriteProjects.Any(fp => fp.ProjectId == p.Id)).ToList();

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
                    errorLbl.Text += "The new passwords are not the same.";
                    return;
                }
            }

            if (passwordChanged && DatabaseHandlerClass.PasswordMatches(StaticDataClass.loggedInUser.EmployeeID.ToString(), StaticDataClass.loggedInUser.Password).Result)
            { // password changed and match with the previous one - saved in db
                errorLbl.Text = "Password cannot be the same as before.";
                return;
            }

            AddedProjects = favoriteProjects.Except(StaticDataClass.favoriteProjects).ToList();
            DeletedProjects = StaticDataClass.favoriteProjects.Except(favoriteProjects).ToList();
  
            try
            {
                StaticDataClass.loggedInUser.Name = fullNameTB.Text;
                StaticDataClass.loggedInUser.Address = adressTB.Text;
                StaticDataClass.loggedInUser.Email = emailTB.Text;            
            }
            catch (Exception ex)
            {
                errorLbl.Text = ex.Message;
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void favoriteBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                if (!listBox2.Items.Contains(listBox1.SelectedItems))
                {
                    favoriteProjects.Add(new UserFavoriteProject(StaticDataClass.loggedInUser.Id, (listBox1.SelectedItem as Project).Id));
                    allProject.RemoveAt(listBox1.SelectedIndex);
                    Listbox_Project_Update();
                    FavoriteListChanged = true;
                } else
                {
                    errorLbl.Text = "The project is already added to favorites";
                }              
                
            } else
            {
                errorLbl.Text = "No element were chosen";
            }
        }

        private void Listbox_Project_Update()
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox2.DataSource = StaticDataClass.projects
                    .Where(p => favoriteProjects.Any(fp => fp.ProjectId == p.Id)).ToList();
            listBox1.DataSource = allProject;
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > -1)
            {
                if (!listBox1.Items.Contains(listBox1.SelectedItems))
                {
                    allProject.Add(listBox2.SelectedItem as Project);
                    favoriteProjects.RemoveAt(listBox2.SelectedIndex);
                    Listbox_Project_Update();
                    FavoriteListChanged = true;
                }
                else
                {
                    errorLbl.Text = "The project is already removed from favorites";
                }

            }
            else
            {
                errorLbl.Text = "No element were chosen";
            }
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
