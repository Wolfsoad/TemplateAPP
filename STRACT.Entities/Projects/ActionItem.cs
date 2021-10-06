using STRACT.Entities.Certifications;
using STRACT.Entities.Financial;
using STRACT.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Projects
{
    public class ActionItem
    {
        public int ActionItemId { get; set; }
        public string Description { get; set; }
        public DateTime RequestedIn { get; set; }
        public bool IsActive { get; set; }
        public int ActionGroupId { get; set; }
        public ActionGroup ActionGroup { get; set; }
        public int ActionPlanRevisionId { get; set; }
        public ActionPlanRevision ActionPlanRevision { get; set; }
        public int ProjectItemId { get; set; }
        public ProjectItem ProjectItem { get; set; }
        public ICollection<LocationsForAction> Locations { get; set; }
        public ICollection<LineOfProduct> LinesOfProducts { get; set; }
        public ICollection<CertificationInActionItem> CertificationInActionItems { get; set; }
        public ICollection<ToDoTask> ToDoTasks { get; set; }
        public ICollection<FinancialLine> FinancialLines { get; set; }
    }
}
