using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Financial
{
    public class FinancialLineSubType
    {
        public int FinancialLineSubTypeId { get; set; }
        public string Description { get; set; }
        public ICollection<FinancialLine> FinancialLines { get; set; }
    }
}
