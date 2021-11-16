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
        public DateTime StartDate { get; set; }
        public int EntityId { get; set; }
        public Entity Entity { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Audit> Audits { get; set; }
        public ICollection<CertificationInActionItem> CertificationsInActionItens { get; set; }
        public ICollection<CertificationInLocation> CertificationInLocations { get; set; }
        //Private Properties

        //Public extra properties
        public IDictionary<string,int> AuditsPerLocationCurrentYear
        {
            get { return GetAuditsByLocationPerYear(DateTime.Now.Year); }
        }

        //Private Methods

        //Public Methods
        public IDictionary<string,int> GetAuditsByLocationPerYear(int year)
        {
            if (DateTime.TryParse(string.Format("{0}/1/1", year), out DateTime datetime))
            {
                var result = new Dictionary<string,int>();
                var availableLocations = CertificationInLocations
                             .Where(c => c.CertificationLineId == CertificationLineId)
                             .Select(c => c.Location);
                foreach (var loc in availableLocations)
                {
                    int auditsPerformed = Audits.Where(a => a.Year == year)
                                   .Where(a => a.Concluded == true && loc.LocationId == a.Location.LocationId)
                                   .Count();
                    result.Add(loc.Name, auditsPerformed);              
                }
                return result;
            }
            else
            {
                return new Dictionary<string, int>();
            }
        }

        public IDictionary<string,Dictionary<int,int>> GetNeededAuditsByLocationBetweenYears(int startYear, int endYear)
        {
            Dictionary<string, Dictionary<int,int>> result = new Dictionary<string, Dictionary<int,int>>();
            if (DateTime.TryParse(string.Format("{0}/1/1", startYear), out DateTime startYearDate)
                && DateTime.TryParse(string.Format("{0}/12/31", endYear), out DateTime endYearDate))
            {
                foreach (var location in CertificationInLocations)
                {
                    DateTime auditDate;
                    Dictionary<int, int> yearResults = new Dictionary<int, int>();
                    for (int i = startYear; i <= endYear; i++)
                    {
                        int auditPerYear = 0;
                        auditDate = StartDate;
                        do
                        {
                            if (auditDate.Year == i)
                            {
                                auditPerYear = ++auditPerYear;
                            }
                            auditDate = auditDate.AddMonths(AuditFrequency);

                        } while (auditDate <= endYearDate);

                        yearResults.Add(i, auditPerYear);
                    }
                    result.Add(location.Location.Name, yearResults);
                }
                
            }
            return result;
        }

        public int GetNeededAuditsCurrentYear(string location)
        {
            return GetNeededAuditsByLocationBetweenYears(DateTime.Now.Year, DateTime.Now.Year+1)[location][DateTime.Now.Year];
        }
    }
}
