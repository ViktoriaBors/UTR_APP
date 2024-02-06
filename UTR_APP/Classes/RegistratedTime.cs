using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTR_APP.Classes
{
    public class RegistratedTime
    {
        int id;
        int userID;
        int projectID;
        float hours;
        string description;
        DateTime date;
        bool modified;

        public RegistratedTime(int id, int userID, int projectID, string description, float hours, DateTime created, bool modified)
        {
            Id = id;
            UserID = userID;
            ProjectID = projectID;
            Hours = hours;
            Description = description;
            Date = new DateTime(created.Year, created.Month, created.Day);
            Modified = modified;
        }

        public int Id { get => id; set => id = value; }
        public int UserID { get => userID; set => userID = value; }
        public int ProjectID { get => projectID; set => projectID = value; }
        public float Hours 
        { 
            get => hours;
            set 
            {
                if (value % 0.25 == 0)
                {
                    hours = value;
                }
                else
                {
                    throw new ArgumentException("The registered hours must be a multiple of 0.25.");
                }
            }
        }
        public DateTime Date { get => date; set => date = value; }
        public string Description { get => description; set => description = value; }
        public bool Modified { get => modified; set => modified = value; }

        
    }
}
