using STRACT.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Projects
{
    public class LocationsForAction
    {
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int ActionLineId { get; set; }
        public ActionItem ActionItem { get; set; }
    }
}
