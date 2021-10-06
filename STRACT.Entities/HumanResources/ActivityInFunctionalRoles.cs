using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class ActivityInFunctionalRoles
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public int FunctionalRoleId { get; set; }
        public FunctionalRole FunctionalRole { get; set; }

    }
}
