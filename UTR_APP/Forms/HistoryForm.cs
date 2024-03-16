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
    public partial class HistoryForm : Form
    {
        DateTime startDate;
        DateTime endDate;
        float allBaseHoursInPeriod;
        float allWorkedHoursInPeriod;
        float allOvertimeHoursInPeriod;
        public HistoryForm()
        {
            InitializeComponent();
            CB_Update();
            startDate = DateTime.Today;
            endDate = DateTime.Today;
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
            historyDG.Rows.Clear();
            foreach (RegistratedTime item in StaticDataClass.workedHours) // update coloumn/rows manually
            {
                object[] rowData = { item.Id, StaticDataClass.projects.Find(p => p.Id == item.ProjectID), item.Description, item.Hours, StaticDataClass.DateTime_Converter(item.Date) };
                historyDG.Rows.Add(rowData);
            }

            Calculate_Summary();
            workedHoursLBL.Text = allWorkedHoursInPeriod.ToString();
            baseHoursLBL.Text = allBaseHoursInPeriod.ToString();
            overtimeTB.Text = allOvertimeHoursInPeriod.ToString();
        }

        private void Calculate_Summary()
        {
            int workingDays = Count_WorkingDays();
            allBaseHoursInPeriod = Calculate_BaseHours(workingDays,StaticDataClass.baseHoursPerday);

            allWorkedHoursInPeriod = Calculate_ActualWorkedHours();
            allOvertimeHoursInPeriod = allWorkedHoursInPeriod - allBaseHoursInPeriod;   
        }

        private float Calculate_ActualWorkedHours()
        {           
            return (float)StaticDataClass.UsersFlexHoursFromPrevSystem + (float)StaticDataClass.workedHoursFromEmplymentStart;
        }

        private float Calculate_BaseHours(int workingDays, float baseHoursPerDay)
        {
            return workingDays * baseHoursPerDay;
        }

        private int Count_WorkingDays()
        {
            int workingDays = 0;
            DateTime currentDate = StaticDataClass.loggedInUser.EmploymentStart;

            while (currentDate <= endDate)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
                currentDate = currentDate.AddDays(1);
            }
            return workingDays;
        }

        private void fromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            startDate = ((DateTimePicker)sender).Value;
            projectCB.SelectedIndex = 0;
            StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(StaticDataClass.DateTime_Converter(startDate), StaticDataClass.DateTime_Converter(endDate));
            UI_Update();
        }

        private void toDatePicker_ValueChanged(object sender, EventArgs e)
        {
            endDate = ((DateTimePicker)sender).Value;
            projectCB.SelectedIndex = 0;
            StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(StaticDataClass.DateTime_Converter(startDate), StaticDataClass.DateTime_Converter(endDate));
            StaticDataClass.workedHoursFromEmplymentStart = DatabaseHandlerClass.AllRegisteredHoursByUserFromEmplymentStart(StaticDataClass.DateTime_Converter(endDate));
            UI_Update() ;
        }

        private void projectCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projectCB.SelectedIndex > 0) // all is not calculated in
            {
                int projectID = StaticDataClass.projects.Find(pr => pr.Id == (projectCB.SelectedItem as Project).Id).Id;
                StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(StaticDataClass.DateTime_Converter(startDate), StaticDataClass.DateTime_Converter(endDate), projectID);
            } else
            {
                StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(StaticDataClass.DateTime_Converter(startDate), StaticDataClass.DateTime_Converter(endDate));
            }
            UI_Update();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
