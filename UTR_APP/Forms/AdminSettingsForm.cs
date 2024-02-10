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
    public partial class AdminSettingsForm : Form
    {
        bool departmentDGRowAdded = false;
        bool employmentTypeDGRowAdded = false;
        bool roleDGRowAdded = false;
        bool initialized = false;
        public AdminSettingsForm()
        {
            InitializeComponent();           
            DataGridView_Update();
            errorLbl.Text = string.Empty;
            initialized = true;
        }

        private void DataGridView_Update()
        {
            departmentDG.Rows.Clear();
            roleDG.Rows.Clear();
            emplTypesDG.Rows.Clear(); 
           
            foreach (Department item in StaticDataClass.departmentTypes) // update coloumn/rows manually
            {
                object[] rowData = { item.Id,item.Name, item.Description };
                departmentDG.Rows.Add(rowData);
            }
            foreach (Role item in StaticDataClass.roleTypes) // update coloumn/rows manually
            {
                object[] rowData = { item.Id, item.Name, item.Description };
                roleDG.Rows.Add(rowData);
            }
            foreach (EmploymentType item in StaticDataClass.employmentTypes) // update coloumn/rows manually
            {
                object[] rowData = { item.Id, item.Name, item.Description };
                emplTypesDG.Rows.Add(rowData);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void departmentDG_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {           
            departmentDGRowAdded = true;
        }

        private void departmentDG_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (departmentDG.SelectedRows.Contains(departmentDG.Rows[0]))
            {
                errorLbl.Text = "First row cannot be deleted";
                e.Cancel = true;
                return;
            }

            if (departmentDG.SelectedCells[0].Value == null)
            {
                return;
            }
            int id = Convert.ToInt32(departmentDG.SelectedCells[0].Value);
            Department forDelete = StaticDataClass.departmentTypes.Find(data => data.Id == id);
            if (forDelete != null)
            {
                // the item alredy exist in the list - delete it
                
                if (MessageBox.Show("Are you sure you want to delete " + departmentDG.SelectedCells[1].Value.ToString(), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                FunctionResult result = DatabaseHandlerClass.DeleteDepartment(forDelete);
                if (!result.Result)
                {
                    errorLbl.Text = result.Message;
                } else
                {
                    StaticDataClass.departmentTypes.Remove(forDelete);
                    DataGridView_Update();
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool OkToContinue = true;
            if (departmentDGRowAdded)
            {
                try
                {
                    List<Department> list = new List<Department>();
                    for (int i = 0; i < departmentDG.Rows.Count - 1; i++)
                    {
                        object objectId = departmentDG.Rows[i].Cells[0].Value;
                        int id = objectId == null ? 0 : Convert.ToInt32(objectId);
                        string desc = (departmentDG.Rows[i].Cells[2].Value as string) == null ? "" : (departmentDG.Rows[i].Cells[2].Value as string);
                        Department newDepartment = new Department(id, (departmentDG.Rows[i].Cells[1].Value as string), desc);
                        list.Add(newDepartment);
                    }

                    // update/add departments to db
                    for (int j = 0; j < list.Count; j++)
                    {
                        FunctionResult result = DatabaseHandlerClass.DepartmentUpdateAdd(list[j]);
                        if (!result.Result)
                        {
                            errorLbl.Text += result.Message;
                            OkToContinue = false;
                        }
                    }
                    StaticDataClass.departmentTypes = DatabaseHandlerClass.GetDepartmentTypes();

                }
                catch (Exception ex)
                {
                    errorLbl.Text += ex.Message + Environment.NewLine;
                    OkToContinue = false;
                }
            }

            if (roleDGRowAdded)
            {
                try
                {
                    List<Role> list = new List<Role>();
                    for (int i = 0; i < roleDG.Rows.Count - 1; i++)
                    {
                        object objectId = roleDG.Rows[i].Cells[0].Value;
                        int id = objectId == null ? 0 : Convert.ToInt32(objectId);
                        string desc = (roleDG.Rows[i].Cells[2].Value as string) == null ? "" : (roleDG.Rows[i].Cells[2].Value as string);
                        Role newRole = new Role(id, (roleDG.Rows[i].Cells[1].Value as string),desc);
                        list.Add(newRole);
                    }

                    // update/add departments to db
                    for (int j = 0; j < list.Count; j++)
                    {
                        FunctionResult result = DatabaseHandlerClass.RoleUpdateAdd(list[j]);
                        if (!result.Result)
                        {
                            errorLbl.Text += result.Message;
                            OkToContinue = false;
                        }
                    }
                    StaticDataClass.roleTypes = DatabaseHandlerClass.GetRoleTypes();

                }
                catch (Exception ex)
                {
                    errorLbl.Text += ex.Message + Environment.NewLine;
                    OkToContinue = false;
                }

            }


            if (employmentTypeDGRowAdded)
            {
                try
                {
                    List<EmploymentType> list = new List<EmploymentType>();
                    for (int i = 0; i < emplTypesDG.Rows.Count - 1; i++)
                    {
                        object objectId = emplTypesDG.Rows[i].Cells[0].Value;
                        int id = objectId == null ? 0 : Convert.ToInt32(objectId);
                        string desc = (emplTypesDG.Rows[i].Cells[2].Value as string) == null ? "" : (emplTypesDG.Rows[i].Cells[2].Value as string);
                        EmploymentType newEmpl = new EmploymentType(id, (emplTypesDG.Rows[i].Cells[1].Value as string),desc);
                        list.Add(newEmpl);
                    }

                    // update/add departments to db
                    for (int j = 0; j < list.Count; j++)
                    {
                        FunctionResult result = DatabaseHandlerClass.EmploymentTypeUpdateAdd(list[j]);
                        if (!result.Result)
                        {
                            errorLbl.Text += result.Message;
                            OkToContinue = false;
                        }
                    }
                    StaticDataClass.employmentTypes = DatabaseHandlerClass.GetEmploymentTypes();

                }
                catch (Exception ex)
                {
                    errorLbl.Text += ex.Message + Environment.NewLine;
                    OkToContinue = false;
                }
            }

            if (OkToContinue)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void departmentDG_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (initialized)
            {
                departmentDGRowAdded = true;
            }
           
        }

        private void roleDG_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (initialized)
            {
                roleDGRowAdded = true;
            }

        }

        private void roleDG_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            roleDGRowAdded = true;
        }

        private void roleDG_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (roleDG.SelectedRows.Contains(roleDG.Rows[0]))
            {
                errorLbl.Text = "First row cannot be deleted";
                e.Cancel = true;
                return;
            }

            if (roleDG.SelectedCells[0].Value == null)
            {
                return;
            }
            int id = Convert.ToInt32(roleDG.SelectedCells[0].Value);
            Role forDelete = StaticDataClass.roleTypes.Find(data => data.Id == id);
            if (forDelete != null)
            {
                // the item alredy exist in the list - delete it

                if (MessageBox.Show("Are you sure you want to delete " + roleDG.SelectedCells[1].Value.ToString(), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                FunctionResult result = DatabaseHandlerClass.DeleteRole(forDelete);
                if (!result.Result)
                {
                    errorLbl.Text = result.Message;
                }
                else
                {
                    StaticDataClass.roleTypes.Remove(forDelete);
                    DataGridView_Update();
                }
            }
        }

        private void emplTypesDG_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (initialized)
            {
                employmentTypeDGRowAdded = true;
            }
        }

        private void emplTypesDG_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            employmentTypeDGRowAdded = true;
        }

        private void emplTypesDG_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            
            if (emplTypesDG.SelectedRows.Contains(emplTypesDG.Rows[0]))
            {
                errorLbl.Text = "First row cannot be deleted";
                e.Cancel = true;
                return;
            }
            

            if (emplTypesDG.SelectedCells[0].Value == null)
            {
                return;
            }
            int id = Convert.ToInt32(emplTypesDG.SelectedCells[0].Value);
            EmploymentType forDelete = StaticDataClass.employmentTypes.Find(data => data.Id == id);
            if (forDelete != null)
            {
                // the item alredy exist in the list - delete it

                if (MessageBox.Show("Are you sure you want to delete " + emplTypesDG.SelectedCells[1].Value.ToString(), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                FunctionResult result = DatabaseHandlerClass.DeleteEmploymentType(forDelete);
                if (!result.Result)
                {
                    errorLbl.Text = result.Message;
                }
                else
                {
                    StaticDataClass.employmentTypes.Remove(forDelete);
                    DataGridView_Update();
                }
            }
        }
    }
}
