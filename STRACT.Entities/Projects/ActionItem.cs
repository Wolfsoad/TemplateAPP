using STRACT.Entities.Certifications;
using STRACT.Entities.Financial;
using STRACT.Entities.General;
using STRACT.Entities.HumanResources;
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
        public int? ActionPlanRevisionId { get; set; }
        public ActionPlanRevision ActionPlanRevision { get; set; }
        public int? ProjectItemId { get; set; }
        public ProjectItem ProjectItem { get; set; }
        public int DepartmentId { get; set; }
        public Department RequestedBy { get; set; }
        public ICollection<LocationsForAction> Locations { get; set; }
        public ICollection<LineOfProduct> LinesOfProducts { get; set; }
        public ICollection<CertificationInActionItem> CertificationInActionItems { get; set; }
        public ICollection<ToDoTask> ToDoTasks { get; set; }
        public ICollection<FinancialLine> FinancialLines { get; set; }

        //Private properties
        private double _totalValueInBudget;
        private double _totalValueAccounted;
        private Dictionary<string, double> _totalValueInBudgetByType;
        private Dictionary<string, List<FinancialLine>> _totalFinancialLineByType;
        private Dictionary<int, Dictionary<string, DateTime>> _chronogramsMilestones;
        private int _actionPlanYear;
        private double _actionCompletionPercentage;

        //Additional read only properties
        public double TotalValueInBudget
        { 
            get 
            {
                GetTotalValueInBudget();
                return _totalValueInBudget; 
            } 
        }
        public double TotalValueAccounted
        {
            get
            {
                GetTotalValueAccounted();
                return _totalValueAccounted;
            }
        }
        public Dictionary<string, double> TotalValueInBudgetByType
        {
            get
            {
                GetTotalValueInBudgetByType();
                return _totalValueInBudgetByType;
            }
        }
        public Dictionary<string, List<FinancialLine>> TotalFinancialLineByType
        {
            get
            {
                GetFinancialLinesByType();
                return _totalFinancialLineByType;
            }
        }
        public Dictionary<int, Dictionary<string, DateTime>> ChronogramsMilesones
        {
            get
            {
                GetChronogramsMilestones();
                return _chronogramsMilestones;
            }
        }
        public int ActionPlanYear
        {
            get
            {
                GetActionPlanYear();
                return _actionPlanYear;
            }
        }
        public double ActionCompletionPercentage
        {
            get
            {
                GetActionCompletionPercentage();
                return _actionCompletionPercentage;
            }
        }

        //Private methods
        private void GetTotalValueInBudget()
        {
            _totalValueInBudget = FinancialLines.Select(c => c.BudgetValue).ToList().Sum();
        }
        private void GetTotalValueAccounted()
        {
            _totalValueAccounted = FinancialLines.Select(c => c.AccountedValue).ToList().Sum();
        }
        private void GetTotalValueInBudgetByType()
        {
            var results = FinancialLines.GroupBy(
                p => p.FinancialLineType.Description)
                .ToDictionary(g => g.Key, g => g.Sum(v => v.BudgetValue));
            _totalValueInBudgetByType = results;
        }
        private void GetFinancialLinesByType()
        {
            var results = FinancialLines.GroupBy(
                p => p.FinancialLineType.Description)
                .ToDictionary(g => g.Key, g => g.ToList());
            _totalFinancialLineByType = results;
        }
        private void GetChronogramsMilestones()
        {
            var result = ProjectItem.Chronograms.ToDictionary(g => g.ChronogramRevisionId, g => g.ChronogramMilestones);
            _chronogramsMilestones = result;
        }
        private void GetActionPlanYear()
        {
            _actionPlanYear = ActionPlanRevision.ActionPlanYear;
        }
        private void GetActionCompletionPercentage()
        {
            _actionCompletionPercentage = ProjectItem.GetActionCompletionPercentage();
        }

        //Public Methods

    }
}
