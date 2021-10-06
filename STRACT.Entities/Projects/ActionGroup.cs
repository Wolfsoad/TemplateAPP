using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Projects
{
    public class ActionGroup
    {
        public int ActionGroupId { get; set; }
        public string Description { get; set; }
        public ICollection<ActionItem> ActionItems { get; set; }
    }
}
