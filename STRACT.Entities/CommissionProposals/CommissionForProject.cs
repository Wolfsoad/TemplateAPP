using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.CommissionProposals
{
    public class CommissionForProject
    {
        public int CommissionId { get; set; }
        public Commission Commission { get; set; }
        public int ProjectId { get; set; }
        public string Proposal { get; set; }
        public string SupportDocuments { get; set; }
        public string Justification { get; set; }
        public string Advantages { get; set; }
    }
}
