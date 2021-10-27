using STRACT.Entities.HumanResources;
using System.Collections.Generic;

namespace STRACT.web.Models
{
    public class ActivityInGroupsData
    {
        public IEnumerable<Activity> Activities { get; set; }
        public IEnumerable<ActivityGroup> ActivityGroups { get; set; }
        public IEnumerable<ActivityInGroup> ActivityInGroups { get; set; }
    }
}
