using STRACT.Entities.HumanResources;
using STRACT.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Projects
{
    public class ProjectMember
    {
        public int ProjectItemId { get; set; }
        public ProjectItem ProjectItem { get; set; }
        public int UserId { get; set; }
        public UserInTeam User { get; set; }
        public int FunctionalRoleId { get; set; }
        public FunctionalRole FunctionalRole { get; set; }
        public string DescriptionOfFunction { get; set; }

    }
}
