using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.CommissionProposals
{
    public class Commission
    {
        public int CommissionId { get; set; }
        public string Name { get; set; }
        public ICollection<Decision> Decisions { get; set; }
        public ICollection<Proposal> Proposals { get; set; }
        public ICollection<CommissionForProject> CommissionForProjects { get; set; }
    }
}
