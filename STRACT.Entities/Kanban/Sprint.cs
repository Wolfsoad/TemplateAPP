using STRACT.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Kanban
{
    public class Sprint
    {
        public int SprintId { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationInDays { get; set; }
        public int PointsRequired { get; set; }
        public int PointsDone { get; set; }
        public bool IsSprintEnded { get; set; }
        public ICollection<TaskInKanban> Tasks { get; set; }
        //Private properties
        private Dictionary<string, int> _totalPointsInSprintByLocation;

        //Public additional properties
        public Dictionary<string, int> TotalPointsInSprintByLocation
        {
            get
            {
                GetTotalPointsInSprintByLocation();
                return _totalPointsInSprintByLocation;
            }
        }
        //Private methods
        private void GetTotalPointsRequired()
        {
            var result = Tasks.Select(t => t.TaskItem)
                .Sum(t => t.Points);
        }
        private void GetTotalPointsInSprintByLocation()
        {
            _totalPointsInSprintByLocation = Tasks.GroupBy(g => g.LocationInKanban.Description)
                .ToDictionary(g => g.Key, g => g.Sum(p => p.TaskItem.Points));
        }
    }
}
