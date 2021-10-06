using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.CommissionProposals
{
    public class ProposalStatus
    {
        public int ProposalStatusId { get; set; }
        public string Text { get; set; }
        public ICollection<Decision> Decisions { get; set; }
    }
}
