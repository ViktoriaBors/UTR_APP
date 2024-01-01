using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTR_APP.Classes
{
    internal class StaticDataClass
    {
        public static Dictionary<int, string> employmentTypes = DatabaseHandlerClass.GetEmploymentTypes();
        public static Dictionary<int, string> departmentTypes = DatabaseHandlerClass.GetDepartmentTypes();
        public static Dictionary<int, string> roleTypes = DatabaseHandlerClass.GetRoleTypes();

        public static UserClass loggedInUser;
    }
}
