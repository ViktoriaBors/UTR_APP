using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTR_APP.Classes;
using UTR_APP.Forms;

namespace UTR_APP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // ini file check 
            if (!File.Exists("settings.ini"))
            {
                if (MessageBox.Show("There is a problem with the settings.ini file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }

            this.Hide();
            LoginForm ablak = new LoginForm();
            if (ablak.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                CheckAdminStatus();
            }

            bool forgottenRegistration = false;

            if (StaticDataClass.loggedInUser.EmployeeID != "Admin")
            {
                StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(StaticDataClass.DateTime_Converter(DateTime.Today.AddDays(-1)));
                if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                {
                    string dateFriday = StaticDataClass.DateTime_Converter(DateTime.Today.AddDays(-3));
                    StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(dateFriday);

                    if (StaticDataClass.workedHours.Count == 0)
                    {
                        forgottenRegistration = true;
                    }

                    if (DateTime.Today.DayOfWeek != DayOfWeek.Monday && DateTime.Today.DayOfWeek != DayOfWeek.Sunday && DateTime.Today.DayOfWeek != DayOfWeek.Saturday)
                    {
                        string yesterday = StaticDataClass.DateTime_Converter(DateTime.Today.AddDays(-1));
                        StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(yesterday);
                        if (StaticDataClass.workedHours.Count == 0)
                        {
                            forgottenRegistration = true;
                        }
                    }
                    StaticDataClass.workedHours = new List<RegistratedTime>();

                    if (forgottenRegistration)
                    {
                        if (MessageBox.Show("It looks like you forgot to register you working hours from last working day. Do you want to register now?", "Missing hours registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            new TimeRegistrationForm().ShowDialog();
                        }
                    }
                }
            }       
         
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            DesignStatic.PB_Enter(sender as PictureBox);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            DesignStatic.PB_Leave(sender as PictureBox);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                string error = string.Empty;
                // save the employee data changes to database
               FunctionResult savingData = DatabaseHandlerClass.Update_EmployeeData(form.passwordChanged, StaticDataClass.loggedInUser, false);
                if (!savingData.Result)
                {
                    error = savingData.Message;
                }

                if (form.DeletedProjects.Count > 0)
                {
                    List<FunctionResult> deleteFavorites = DatabaseHandlerClass.DeleteFavoriteProjects(form.DeletedProjects);
                    foreach (FunctionResult item in deleteFavorites)
                    {
                        if (!item.Result)
                        {
                            error += item.Message + Environment.NewLine;
                        }
                    }                    
                }

                if (form.FavoriteListChanged)
                {
                    if (form.AddedProjects.Count > 0)
                    {
                        List<FunctionResult> savingFavorites = DatabaseHandlerClass.SaveFavoriteProjects(form.AddedProjects);
                        foreach (FunctionResult item in savingFavorites)
                        {
                            if (!item.Result)
                            {
                                error += item.Message + Environment.NewLine;
                            }
                        }                        
                    }

                    if (error.Length > 0)
                    {
                        MessageBox.Show(error, "Error saving data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }               
            }
           
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //(new EmployeeForm()).ShowDialog();
            (new EmployeeOverviewForm()).ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        { // remember delete saved logged in user before
            StaticDataClass.loggedInUser = null;
            this.Hide();
            LoginForm ablak = new LoginForm();
            if (ablak.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                CheckAdminStatus();
            }
            bool forgottenRegistration = false;

            if (StaticDataClass.loggedInUser.EmployeeID != "Admin")
            {
                StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(StaticDataClass.DateTime_Converter(DateTime.Today.AddDays(-1)));
                if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                {
                    string dateFriday = StaticDataClass.DateTime_Converter(DateTime.Today.AddDays(-3));
                    StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(dateFriday);

                    if (StaticDataClass.workedHours.Count == 0)
                    {
                        forgottenRegistration = true;
                    }

                    if (DateTime.Today.DayOfWeek != DayOfWeek.Monday && DateTime.Today.DayOfWeek != DayOfWeek.Sunday && DateTime.Today.DayOfWeek != DayOfWeek.Saturday)
                    {
                        string yesterday = StaticDataClass.DateTime_Converter(DateTime.Today.AddDays(-1));
                        StaticDataClass.workedHours = DatabaseHandlerClass.AllRegisteredHoursByUser(yesterday);
                        if (StaticDataClass.workedHours.Count == 0)
                        {
                            forgottenRegistration = true;
                        }
                    }
                    StaticDataClass.workedHours = new List<RegistratedTime>();

                    if (forgottenRegistration)
                    {
                        if (MessageBox.Show("It looks like you forgot to register you working hours from last working day. Do you want to register now?", "Missing hours registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            new TimeRegistrationForm().ShowDialog();
                        }
                    }
                }
            }
        }

        private void CheckAdminStatus()
        {
            if (StaticDataClass.loggedInUser.RoleId != 1) // not admin
            {
                adminToolStripMenuItem.Visible = false;
                adminToolStripMenuItem.Enabled = false;
            }
            else
            {
                adminToolStripMenuItem.Visible = true;
                adminToolStripMenuItem.Enabled = true;
            }

            if (StaticDataClass.loggedInUser.EmployeeID == "Admin")
            {
                groupBox1.Enabled = false;
            } else
            {
                groupBox1.Enabled= true;
            }

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AdminSettingsForm()).ShowDialog();
        }

        private void projectHoursOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ProjectsForm()).ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new TimeRegistrationForm().ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new HistoryForm().ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new StatisticsForm().ShowDialog();
        }

        private void projectHoursOverviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new ProjectOverviewForm()).ShowDialog();
        }
    }
}
