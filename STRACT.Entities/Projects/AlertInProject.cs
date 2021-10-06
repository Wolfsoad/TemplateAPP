using STRACT.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Projects
{
    public class AlertInProject
    {
        public int AlertTypeId { get; set; }
        public AlertType AlertType { get; set; }
        public int ProjectItemId { get; set; }
        public ProjectItem ProjectItem { get; set; }
    }
}
