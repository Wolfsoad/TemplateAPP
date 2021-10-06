using STRACT.Entities.Certifications;
using STRACT.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.General
{
    public class LineOfProduct
    {
        public int LineOfProductId { get; set; }
        public string Description { get; set; }

        public ICollection<CertificateProductLine> CertificateProductLines { get; set; }
        public ICollection<ActionItem> ActionItems { get; set; }
    }
}
