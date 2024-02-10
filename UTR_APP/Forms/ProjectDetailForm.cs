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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace UTR_APP.Forms
{
    public partial class ProjectDetailForm : Form
    {
        public Project Project { get; set; }
        public ProjectDetailForm()
        {
            InitializeComponent();
            this.Text = "Add new employee";
            errorLbl.Text = string.Empty;
            deleteBtn.Enabled = false;
            deleteBtn.Visible = false;
            Project = null;
            DepartmentCB_Update();
        }

        private void DepartmentCB_Update()
        {
            departmentCB.DataSource = null;
            departmentCB.DataSource = StaticDataClass.departmentTypes;
            departmentCB.ValueMember = "ID";
            departmentCB.DisplayMember = "Name";
        }

        public ProjectDetailForm(Project project)
        {
            InitializeComponent();
            errorLbl.Text = string.Empty;
            Project = project;
            this.Text = "Modify project: " + project.Name;
            UI_Update();
        }

        private void UI_Update()
        {
            nameTB.Text = Project.Name;
            descTB.Text = Project.Description;
            isActiveCB.Checked = Project.IsActive;
            isActiveCB.Enabled = false;

            deleteBtn.Text = Project.IsActive ? "Deactivate" : "Activate";

            DepartmentCB_Update();
            departmentCB.SelectedItem = StaticDataClass.departmentTypes.Find(p=> p.Id == Project.DepartmentId);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorLbl.Text = string.Empty;
            if (Project == null) // new project registration
            {
                try
                {
                    Project = new Project(0, nameTB.Text, descTB.Text, isActiveCB.Checked, (int)departmentCB.SelectedValue);
                    FunctionResult registerNewProject = DatabaseHandlerClass.RegistrationOfNewProject(Project);
                    if (registerNewProject.Result)
                    {
                        StaticDataClass.projects = DatabaseHandlerClass.AllProjects();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        errorLbl.Text = "The new project could not be created because of the following: " + Environment.NewLine + registerNewProject.Message;
                    }
                }
                catch (Exception ex)
                {
                    errorLbl.Text = string.Empty;
                    errorLbl.Text = "The new project could not be created because of the following: " + Environment.NewLine + ex.Message;
                }
            }
            else // a given project data is changed
            {
                try
                {
                    Project.Name = nameTB.Text;
                    Project.Description = descTB.Text;
                    Project.IsActive = isActiveCB.Checked;
                    FunctionResult updateProject = DatabaseHandlerClass.UpdateProjectData(Project);
                    if (updateProject.Result)
                    {
                        StaticDataClass.projects = DatabaseHandlerClass.AllProjects();
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    errorLbl.Text = string.Empty;
                    errorLbl.Text = "The project could not be updated because of the following: " + Environment.NewLine + ex.Message;
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            errorLbl.Text = string.Empty;
            // popup wndow - are you sure you want to delete the worker yes or no - if yes then delete form db
            if (MessageBox.Show("Are you sure, you want to deactivate the " + Project.Name + "? Employees cannot register hours anymore on this project then.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Project.IsActive = !isActiveCB.Checked;
                FunctionResult deactivateProject = DatabaseHandlerClass.DeactivateProject(Project);
                if (!deactivateProject.Result)
                {
                    errorLbl.Text = "Project could not be deactivated because of the following: " + Environment.NewLine + deactivateProject.Message;
                }
                else
                {
                    StaticDataClass.projects = DatabaseHandlerClass.AllProjects();
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
