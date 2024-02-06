using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTR_APP.Classes
{
    public class UserFavoriteProject
    {
        int userId;
        int projectId;
        string projectName;

        public UserFavoriteProject(int userId, int projectId, string project)
        {
            UserId = userId;
            ProjectId = projectId;
            projectName = project;
        }

        public UserFavoriteProject(int userId, int projectId)
        {
            UserId = userId;
            ProjectId = projectId;
        }

        public int UserId { get => userId; set => userId = value; }
        public int ProjectId { get => projectId; set => projectId = value; }
        public string Projectname { get => projectName; set => projectName = value; }

        public override string ToString()
        {
            return projectName;
        }
    }
}
