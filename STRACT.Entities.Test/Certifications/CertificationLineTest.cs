using STRACT.Entities.Certifications;
using STRACT.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STRACT.Entities.Test.Certifications
{
    public class CertificationLineTest
    {
        [Fact]
        public void GetAuditsByLocationPerYear_TestSameYearDifferentLocations()
        {
            Location location1 = new Location { LocationId = 1, Name = "Location 1" };
            Location location2 = new Location { LocationId = 2, Name = "Location 2" };
            Audit audit1 = new Audit { AuditId = 1, Year = 2019, Concluded = true, Location = location1 };
            Audit audit2 = new Audit { AuditId = 1, Year = 2019, Concluded = true, Location = location1 };
            Audit audit3 = new Audit { AuditId = 1, Year = 2019, Concluded = true, Location = location2 };
            Audit audit4 = new Audit { AuditId = 1, Year = 2019, Concluded = true, Location = location1 };
            List<Audit> audits = new List<Audit>
            {
                audit1, audit2, audit3, audit4
            };

            CertificationLine certificationLine = new CertificationLine
            {
                CertificationLineId = 1,
                Audits = audits,
            };

            Assert.Equal(3, certificationLine.GetAuditsByLocationPerYear(2019)["Location 1"]);
            Assert.Equal(1,certificationLine.GetAuditsByLocationPerYear(2019)["Location 2"]);
        }
        [Fact]
        public void GetAuditsByLocationPerYear_TestDifferentYearsAndLocations()
        {
            Location location1 = new Location { LocationId = 1, Name = "Location 1" };
            Location location2 = new Location { LocationId = 2, Name = "Location 2" };
            Audit audit1 = new Audit { AuditId = 1, Year = 2019, Concluded = true, Location = location1 };
            Audit audit2 = new Audit { AuditId = 1, Year = 2021, Concluded = true, Location = location1 };
            Audit audit3 = new Audit { AuditId = 1, Year = 2020, Concluded = true, Location = location2 };
            Audit audit4 = new Audit { AuditId = 1, Year = 2020, Concluded = true, Location = location1 };
            List<Audit> audits = new List<Audit>
            {
                audit1, audit2, audit3, audit4
            };

            CertificationLine certificationLine = new CertificationLine
            {
                CertificationLineId = 1,
                Audits = audits,
            };

            Assert.Equal(1, certificationLine.GetAuditsByLocationPerYear(2019)["Location 1"]);
            Assert.Equal(1, certificationLine.GetAuditsByLocationPerYear(2020)["Location 1"]);
            Assert.Equal(1, certificationLine.GetAuditsByLocationPerYear(2020)["Location 2"]);
            Assert.Equal(1, certificationLine.GetAuditsByLocationPerYear(2021)["Location 1"]);
        }
        [Fact]
        public void GetAuditsByLocationPerYear_TestInvalidYear()
        {
            Location location1 = new Location { LocationId = 1, Name = "Location 1" };
            Location location2 = new Location { LocationId = 2, Name = "Location 2" };
            Audit audit1 = new Audit { AuditId = 1, Year = 2019, Concluded = true, Location = location1 };
            Audit audit2 = new Audit { AuditId = 1, Year = 2021, Concluded = true, Location = location1 };
            Audit audit3 = new Audit { AuditId = 1, Year = 2020, Concluded = true, Location = location2 };
            Audit audit4 = new Audit { AuditId = 1, Year = 2020, Concluded = true, Location = location1 };
            List<Audit> audits = new List<Audit>
            {
                audit1, audit2, audit3, audit4
            };

            CertificationLine certificationLine = new CertificationLine
            {
                CertificationLineId = 1,
                Audits = audits,
            };

            Assert.Empty(certificationLine.GetAuditsByLocationPerYear(2000));
            Assert.Empty(certificationLine.GetAuditsByLocationPerYear(21500));
            Assert.Empty(certificationLine.GetAuditsByLocationPerYear(-48921));
            Assert.Empty(certificationLine.GetAuditsByLocationPerYear(0));
        }
    }
}
