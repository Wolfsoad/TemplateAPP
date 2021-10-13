using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class ActivityInOrganizationalRole
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public int OrganizationalRoleId { get; set; }
        public OrganizationalRole OrganizationalRole { get; set; }

    }
}
