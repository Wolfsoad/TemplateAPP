using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class ActivityGroup
    {
        public int ActivityGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ActivityInGroup> ActivityInGroups { get; set; }
    }
}
