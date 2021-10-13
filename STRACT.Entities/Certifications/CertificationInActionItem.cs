using STRACT.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Certifications
{
    public class CertificationInActionItem
    {
        public int ActionItemId { get; set; }
        public ActionItem ActionItem { get; set; }
        public int CertificationLineId { get; set; }
        public CertificationLine Certification { get; set; }
    }
}
