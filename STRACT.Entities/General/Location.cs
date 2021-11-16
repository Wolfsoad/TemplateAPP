using STRACT.Entities.Certifications;
using STRACT.Entities.Financial;
using STRACT.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.General
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public ICollection<Audit> Audits { get; set; }
        public ICollection<LocationsForAction> Actions { get; set; }
        public ICollection<FinancialLine> FinancialLines { get; set; }
        public ICollection<CertificationInLocation> CertificationInLocations { get; set; }
    }
}
