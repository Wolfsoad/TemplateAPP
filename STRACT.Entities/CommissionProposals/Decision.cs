using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.CommissionProposals
{
    public class Decision
    {
        public int DecisionId { get; set; }
        public string Subject { get; set; }
        public string Minutes { get; set; }
        public string Description { get; set; }
        public DateTime DateOfDecision { get; set; }
        public int StatusId { get; set; }
        public ProposalStatus Status { get; set; }
        public int CommissionId { get; set; }
        public Commission Commission { get; set; }

    }
}
