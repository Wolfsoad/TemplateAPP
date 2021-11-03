using STRACT.Entities.HumanResources;
using System.Collections.Generic;

namespace STRACT.web.Models.HumanResources
{
    public class ActivityInGroupsData
    {
        public IEnumerable<Activity> Activities { get; set; }
        public IEnumerable<ActivityGroup> ActivityGroups { get; set; }
        public IEnumerable<ActivityInGroup> ActivityInGroups { get; set; }
        public IEnumerable<SkillInActivity> SkillInActivities { get; set; }
        public IEnumerable<FunctionalRole> FunctionalRoles { get; set; }
        public IEnumerable<ActivityInFunctionalRoles> ActivityInFunctionalRoles { get; set; }
        public IEnumerable<OrganizationalRole> OrganizationalRoles { get; set; }
        public IEnumerable<ActivityInOrganizationalRole> ActivityInOrganizationalRoles { get; set; }
    }
}
