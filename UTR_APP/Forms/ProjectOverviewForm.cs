using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTR_APP.Classes;

namespace UTR_APP.Forms
{
    public partial class ProjectOverviewForm : Form
    {
        DateTime startDate;
        DateTime endDate;
        double allWorkedHoursInPeriod;
        public ProjectOverviewForm()
        {
            InitializeComponent();
            StaticDataClass.users = DatabaseHandlerClass.AllUsers(true);
            CB_Update();
            startDate = DateTime.Now;
            endDate = DateTime.Now;
            fromDatePicker.Value = startDate;
            toDatePicker.Value = endDate;
        }

        private void CB_Update()
        {
            projectCB.Items.Clear();
            projectCB.Items.Add("All");
            foreach (Project pr in StaticDataClass.projects)
            {
                projectCB.Items.Add(pr);
            }
            projectCB.SelectedIndex = 0;
        }
        private void UI_Update()
        {
            allHistoryDG.Rows.Clear();
            foreach (RegistratedTime item in StaticDataClass.workedHours) // update coloumn/rows manually
            {
                string modified = item.Modified ? "Yes" : "";
                UserClass user = StaticDataClass.users.Find(u => u.Id == item.UserID);
                object[] rowData = { item.Id, StaticDataClass.projects.Find(p => p.Id == item.ProjectID), user.EmployeeID, user.Name, item.Hours, item.Date, item.Description, modified, item.Approved };
                allHistoryDG.Rows.Add(rowData);
            }

            allWorkedHoursInPeriod = Calculate_ActualWorkedHours(StaticDataClass.workedHours);
            workedHoursLBL.Text = allWorkedHoursInPeriod.ToString();
        }

        private double Calculate_ActualWorkedHours(List<RegistratedTime> registrations)
        {
            double actualWorkedHours = 0;

            foreach (RegistratedTime registration in registrations)
            {
                if (registration.Date >= startDate && registration.Date <= endDate)
                {
                    actualWorkedHours += registration.Hours;
                } else
                {
                    actualWorkedHours = registration.Hours;
                }
            }
            return actualWorkedHours;
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void fromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            startDate = ((DateTimePicker)sender).Value;
            projectCB.SelectedIndex = 0;
            StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHours(StaticDataClass.DateTime_Converter(startDate), StaticDataClass.DateTime_Converter(endDate));
            UI_Update();
        }

        private void toDatePicker_ValueChanged(object sender, EventArgs e)
        {
            endDate = ((DateTimePicker)sender).Value;
            projectCB.SelectedIndex = 0;
            StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHours(StaticDataClass.DateTime_Converter(startDate), StaticDataClass.DateTime_Converter(endDate));
            UI_Update();
        }

        private void projectCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectFilter();
        }

        private void projectFilter()
        {
            if (projectCB.SelectedIndex > 0) // all is not calculated in
            {
                int projectID = StaticDataClass.projects.Find(pr => pr.Id == (projectCB.SelectedItem as Project).Id).Id;
                StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHours(StaticDataClass.DateTime_Converter(startDate), StaticDataClass.DateTime_Converter(endDate), projectID);
            }
            else
            {
                StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHours(StaticDataClass.DateTime_Converter(startDate), StaticDataClass.DateTime_Converter(endDate));
            }
            UI_Update();
        }

        private void chartBtn_Click(object sender, EventArgs e)
        {
            new StatisticsForm(StaticDataClass.workedHours).ShowDialog();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            List<RegistratedTime> ListForApproval = GetListForApproval();
            if (MessageBox.Show("Is everything look right? After 'yes', all hours going to be saved.", "Ready to save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatabaseHandlerClass.SaveUpdateHours(ListForApproval);
            }
            projectFilter();
        }

        private List<RegistratedTime> GetListForApproval()
        {
            List<RegistratedTime> result = new List<RegistratedTime>();
            for (int i = 0; i < allHistoryDG.Rows.Count; i++)
            {
                try
                {
                    int id = Convert.ToInt32(allHistoryDG.Rows[i].Cells[0].Value);
                    string user = Convert.ToString(allHistoryDG.Rows[i].Cells[2].Value);
                    int userID = StaticDataClass.users.Find(u => u.EmployeeID == user).Id;
                    string project = Convert.ToString(allHistoryDG.Rows[i].Cells[1].Value);
                    int projectID = StaticDataClass.projects.Find(p => p.Name == project).Id;
                    string description = Convert.ToString(allHistoryDG.Rows[i].Cells[6].Value);
                    int hours = Convert.ToInt32(allHistoryDG.Rows[i].Cells[4].Value);
                    DateTime date = Convert.ToDateTime(allHistoryDG.Rows[i].Cells[5].Value);
                    bool modified = Convert.ToString(allHistoryDG.Rows[i].Cells[7].Value) == "Yes" ? true:false;
                    bool isApproved = Convert.ToBoolean(allHistoryDG.Rows[i].Cells[8].Value);

                    result.Add(new RegistratedTime(id, userID, projectID, description, hours, date, modified, isApproved));
                }
                catch (FormatException ex)
                {
                    // Handle the format exception (e.g., log it, skip the row, display an error message)
                    Console.WriteLine($"Format Exception at row {i}: {ex.Message}");
                }
            }
            return result;
        }


        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            StaticDataClass.SelectAllForApproval(StaticDataClass.workedHours);
            UI_Update();
        }
    }
}
