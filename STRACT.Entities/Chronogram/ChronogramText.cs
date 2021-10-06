using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Chronogram
{
    public class ChronogramText
    {
        public int ChronogramTextId { get; set; }
        public string Description { get; set; }
        public bool Repeatable { get; set; }
        public bool Milestone { get; set; }
        public ICollection<ChronogramLine> ChronogramLines { get; set; }

    }
}
