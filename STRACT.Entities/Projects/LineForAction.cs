using STRACT.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Projects
{
    public class LineForAction
    {
        public int LineOfProductId { get; set; }
        public LineOfProduct LineOfProduct { get; set; }
        public int ActionItemId { get; set; }
        public ActionItem ActionItem { get; set; }
    }
}
