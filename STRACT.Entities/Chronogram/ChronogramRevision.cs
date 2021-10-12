using STRACT.Common;
using STRACT.Entities.Projects;
using STRACT.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Chronogram
{
    public class ChronogramRevision
    {
        public int ChronogramRevisionId { get; set; }
        public string RevisionDescription { get; set; }
        public DateTime RevisionDate { get; set; }
        public int Version { get; set; }
        public int? UserId { get; set; }
        public UserInTeam Responsible { get; set; }
        public int ProjectItemId { get; set; }
        public ProjectItem ProjectItem { get; set; }
        public ICollection<ChronogramLine> ChronogramLines { get; set; }

        //Private properties
        private double _averageCompletion;
        private double _totalDaysOfChronogramRevision;
        private Dictionary<string, DateTime> _chronogramMilestones;
        //ReadOnly Properties
        public double AverageCompletion
        {
            get 
            {
                GetAverageCompletion();
                return _averageCompletion;
            }
        }
        public double TotalDaysOfChronogramRevision 
        {
            get 
            {
                GetTotalDaysOfChronogramRevision();
                return _totalDaysOfChronogramRevision; 
            } 
        }
        public Dictionary<string,DateTime> ChronogramMilestones
        {
            get
            {
                GetChronogramMilestones();
                return _chronogramMilestones;
            }
        }
        //Internal Methods
        private void GetAverageCompletion()
        {
            if (ChronogramLines != null)
            {
                List<double> CompletionValues = ChronogramLines.Where(c => c.IsActive).Select(c => c.PercentOfConclusion).ToList();
                _averageCompletion = CompletionValues.Average();
            }
            else
            {
                _averageCompletion = 0;
            }            
        }
        private void GetTotalDaysOfChronogramRevision()
        {
            if (ChronogramLines != null)
            {
                List<DateTime> StartPlannedDates = ChronogramLines
                    .Where(c => c.IsActive)
                    .Select(c => c.PlannedStart)
                    .ToList();
                List<DateTime> EndPlannedDates = ChronogramLines
                    .Where(c => c.IsActive)
                    .Select(c => c.PlannedEnd)
                    .ToList();
                DateTime startDate = StartPlannedDates.Min();
                DateTime endDate = EndPlannedDates.Max();
                _totalDaysOfChronogramRevision = DateTimeExtension.GetWorkDays(startDate, endDate,
                    DateTimeExtension.GetWorkingWeekDays(), 
                    DateTimeExtension.GetNationalHolidaysBetweenDates(startDate , endDate) , 
                    Responsible.PersonalHolidaysDates);
            }
            else
            {
                _totalDaysOfChronogramRevision = 0;
            }
        }
        private void GetChronogramMilestones()
        {
            var result = ChronogramLines
                .Where(n => n.ChronogramText.Milestone == true && n.IsActive == true)
                .ToDictionary(g => g.ChronogramText.Description, g => g.PlannedEnd);
            _chronogramMilestones = result;
        }
    }
}
