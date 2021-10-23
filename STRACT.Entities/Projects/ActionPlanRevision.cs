using STRACT.Entities.Users;
using STRACT.Entities.CommissionProposals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Projects
{
    public class ActionPlanRevision
    {
        public int ActionPlanRevisionId { get; set; }
        public string RevisionDescription { get; set; }
        public DateTime RevisionDate { get; set; }
        public double Budget { get; set; }
        public int ActionPlanYear { get; set; }
        public int Version { get; set; }
        public int? UserInTeamId { get; set; }
        public UserInTeam UserInTeam { get; set; }
        public int? ProposalId { get; set; }
        public Proposal Proposal { get; set; }
        public ICollection<ActionItem> ActionItems { get; set; }

        //Private properties
        private double _actionPlanCompletionPercentage;

        //Public properties
        public double ActionPlanCompletionPercentage
        {
            get
            {
                GetAverageCompletion();
                return _actionPlanCompletionPercentage;
            }
        }

        //Private methods
        private void GetAverageCompletion()
        {
            _actionPlanCompletionPercentage = ActionItems.Average(a => a.ActionCompletionPercentage);
        }
    }
}
