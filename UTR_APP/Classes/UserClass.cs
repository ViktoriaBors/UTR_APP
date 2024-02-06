using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;


namespace UTR_APP.Classes
{
    public class UserClass
    {
        int id; 
        string employeeID; // initials
        string password;
        int roleId;
        string name;
        string address;
        string email;
        int deparmentId;
        int employmentId;
        float hoursFromPrevSystem;
        public ICollection<UserFavoriteProject> FavoriteProjects { get; set; }

        bool passwordHasBeenChanged;

        public int Id { get => id; set => id = value; }
        public string EmployeeID { get => employeeID; set => employeeID = value; }
        public string Password 
        { 
            get => password;
            set 
            {
                string specChar = "!@#$%^&*?_-";
                if(value.Length >= 8 &&
                    value.Any(char.IsDigit) && value.Any(c => specChar.Contains(c)))  
                { 
                    password = value; 
                } else
                {
                    throw new ArgumentException("Password must be minimum 8 character and contain a digit and special characters (!@#$%^&*?_-)");
                }                
            }

        }
        public int RoleId { get => roleId; set => roleId = value; }
        public string Name 
        { 
            get => name;
            set
            {
                if (value!= string.Empty && value.Contains(' ') && value.Length >= 5)
                {
                    name = value;
                } else
                {
                    throw new ArgumentException("The name must be minimum 5 charachter and contains a space.");
                }
            }
        }
        public string Address { get => address; set => address = value; }
        public string Email 
        { 
            get => email; 
            set
            {
                if (value.Length > 0 && new EmailAddressAttribute().IsValid(value))
                {
                    email = value;
                } else if (value.Length == 0)
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentException("Not a valid email address.");
                }
            } 
        }
        public int DeparmentId { get => deparmentId; set => deparmentId = value; }
        public int EmploymentId { get => employmentId; set => employmentId = value; }
        public float HoursFromPrevSystem { get => hoursFromPrevSystem; set => hoursFromPrevSystem = value; }


        public UserClass(string employeeID, string password, int roleId, string name, int deparmentId, int employmentId, float hoursFromPrevSystem)
        { // first time the admin register a new employee
            EmployeeID = employeeID;
            Password = password;
            RoleId = roleId;
            Name = name;
            DeparmentId = deparmentId;
            EmploymentId = employmentId;
            HoursFromPrevSystem = hoursFromPrevSystem;
        }

        public UserClass(int id, string employeeID, string password, int roleId, string name, string address, string email, int deparmentId, int employmentId, float hoursFromPrevSystem) // int timeRegTypeId)
        { // creating the employee from the database
            Id = id;
            EmployeeID = employeeID;
            Password = password;
            RoleId = roleId;
            Name = name;
            Address = address;
            Email = email;
            DeparmentId = deparmentId;
            EmploymentId = employmentId;
            HoursFromPrevSystem = hoursFromPrevSystem;
        }
    }
}
