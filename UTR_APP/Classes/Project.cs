using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTR_APP.Classes
{
    public class Project
    {
        int id;
        string name;
        string description;
        bool invoiceRequired;
        bool isActive;
        int departmentId;

        public ICollection<UserFavoriteProject> Users { get; set; }

        public Project(int id, string name, string description, bool isActive, int departmentId)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
            DepartmentId = departmentId;
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
                }
                else
                {
                    throw new ArgumentException("The project name must be at least 3 character.");
                }
            }
        }
        public string Description { get => description; set => description = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }

        public override string ToString()
        {
            return Name;
        }
    }
}
