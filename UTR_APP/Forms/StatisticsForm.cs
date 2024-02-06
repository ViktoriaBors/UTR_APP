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
using System.Windows.Forms.DataVisualization.Charting;
using UTR_APP.Classes;

namespace UTR_APP.Forms
{
    public partial class StatisticsForm : Form
    {
        DateTime startDate;
        DateTime endDate;
        bool initialized = false;
        public StatisticsForm()
        {
            InitializeComponent();
            startDate = DateTime.Now;
            endDate = DateTime.Now;
            fromDatePicker.Value = startDate;
            toDatePicker.Value = endDate;
            initialized = true;
            UI_Update();
        }

        public StatisticsForm(List<RegistratedTime> workedHours)
        {
            InitializeComponent();
            fromDatePicker. Visible = false;
            toDatePicker.Visible = false;
            fromDatePicker.Enabled = false;
            toDatePicker.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            UI_Update(workedHours);
        }

        private void fromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            startDate = ((DateTimePicker)sender).Value;
            StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(StaticDataClass.DateTime_Converter(startDate), StaticDataClass.DateTime_Converter(endDate));
            if (initialized && StaticDataClass.workedHours.Count > 0)
            {
                UI_Update();
            }
        }

        private void toDatePicker_ValueChanged(object sender, EventArgs e)
        {
            endDate = ((DateTimePicker)sender).Value;
            StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(StaticDataClass.DateTime_Converter(startDate), StaticDataClass.DateTime_Converter(endDate));
            if (initialized && StaticDataClass.workedHours.Count > 0)
            {
                UI_Update();
            }

        }

        private void UI_Update()
        {   
            StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(StaticDataClass.DateTime_Converter(startDate), StaticDataClass.DateTime_Converter(endDate));

            if (StaticDataClass.workedHours.Count > 0)
            {
                errorLbl.Text = string.Empty;
                statisticChart.Visible = true;
                statisticChart.Series.Clear();
                if (startDate != endDate) // longer period
                {
                    foreach (Project project in StaticDataClass.projects)
                    {
                        Series projectSeries = new Series(project.Name);

                        foreach (RegistratedTime workedhours in StaticDataClass.workedHours.Where(w => w.ProjectID == project.Id))
                        {
                            projectSeries.Points.AddXY(workedhours.Date, workedhours.Hours);
                        }

                        statisticChart.Series.Add(projectSeries);
                    }

                    statisticChart.ChartAreas[0].AxisX.Title = "Date";
                    statisticChart.ChartAreas[0].AxisY.Title = "Worked Hours";
                    statisticChart.ChartAreas[0].Area3DStyle.Enable3D = false;
                } else // one day period should shown as a pie
                {
                    Series pieSeries = new Series("WorkedHoursDistribution");
                    pieSeries.ChartType = SeriesChartType.Pie;

                    foreach (Project project in StaticDataClass.projects)
                    {
                        // Calculate total worked hours for the project
                        double totalHours = StaticDataClass.workedHours
                            .Where(w => w.ProjectID == project.Id)
                            .Sum(item => item.Hours);

                        // Add a data point to the pie series
                        // pieSeries.Points.AddXY(project.Name,totalHours);

                        DataPoint dataPoint = pieSeries.Points.Add(totalHours);

                        // Set the label to include both project name and hours
                        dataPoint.Label = $"{project.Name}: {totalHours} hours";

                    }

                    statisticChart.Series.Add(pieSeries);
                    statisticChart.ChartAreas[0].Area3DStyle.Enable3D = true; // Enable 3D view for better visualization
                    statisticChart.Series["WorkedHoursDistribution"]["PieLabelStyle"] = "Outside"; // Show labels outside the pie slices
                    statisticChart.ChartAreas[0].AxisX.Title = "Projects"; // Update axis title
                    statisticChart.ChartAreas[0].AxisY.Title = "Total Worked Hours"; // Update axis title

                }               

            } else
            {
                statisticChart.Visible = false;
                errorLbl.Text = "No statistic can be showned.";
            }           
        }

        private void UI_Update(List<RegistratedTime> workedHoursList)
        {        

            if (workedHoursList.Count > 0)
            {
                errorLbl.Text = string.Empty;
                statisticChart.Visible = true;
                statisticChart.Series.Clear();
                if (startDate != endDate) // longer period
                {
                    foreach (Project project in StaticDataClass.projects)
                    {
                        Series projectSeries = new Series(project.Name);

                        foreach (RegistratedTime workedhours in workedHoursList.Where(w => w.ProjectID == project.Id))
                        {
                            projectSeries.Points.AddXY(workedhours.Date, workedhours.Hours);
                        }

                        statisticChart.Series.Add(projectSeries);
                    }

                    statisticChart.ChartAreas[0].AxisX.Title = "Date";
                    statisticChart.ChartAreas[0].AxisY.Title = "Worked Hours";
                    statisticChart.ChartAreas[0].Area3DStyle.Enable3D = false;
                }
                else // one day period should shown as a pie
                {
                    Series pieSeries = new Series("WorkedHoursDistribution");
                    pieSeries.ChartType = SeriesChartType.Pie;

                    foreach (Project project in StaticDataClass.projects)
                    {
                        // Calculate total worked hours for the project
                        double totalHours = StaticDataClass.workedHours
                            .Where(w => w.ProjectID == project.Id)
                            .Sum(item => item.Hours);

                        // Add a data point to the pie series
                        // pieSeries.Points.AddXY(project.Name,totalHours);

                        DataPoint dataPoint = pieSeries.Points.Add(totalHours);

                        // Set the label to include both project name and hours
                        dataPoint.Label = $"{project.Name}: {totalHours} hours";

                    }

                    statisticChart.Series.Add(pieSeries);
                    statisticChart.ChartAreas[0].Area3DStyle.Enable3D = true; // Enable 3D view for better visualization
                    statisticChart.Series["WorkedHoursDistribution"]["PieLabelStyle"] = "Outside"; // Show labels outside the pie slices
                    statisticChart.ChartAreas[0].AxisX.Title = "Projects"; // Update axis title
                    statisticChart.ChartAreas[0].AxisY.Title = "Total Worked Hours"; // Update axis title

                }

            }
            else
            {
                statisticChart.Visible = false;
                errorLbl.Text = "No statistic can be showned.";
            }

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
