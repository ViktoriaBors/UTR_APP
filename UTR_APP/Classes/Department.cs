using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTR_APP.Classes
{
    internal class Department
    {
        int id;
        string name;
        string description;

        public Department(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        public int Id { get => id; set => id = value; }
        public string Name 
        { 
            get => name;
            set 
            {
                if (value.Length >= 3)
                {
                    name = value;
                } else
                {
                    throw new ArgumentException("The department name must be at least 3 character.");
                }
            } 
        }
       public string Description { get => description; set => description = value; }
    }
}
