using STRACT.Common;
using STRACT.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Chronogram
{
    public class ChronogramLine
    {
        public int ChronogramLineId { get; set; }
        public DateTime PlannedStart { get; set; }
        public int DurationInDays { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public double PercentOfConclusion { get; set; }
        public bool IsActive { get; set; }
        public int ChronogramTextId { get; set; }
        public ChronogramText ChronogramText { get; set; }
        public int ChronogramRevisionId { get; set; }
        public ChronogramRevision ChronogramRevision { get; set; }

        //Private properties
        private DateTime _plannedEnd;
        public DateTime PlannedEnd 
        { 
            get 
            {
                GetPlannedEndDate();
                return _plannedEnd; 
            } 
        }
        //Private Methods
        private void GetPlannedEndDate()
        {
            _plannedEnd = DateTimeExtension.AddWorkDays(
                PlannedStart, 
                DurationInDays, 
                DateTimeExtension.GetWorkingWeekDays(),
                DateTimeExtension.GetNationalHolidaysBetweenDates(PlannedStart, PlannedStart.AddDays(DurationInDays)),
                ChronogramRevision.User.PersonalHolidaysDates);
        }
    }
}
