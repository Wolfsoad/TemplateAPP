using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Certifications
{
    public class Certificate
    {
        public int CertificateId { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public DateTime EmissionDate { get; set; }
        public DateTime ValidUntil { get; set; }
        public string CertificateUrl { get; set; }
        public int CertificationLineId { get; set; }
        public CertificationLine CertificationLine { get; set; }
        public ICollection<CertificateProductLine> CertificateProductLines { get; set; }

    }
}
