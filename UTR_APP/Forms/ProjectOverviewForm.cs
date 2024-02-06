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
            StaticDataClass.users = DatabaseHandlerClass.AllUsers();
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
                object[] rowData = { item.Id, StaticDataClass.projects.Find(p => p.Id == item.ProjectID), user.EmployeeID, user.Name, item.Hours, item.Date, item.Description, modified };
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
    }
}
