using STRACT.Entities.Financial;
using STRACT.Entities.Projects;
using STRACT.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.CommissionProposals
{
    public class Proposal
    {
        public int ProposalId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateSent { get; set; }
        public string Path { get; set; }
        public int CommissionId { get; set; }
        public Commission Commission { get; set; }
        public int UserId { get; set; }
        public UserInTeam Responsible { get; set; }
        public ActionPlanRevision ActionPlanRevision { get; set; }
        public ICollection<FinancialLine> FinancialLines { get; set; }
    }
}
