using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.X509;
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
    public partial class EmployeeOverviewForm : Form
    {
        public EmployeeOverviewForm()
        {
            InitializeComponent();
            StaticDataClass.users = DatabaseHandlerClass.AllUsers();
            if (StaticDataClass.users.Count > 0)
            {
                DataGridView_Update(StaticDataClass.users);
            }
        }

        private void DataGridView_Update(List<UserClass> users)
        {
            employeeDG.Rows.Clear();
            
            foreach (UserClass user in users) // update coloumn/rows manually
            {
                string depName = StaticDataClass.departmentTypes.Find(data => data.Id == user.DeparmentId) == null ? "-" : StaticDataClass.departmentTypes.Find(data => data.Id == user.DeparmentId).Name;
                string emplName = StaticDataClass.employmentTypes.Find(data => data.Id == user.EmploymentId) == null ? "-" : StaticDataClass.employmentTypes.Find(data => data.Id == user.EmploymentId).Name;
                string roleName = StaticDataClass.roleTypes.Find(data => data.Id == user.RoleId) == null ? "-" : StaticDataClass.roleTypes.Find(data => data.Id == user.RoleId).Name;
                object[] rowData = { user.EmployeeID, user.Name, depName , emplName, roleName  };
                employeeDG.Rows.Add(rowData);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();  
            DialogResult = DialogResult.Cancel;
        }

        private void newUserBtn_Click(object sender, EventArgs e)
        {
            EmployeeForm form = new EmployeeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                DataGridView_Update(StaticDataClass.users);
            }
        }

        private void employeeDG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {                              
                EmployeeForm form = new EmployeeForm(StaticDataClass.users[employeeDG.SelectedCells[0].RowIndex]);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    DataGridView_Update(StaticDataClass.users);
                }
                
            }
            else
            {
                MessageBox.Show("No items were selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            if (new EmployeeForm().ShowDialog() == DialogResult.OK)
            {
                DataGridView_Update(StaticDataClass.users);
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
            {
                string searchText = (sender as TextBox).Text.ToLower();
                List<UserClass> filteredUsers = StaticDataClass.users.Where(user => user.EmployeeID.ToLower().Contains(searchText.ToLower()) || user.Name.ToLower().Contains(searchText.ToLower())).ToList();
                DataGridView_Update(filteredUsers);
            }
            else
            {
                DataGridView_Update(StaticDataClass.users);
            }
        }
    }
}
