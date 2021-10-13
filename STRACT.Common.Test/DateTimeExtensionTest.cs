using System;
using System.Collections.Generic;
using System.Linq;
using STRACT.Common;
using Xunit;

namespace STRACT.Common.Test
{
    public class DateTimeExtensionTest
    {
        [Fact]
        public void AddWorkDays_AddDaysMidWeek()
        {
            Dictionary<int, bool> workingDays = new Dictionary<int, bool> 
            {
                {(int)DayOfWeek.Sunday, false},
                {(int)DayOfWeek.Monday, true},
                {(int)DayOfWeek.Tuesday, true},
                {(int)DayOfWeek.Wednesday, true},
                {(int)DayOfWeek.Thursday, true},
                {(int)DayOfWeek.Friday, true},
                {(int)DayOfWeek.Saturday, false},
            };
            DateTime newDate = DateTimeExtension.AddWorkDays(DateTime.Parse("11/10/2021"), 3, workingDays, new Dictionary<string, DateTime>(), new List<DateTime>());

            Assert.True(newDate.DayOfWeek == DayOfWeek.Thursday);
        }
        [Fact]
        public void AddWorkDays_AddDaysWithWeekendInMiddle()
        {
            Dictionary<int, bool> workingDays = new Dictionary<int, bool>
            {
                {(int)DayOfWeek.Sunday, false},
                {(int)DayOfWeek.Monday, true},
                {(int)DayOfWeek.Tuesday, true},
                {(int)DayOfWeek.Wednesday, true},
                {(int)DayOfWeek.Thursday, true},
                {(int)DayOfWeek.Friday, true},
                {(int)DayOfWeek.Saturday, false},
            };
            DateTime newDate = DateTimeExtension.AddWorkDays(DateTime.Parse("06/10/2021"), 3, workingDays, new Dictionary<string, DateTime>(), new List<DateTime>());

            Assert.True(newDate.DayOfWeek == DayOfWeek.Monday);
        }
        [Fact]
        public void AddWorkDays_AddDaysStartingAtSaturday()
        {
            Dictionary<int, bool> workingDays = new Dictionary<int, bool>
            {
                {(int)DayOfWeek.Sunday, false},
                {(int)DayOfWeek.Monday, true},
                {(int)DayOfWeek.Tuesday, true},
                {(int)DayOfWeek.Wednesday, true},
                {(int)DayOfWeek.Thursday, true},
                {(int)DayOfWeek.Friday, true},
                {(int)DayOfWeek.Saturday, false},
            };
            DateTime newDate = DateTimeExtension.AddWorkDays(DateTime.Parse("09/10/2021"), 3, workingDays, new Dictionary<string, DateTime>(), new List<DateTime>());

            Assert.True(newDate.DayOfWeek == DayOfWeek.Wednesday);
        }
        [Fact]
        public void AddWorkDays_AddDaysMidWeekWithHolidaysAtWednesday()
        {
            Dictionary<int, bool> workingDays = new Dictionary<int, bool>
            {
                {(int)DayOfWeek.Sunday, false},
                {(int)DayOfWeek.Monday, true},
                {(int)DayOfWeek.Tuesday, true},
                {(int)DayOfWeek.Wednesday, true},
                {(int)DayOfWeek.Thursday, true},
                {(int)DayOfWeek.Friday, true},
                {(int)DayOfWeek.Saturday, false},
            };
            Dictionary<string, DateTime> holidays = new Dictionary<string, DateTime>
            {
                { "First", DateTime.Parse("13/10/2021") }
            };
            DateTime newDate = DateTimeExtension.AddWorkDays(DateTime.Parse("11/10/2021"), 3, workingDays, holidays, new List<DateTime>());

            Assert.True(newDate.DayOfWeek == DayOfWeek.Friday);
        }
        [Fact]
        public void AddWorkDays_AddTenDaysWithHolidaysMidweekAndWorkingAtSaturday()
        {
            Dictionary<int, bool> workingDays = new Dictionary<int, bool>
            {
                {(int)DayOfWeek.Sunday, false},
                {(int)DayOfWeek.Monday, true},
                {(int)DayOfWeek.Tuesday, true},
                {(int)DayOfWeek.Wednesday, true},
                {(int)DayOfWeek.Thursday, true},
                {(int)DayOfWeek.Friday, true},
                {(int)DayOfWeek.Saturday, true},
            };
            Dictionary<string, DateTime> holidays = new Dictionary<string, DateTime>
            {
                { "First", DateTime.Parse("13/10/2021") },
                { "Second", DateTime.Parse("14/10/2021") }
            };
            DateTime newDate = DateTimeExtension.AddWorkDays(DateTime.Parse("11/10/2021"), 10, workingDays, holidays, new List<DateTime>());

            Assert.True(newDate.DayOfWeek == DayOfWeek.Monday);
        }
        [Fact]
        public void GetEasterMonthTest()
        {
            int i = DateTimeExtension.GetEasterMonth(2021);
            int j = DateTimeExtension.GetEasterMonth(2016);

            Assert.True(i == 4);
            Assert.True(j == 3);
        }
        [Fact]
        public void GetEasterDayTest()
        {
            int i = DateTimeExtension.GetEasterDay(2021);
            int j = DateTimeExtension.GetEasterDay(2016);

            Assert.True(i == 4);
            Assert.True(j == 27);
        }
        [Fact]
        public void GetNationalHolidaysTest_HasNewYear()
        {
            Dictionary<string, DateTime> nationalHolidays = new Dictionary<string, DateTime>();
            nationalHolidays = DateTimeExtension.GetNationalHolidaysBetweenDates(new DateTime(2021, 1, 1), new DateTime(2021, 12, 31));

            Assert.Contains<string>("New Year 2021", nationalHolidays.Keys.ToList());
        }
        [Fact]
        public void GetNationalHolidaysTest_HasCorrectEasterDay()
        {
            Dictionary<string, DateTime> nationalHolidays = new Dictionary<string, DateTime>();
            nationalHolidays = DateTimeExtension.GetNationalHolidaysBetweenDates(new DateTime(2021, 1, 1), new DateTime(2021, 12, 31));

            Assert.Contains<string>("Easter 2021", nationalHolidays.Keys.ToList());
            Assert.True(nationalHolidays["Easter 2021"] == new DateTime(2021, 4, 4));
        }
        [Fact]
        public void GetNationalHolidaysTest_HasMultipleYearHolidays()
        {
            Dictionary<string, DateTime> nationalHolidays = new Dictionary<string, DateTime>();
            nationalHolidays = DateTimeExtension.GetNationalHolidaysBetweenDates(new DateTime(2019, 5, 1), new DateTime(2021, 12, 31));

            Assert.Contains<string>("Easter 2021", nationalHolidays.Keys.ToList());
            Assert.Contains<string>("Easter 2020", nationalHolidays.Keys.ToList());
            Assert.Contains<string>("Easter 2019", nationalHolidays.Keys.ToList());
        }
        [Fact]
        public void GetWorkDaysTest_HasCorrectNumberOfDays()
        {
            Dictionary<int, bool> workingDays = new Dictionary<int, bool>
            {
                {(int)DayOfWeek.Sunday, false},
                {(int)DayOfWeek.Monday, true},
                {(int)DayOfWeek.Tuesday, true},
                {(int)DayOfWeek.Wednesday, true},
                {(int)DayOfWeek.Thursday, true},
                {(int)DayOfWeek.Friday, true},
                {(int)DayOfWeek.Saturday, true},
            };
            Dictionary<string, DateTime> holidays = new Dictionary<string, DateTime>
            {
                { "First", DateTime.Parse("13/10/2021") },
                { "Second", DateTime.Parse("14/10/2021") },
                { "Third", DateTime.Parse("20/10/2021") }
            };
            int workDays = DateTimeExtension.GetWorkDays(DateTime.Parse("11/10/2021"), DateTime.Parse("25/10/2021"), workingDays, holidays, new List<DateTime>());

            Assert.Equal(10, workDays);
        }
        [Fact]
        public void GetWorkDaysTest_HasCorrectNumberOfDaysWithUserVacations()
        {
            Dictionary<int, bool> workingDays = new Dictionary<int, bool>
            {
                {(int)DayOfWeek.Sunday, false},
                {(int)DayOfWeek.Monday, true},
                {(int)DayOfWeek.Tuesday, true},
                {(int)DayOfWeek.Wednesday, true},
                {(int)DayOfWeek.Thursday, true},
                {(int)DayOfWeek.Friday, true},
                {(int)DayOfWeek.Saturday, false},
            };
            Dictionary<string, DateTime> holidays = new Dictionary<string, DateTime>
            {
                { "First", DateTime.Parse("13/10/2021") },
                { "Second", DateTime.Parse("14/10/2021") }
            };
            List<DateTime> userHolidays = new List<DateTime>
            {
                new DateTime(2021,10,20),
                new DateTime(2021,10,21)
            };
            int workDays = DateTimeExtension.GetWorkDays(DateTime.Parse("11/10/2021"), DateTime.Parse("25/10/2021"), workingDays, holidays, userHolidays);

            Assert.Equal(7, workDays);
        }
    }
}
