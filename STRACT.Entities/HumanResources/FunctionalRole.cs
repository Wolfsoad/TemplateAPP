using STRACT.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class FunctionalRole
    {
        public int FunctionalRoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<ProjectMember> Projects { get; set; }
    }
}
