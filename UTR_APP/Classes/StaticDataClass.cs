using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UTR_APP.Classes
{
    internal class StaticDataClass
    {
        /*
        public static Dictionary<int, string> employmentTypes = DatabaseHandlerClass.GetEmploymentTypes();
        public static Dictionary<int, string> departmentTypes = DatabaseHandlerClass.GetDepartmentTypes();
        public static Dictionary<int, string> roleTypes = DatabaseHandlerClass.GetRoleTypes();
        */

        public static string SettingIniPath = "settings.ini";

        public static List<EmploymentType> employmentTypes = DatabaseHandlerClass.GetEmploymentTypes();
        public static List<Department> departmentTypes = DatabaseHandlerClass.GetDepartmentTypes();
        public static List<Role> roleTypes = DatabaseHandlerClass.GetRoleTypes();

        public static List<Project> projects = DatabaseHandlerClass.AllProjects();
        public static List<UserFavoriteProject> favoriteProjects =new List<UserFavoriteProject>();

        public static List<RegistratedTime> workedHours = new List<RegistratedTime>();
        public static double workedHoursFromEmplymentStart = 0;

        public static UserClass loggedInUser;
        public static float UsersFlexHoursFromPrevSystem = 0;
        public static List<UserClass> users = new List<UserClass>();

        public static float baseHoursPerday = 7.4F;


        public static string DateTime_Converter(DateTime value)
        {
            DateTime result = new DateTime(value.Year, value.Month, value.Day);
            string formattedDate = result.ToString("yyyy-MM-dd");
            return formattedDate;
        }

        public static string Connection_Settings(string SettingIniPath)
        {
            string[] lines = File.ReadAllLines(SettingIniPath);
            Dictionary<string, string> connectionStringParams = new Dictionary<string, string>();

            foreach (string line in lines)
            {
                string[] parts = line.Split('=');

                if (parts.Length == 2)
                {
                    connectionStringParams.Add(parts[0].Trim(), parts[1].Trim());
                }
            }

            if (connectionStringParams.ContainsKey("server") &&
                connectionStringParams.ContainsKey("uid") &&
                connectionStringParams.ContainsKey("pwd") &&
                connectionStringParams.ContainsKey("database"))
            {
                return $"server={connectionStringParams["server"]};uid={connectionStringParams["uid"]};pwd={connectionStringParams["pwd"]};database={connectionStringParams["database"]}";
            }
            else
            {
                return string.Empty;
            }

        }

        internal static void SelectAllForApproval(List<RegistratedTime> workedHours)
        {
            foreach (RegistratedTime time in workedHours)
            {
                if (!time.Approved)
                {
                    time.Approved = true;
                }
            }
        }
    }

}
