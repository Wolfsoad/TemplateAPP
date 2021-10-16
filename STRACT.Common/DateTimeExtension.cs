using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Common
{
    public static class DateTimeExtension
    {
        public static DateTime AddWorkDays(this DateTime date, int workingDays, IDictionary<int,bool> ValidWorkingDays, IDictionary<string, DateTime> holidays = null, List<DateTime> userHolidays = null)
        {
            int direction = workingDays < 0 ? -1 : 1;
            //Constructing dictionaries if null
            if (holidays == null) new Dictionary<string, DateTime>();
            if (userHolidays == null) new Dictionary<string, DateTime>();

            //Logic
            DateTime newDate = date;
            while (workingDays != 0)
            {
                newDate = newDate.AddDays(direction);
                if ((ValidWorkingDays[(int)newDate.DayOfWeek]) && !(holidays.Values.ToList()).Contains(newDate) && !userHolidays.Contains(newDate))
                {
                    workingDays -= direction;
                }
            }
            return newDate;
        }
        public static int GetWorkDays(DateTime startDate, DateTime endDate, IDictionary<int, bool> ValidWorkingDays, IDictionary<string, DateTime> holidays = null, List<DateTime> userHolidays = null)
        {
            //Constructing dictionaries if null
            if (holidays == null) new Dictionary<string, DateTime>();
            if (userHolidays == null) new Dictionary<string, DateTime>();

            //Logic
            List<DateTime> allDaysBetweenDates = new List<DateTime>();
            if (startDate <= endDate)
            {
                allDaysBetweenDates = Enumerable
                    .Range(0, 1 + endDate.Subtract(startDate).Days)
                    .Select(offset => startDate.AddDays(offset))
                    .ToList();
            }
            else
            {
                allDaysBetweenDates = Enumerable
                    .Range(0, 1 + startDate.Subtract(endDate).Days)
                    .Select(offset => endDate.AddDays(offset))
                    .ToList();
            }
            List<DateTime> allDaysMinusNotWorkingDays = allDaysBetweenDates
                .FindAll(date => ValidWorkingDays[(int)date.DayOfWeek] == true)
                .ToList();
            List<DateTime> allDaysMinusHolidaysAndNotWorkDays = allDaysMinusNotWorkingDays
                .FindAll(date => !holidays.Values.Contains(date))
                .ToList();
            List<DateTime> allDaysMinusHolidaysAndNotWorkDaysAndUserHolidays = allDaysMinusHolidaysAndNotWorkDays
                .FindAll(date => !userHolidays.Contains(date))
                .ToList();
            return allDaysMinusHolidaysAndNotWorkDaysAndUserHolidays.Count;
        }
        public static Dictionary<string, DateTime> GetNationalHolidaysBetweenDates(DateTime startDate, DateTime endDate)
        {
            int firstYear = startDate.Year;
            int lastYear = endDate.Year;
            Dictionary<string, DateTime> temporatyListOfHolidays = new Dictionary<string, DateTime> ();
            for (int i = firstYear; i <= lastYear; i++)
            {
                temporatyListOfHolidays.Add("New Year" + " " + i, new DateTime(i, 1, 1)); 
                temporatyListOfHolidays.Add("Christmas" + " " + i, new DateTime(i, 12, 25)); 
                temporatyListOfHolidays.Add("Labor day" + " " + i, new DateTime(i, 5, 1)); 
                temporatyListOfHolidays.Add("Liberty Day" + " " + i, new DateTime(i, 4, 25)); 
                temporatyListOfHolidays.Add("Portugal Day" + " " + i, new DateTime(i, 6, 1));
                temporatyListOfHolidays.Add("Republic Day" + " " + i, new DateTime(i, 10, 5));
                temporatyListOfHolidays.Add("All saints" + " " + i, new DateTime(i, 11, 1));
                temporatyListOfHolidays.Add("Independence Day" + " " + i, new DateTime(i, 12, 1)); 
                temporatyListOfHolidays.Add("Conception" + " " + i, new DateTime(i, 12, 8)); 
                temporatyListOfHolidays.Add("Saint John" + " " + i, new DateTime(i, 6, 24));
                temporatyListOfHolidays.Add("Easter" + " " + i, new DateTime(i, GetEasterMonth(i), GetEasterDay(i))); 
                temporatyListOfHolidays.Add("Carnival" + " " + i, new DateTime(i, GetEasterMonth(i), GetEasterDay(i)).AddDays(-47)); 
                temporatyListOfHolidays.Add("Corpus Christi" + " " + i, new DateTime(i, GetEasterMonth(i), GetEasterDay(i)).AddDays(60)); 
            }
            return temporatyListOfHolidays;
        }
        public static Dictionary<int, bool> GetWorkingWeekDays()
        {
            Dictionary<int, bool> temporaryWorkDays = new Dictionary<int, bool>
            {
                { (int)DayOfWeek.Sunday, false},
                {(int)DayOfWeek.Monday, true},
                {(int)DayOfWeek.Tuesday, true},
                {(int)DayOfWeek.Wednesday, true},
                {(int)DayOfWeek.Thursday, true},
                {(int)DayOfWeek.Friday, true},
                {(int)DayOfWeek.Saturday, false}
            };
            return temporaryWorkDays;
        }
        public static int GetEasterMonth(int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            return (h + l - 7 * m + 114) / 31;
        }
        public static int GetEasterDay(int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            return 1 + (h + l - 7 * m + 114 ) % 31;
        }
    }
}
