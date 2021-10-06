using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ActivityInGroup> ActivityInGroups { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<FunctionalRole> FunctionalRoles { get; set; }
        public ICollection<OrganizationalRole> OrganizationalRoles { get; set; }
    }
}
