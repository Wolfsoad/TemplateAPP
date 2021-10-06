using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Certifications
{
    public class CertificationLine
    {
        public int CertificationLineId { get; set; }
        public string Description { get; set; }
        public bool FactoryAudit { get; set; }
        public string FolderPath { get; set; }
        public int AuditFrequency { get; set; }
        public int EntityId { get; set; }
        public Entity Entity { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Audit> Audits { get; set; }
        public ICollection<CertificationInActionItem> CertificationsInActionItens { get; set; }
    }
}
