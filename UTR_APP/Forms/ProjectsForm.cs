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
    public partial class ProjectsForm : Form
    {
        public ProjectsForm()
        {
            InitializeComponent();
            StaticDataClass.projects = DatabaseHandlerClass.AllProjects();
            if (StaticDataClass.projects.Count > 0)
            {
                projectDG_Update(StaticDataClass.projects);
            }
        }

        private void projectDG_Update(List<Project> projects)
        {
            projectDG.Rows.Clear();
            foreach (Project item in projects) // update coloumn/rows manually
            {
                object[] rowData = { item.Id, item.Name, item.Description, item.IsActive };
                projectDG.Rows.Add(rowData);
            }
        }

        private void addProject_Click(object sender, EventArgs e)
        {
            ProjectDetailForm form = new ProjectDetailForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                projectDG_Update(DatabaseHandlerClass.AllProjects(checkBox1.Checked));
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void filterTb_TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
            {
                string searchText = (sender as TextBox).Text.ToLower();
                List<Project> filteredProjetcs = StaticDataClass.projects.Where(user => user.Name.ToLower().Contains(searchText.ToLower())).ToList();
                projectDG_Update(filteredProjetcs);
            }
            else
            {
                projectDG_Update(StaticDataClass.projects);
            }
        }

        private void projectDG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                ProjectDetailForm form = new ProjectDetailForm(StaticDataClass.projects[projectDG.SelectedCells[0].RowIndex]);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    projectDG_Update(DatabaseHandlerClass.AllProjects(checkBox1.Checked));
                }
            }
            else
            {
                MessageBox.Show("No items were selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            filterTb.Text = string.Empty;
            StaticDataClass.projects = DatabaseHandlerClass.AllProjects(checkBox1.Checked);
            projectDG_Update(StaticDataClass.projects);
        }
    }
}
