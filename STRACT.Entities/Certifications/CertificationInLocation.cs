using STRACT.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Certifications
{
    public class CertificationInLocation
    {
        public int CertificationLineId { get; set; }
        public CertificationLine CertificationLine { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
