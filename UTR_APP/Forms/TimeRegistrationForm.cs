using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UTR_APP.Classes;

namespace UTR_APP.Forms
{
    public partial class TimeRegistrationForm : Form
    {
        public RegistratedTime CurrentRegistratedTime { get; private set; }

        int chosenRegistratedTimeIndex = -1;
        public TimeRegistrationForm()
        {
            InitializeComponent();
            UI_Update(DateTime.Today);
            DataGrid_Update();
        }
        
        private void DataGrid_Update()
        {
            timeRegDG.Rows.Clear();
            foreach (RegistratedTime item in StaticDataClass.workedHours) // update coloumn/rows manually
            {
                object[] rowData = { item.Id, StaticDataClass.projects.Find(p=> p.Id == item.ProjectID), item.Description, item.Hours, StaticDataClass.DateTime_Converter(item.Date) };
                timeRegDG.Rows.Add(rowData);
            }
        }

        private void UI_Update(DateTime value)
        {
            errorLbl.Text = string.Empty;
            comboBox1.DataSource = StaticDataClass.projects;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";

            if (CurrentRegistratedTime != null)
            {
                addBtn.Text = "Modify";
                dateTimePicker1.Value = value;
                comboBox1.SelectedItem = StaticDataClass.projects.Find(p=> p.Id == CurrentRegistratedTime.ProjectID);
                numericUpDown1.Value = (decimal)CurrentRegistratedTime.Hours;
                descTB.Text = CurrentRegistratedTime.Description;

            } else
            {
                addBtn.Text = "Add";
                dateTimePicker1.Value = value;
                comboBox1.SelectedIndex = 0;
                numericUpDown1.Value = 0;
                descTB.Text = string.Empty;
            }

           dateTimePicker1.MaxDate = DateTime.Today;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool success = true;
            if (MessageBox.Show("Are you sure everything is right?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                List<FunctionResult> saveWorkedHours = DatabaseHandlerClass.SaveUpdateHours();

                foreach (FunctionResult item in saveWorkedHours)
                {
                    if (!item.Result)
                    {
                        errorLbl.Text = "Worked hours could not be saved: " + item.Message + Environment.NewLine;
                        success = false;
                    }
                }
                DialogResult = success ? DialogResult.OK : DialogResult.None;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            bool OkToContinue = true;
            DateTime date = dateTimePicker1.Value;
            if (comboBox1.SelectedIndex <= -1)
            {
                OkToContinue = false;
                errorLbl.Text = "No project selected";                
            }

            float modulo = (float)numericUpDown1.Value % 0.25F;
            if ( (int)modulo != 0)
            {
                OkToContinue = false;
                errorLbl.Text += "Given hours is not in acceptable format. It must be a multiple of 0.25.";
            }

            if ((float)numericUpDown1.Value  <= 0F)
            {
                OkToContinue = false;
                errorLbl.Text += "Given hours cannot be 0.";
            }

            if (!OkToContinue)
            {
                return;
            }

            if (CurrentRegistratedTime == null && OkToContinue)
            {
                try
                {
                    StaticDataClass.workedHours.Add(new RegistratedTime(0, StaticDataClass.loggedInUser.Id, (comboBox1.SelectedItem as Project).Id, descTB.Text, (float)numericUpDown1.Value, dateTimePicker1.Value,false));
                    UI_Update(date);
                    DataGrid_Update();
                }
                catch (Exception ex)
                {
                    errorLbl.Text = "There was a problem with the registration of hours: " + ex.Message;
                }
            }

            if (CurrentRegistratedTime != null && OkToContinue)
            {
               
                CurrentRegistratedTime.ProjectID = (int)comboBox1.SelectedValue;
                CurrentRegistratedTime.Hours = (float)numericUpDown1.Value;
                CurrentRegistratedTime.Description = descTB.Text;
                CurrentRegistratedTime.Date = date;
                CurrentRegistratedTime.Modified = true;


                StaticDataClass.workedHours.RemoveAt(chosenRegistratedTimeIndex);
                StaticDataClass.workedHours.Add(CurrentRegistratedTime);
                CurrentRegistratedTime = null;

                UI_Update(date);
                DataGrid_Update();                             
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = checkBox1.Checked ? StaticDataClass.projects.Where(p => StaticDataClass.favoriteProjects.Any(fp => fp.ProjectId == p.Id)).ToList() : StaticDataClass.projects;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(StaticDataClass.DateTime_Converter(dateTimePicker1.Value));
            DataGrid_Update();
        }

        private void timeRegDG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                chosenRegistratedTimeIndex = timeRegDG.SelectedCells[0].RowIndex;
                CurrentRegistratedTime = StaticDataClass.workedHours[chosenRegistratedTimeIndex];                
                UI_Update(CurrentRegistratedTime.Date);
            }
            else
            {
                MessageBox.Show("No items were selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timeRegDG_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            
            if (timeRegDG.SelectedRows.Contains(timeRegDG.Rows[0]))
            {
                errorLbl.Text = "First row cannot be deleted";
                e.Cancel = true;
                return;
            }
            

            if (timeRegDG.SelectedCells.Count == 0 || timeRegDG.SelectedCells[0].Value == null)
            {
                return;
            }

            int id = Convert.ToInt32(timeRegDG.SelectedCells[0].Value);
            RegistratedTime forDelete = StaticDataClass.workedHours.Find(data => data.Id == id);
            if (forDelete != null)
            {
                // the item alredy exist in the list - delete it
                if (MessageBox.Show("Are you sure you want to delete " + StaticDataClass.projects.Find(p => p.Id == forDelete.ProjectID).Name, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                FunctionResult result = DatabaseHandlerClass.DeleteGivenWorkedHours(forDelete);
                if (!result.Result)
                {
                    errorLbl.Text = result.Message;
                }
                else
                {
                    StaticDataClass.workedHours.Remove(forDelete);
                    DataGrid_Update();
                }
            }
        }
    }
}
