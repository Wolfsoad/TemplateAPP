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
        //Private Properties

        //Public extra properties

        //Private Methods

        //Public Methods
        public IDictionary<string,int> GetAuditsByLocationPerYear(int year)
        {
            DateTime datetime;
            if (DateTime.TryParse(string.Format("1/1/{0}", year), out datetime))
            {
                var result = Audits.Where(a => a.Year == year)
                    .Where(a => a.Concluded == true)
                    .GroupBy(a => a.Location.Name)
                    .ToDictionary(a => a.Key, g => g.Count());
                return result;
            }
            else
            {
                return new Dictionary<string,int>();
            }
        }
    }
}
