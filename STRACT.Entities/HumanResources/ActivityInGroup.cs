using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class ActivityInGroup
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public int ActivityGroupId { get; set; }
        public ActivityGroup ActivityGroup { get; set; }
    }
}
