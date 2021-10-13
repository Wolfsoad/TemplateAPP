using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STRACT.Entities.General;

namespace STRACT.Entities.Certifications
{
    public class CertificateProductLine
    {
        public int CertificateId { get; set; }
        public Certificate Certificate { get; set; }
        public int ProductLineId { get; set; }
        public LineOfProduct LineOfProduct { get; set; }
    }
}
