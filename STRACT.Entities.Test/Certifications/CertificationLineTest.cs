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
            Location location1 = new()
            {
                LocationId = 1,
                Name = "Location 1"
            };
            Location location2 = new()
            {
                LocationId = 2,
                Name = "Location 2"
            };
            CertificationInLocation certifactionLocation1 = new()
            {
                LocationId = 1,
                Location = location1,
                CertificationLineId = 1
            };
            CertificationInLocation certifactionLocation2 = new()
            {
                LocationId = 2,
                Location = location2,
                CertificationLineId = 1
            };
            Audit audit1 = new()
            {
                AuditId = 1,
                Year = 2019,
                Concluded = true,
                LocationId = 1,
                Location = location1
            };
            Audit audit2 = new()
            {
                AuditId = 1,
                Year = 2019,
                Concluded = true,
                LocationId = 1,
                Location = location1
            };
            Audit audit3 = new()
            {
                AuditId = 1,
                Year = 2019,
                Concluded = true,
                LocationId = 2,
                Location = location2
            };
            Audit audit4 = new()
            {
                AuditId = 1,
                Year = 2019,
                Concluded = true,
                LocationId = 1,
                Location = location1
            };
            List<Audit> audits = new List<Audit>
            {
                audit1, audit2, audit3, audit4
            };
            CertificationLine certificationLine = new()
            {
                CertificationLineId = 1,
                CertificationInLocations = new List<CertificationInLocation> { certifactionLocation1, certifactionLocation2 },
                Audits = audits
            };

            Assert.Equal(3, certificationLine.GetAuditsByLocationPerYear(2019)["Location 1"]);
            Assert.Equal(1,certificationLine.GetAuditsByLocationPerYear(2019)["Location 2"]);
        }
        [Fact]
        public void GetAuditsByLocationPerYear_TestDifferentYearsAndLocations()
        {
            Location location1 = new()
            {
                LocationId = 1,
                Name = "Location 1"
            };
            Location location2 = new()
            {
                LocationId = 2,
                Name = "Location 2"
            };
            CertificationInLocation certifactionLocation1 = new()
            {
                LocationId = 1,
                Location = location1,
                CertificationLineId = 1
            };
            CertificationInLocation certifactionLocation2 = new()
            {
                LocationId = 2,
                Location = location2,
                CertificationLineId = 1
            };
            Audit audit1 = new()
            {
                AuditId = 1,
                Year = 2019,
                Concluded = true,
                Location = location1
            };
            Audit audit2 = new()
            {
                AuditId = 1,
                Year = 2021,
                Concluded = true,
                Location = location1
            };
            Audit audit3 = new()
            {
                AuditId = 1,
                Year = 2020,
                Concluded = true,
                Location = location2
            };
            Audit audit4 = new()
            {
                AuditId = 1,
                Year = 2020,
                Concluded = true,
                Location = location1
            };
            List<Audit> audits = new List<Audit>
            {
                audit1, audit2, audit3, audit4
            };
            CertificationLine certificationLine = new()
            {
                CertificationLineId = 1,
                CertificationInLocations = new List<CertificationInLocation> { certifactionLocation1, certifactionLocation2 },
                Audits = audits
            };

            Assert.Equal(1, certificationLine.GetAuditsByLocationPerYear(2019)["Location 1"]);
            Assert.Equal(1, certificationLine.GetAuditsByLocationPerYear(2020)["Location 1"]);
            Assert.Equal(1, certificationLine.GetAuditsByLocationPerYear(2020)["Location 2"]);
            Assert.Equal(1, certificationLine.GetAuditsByLocationPerYear(2021)["Location 1"]);
        }
        [Fact]
        public void GetAuditsByLocationPerYear_TestInvalidYear()
        {
            Location location1 = new() 
            { 
                LocationId = 1, 
                Name = "Location 1" 
            };
            Location location2 = new() 
            { 
                LocationId = 2, 
                Name = "Location 2" 
            };
            CertificationInLocation certifactionLocation1 = new() 
            { 
                LocationId = 1, 
                Location = location1, 
                CertificationLineId = 1 
            };
            CertificationInLocation certifactionLocation2 = new() 
            { 
                LocationId = 2, 
                Location = location2, 
                CertificationLineId = 1 
            };
            Audit audit1 = new() 
            { 
                AuditId = 1, 
                Year = 2019, 
                Concluded = true, 
                Location = location1 
            };
            Audit audit2 = new()
            {
                AuditId = 1,
                Year = 2021,
                Concluded = true,
                Location = location1
            };
            Audit audit3 = new()
            {
                AuditId = 1,
                Year = 2020,
                Concluded = true,
                Location = location2
            };
            Audit audit4 = new()
            {
                AuditId = 1,
                Year = 2020,
                Concluded = true,
                Location = location1
            };
            List<Audit> audits = new List<Audit>
            {
                audit1, audit2, audit3, audit4
            };
            CertificationLine certificationLine = new()
            {
                CertificationLineId = 1,
                CertificationInLocations = new List<CertificationInLocation> { certifactionLocation1, certifactionLocation2 },
                Audits = audits
            };

            Assert.Equal(0, certificationLine.GetAuditsByLocationPerYear(2000)["Location 1"]);
            Assert.Empty(certificationLine.GetAuditsByLocationPerYear(21500));
            Assert.Empty(certificationLine.GetAuditsByLocationPerYear(-48921));
            Assert.Empty(certificationLine.GetAuditsByLocationPerYear(0));
        }

        [Theory]
        [InlineData(2018, 2021, "2019/1/1",3, 2019, 4)]
        [InlineData(2018, 2021, "2019/1/1", 6, 2019, 2)]
        [InlineData(2018, 2021, "2019/1/1", 4, 2019, 3)]
        [InlineData(2018, 2021, "2019/7/1", 3, 2019, 2)]
        [InlineData(2018, 2021, "2019/1/1", 4, 2018, 0)]
        [InlineData(2018, 2021, "2019/7/1", 12, 2019, 1)]
        [InlineData(2018, 2021, "2019/1/1", 4, 2020, 3)]
        [InlineData(2018, 2021, "2019/7/1", 12, 2020, 1)]
        [InlineData(2018, 2021, "2019/12/1", 12, 2019, 1)]
        [InlineData(2018, 2021, "2019/1/1", 18, 2020, 1)]
        [InlineData(2018, 2021, "2019/1/1", 18, 2021, 0)]
        [InlineData(2018, 2022, "2019/1/1", 18, 2022, 1)]
        public void GetNeededAuditsByLocationBetweenYears_TestValidInputs(int startYear, int endYear, string startDate, int auditFrequency, int yearToTest, int result)
        {
            CertificationInLocation location1 = new()
            {
                LocationId = 1,
                Location = new Location { Name = "Location 1" }
            };
            CertificationInLocation location2 = new()
            {
                LocationId = 2,
                Location = new Location { Name = "Location 2" }
            };
            CertificationLine certificationLine = new()
            {
                CertificationLineId = 1,
                CertificationInLocations = new List<CertificationInLocation> { location1, location2 },
                StartDate = DateTime.Parse(startDate),
                AuditFrequency = auditFrequency
            };

            Assert.Equal(result, certificationLine.GetNeededAuditsByLocationBetweenYears(startYear,endYear)["Location 1"][yearToTest]);
            Assert.Equal(result, certificationLine.GetNeededAuditsByLocationBetweenYears(startYear, endYear)["Location 2"][yearToTest]);

        }
    }
}
