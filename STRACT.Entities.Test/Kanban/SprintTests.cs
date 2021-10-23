using STRACT.Entities.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STRACT.Entities.Test.Kanban
{
    public class SprintTests
    {
        [Fact]
        public void GetTotalPointsInSprintByLocation_TestWithMultipleTasks()
        {
            LocationInKanban location1 = new LocationInKanban { Description = "Location 1" };
            LocationInKanban location2 = new LocationInKanban { Description = "Location 2" };
            LocationInKanban location3 = new LocationInKanban { Description = "Location 3" };
            TaskInKanban taskInKanban1 = new TaskInKanban { LocationInKanban = location1, TaskItem = new TaskItem { Points = 5 } };
            TaskInKanban taskInKanban2 = new TaskInKanban { LocationInKanban = location1, TaskItem = new TaskItem { Points = 10 } };
            TaskInKanban taskInKanban3 = new TaskInKanban { LocationInKanban = location2, TaskItem = new TaskItem { Points = 15 } };
            TaskInKanban taskInKanban4 = new TaskInKanban { LocationInKanban = location3, TaskItem = new TaskItem { Points = 20 } };
            TaskInKanban taskInKanban5 = new TaskInKanban { LocationInKanban = location3, TaskItem = new TaskItem { Points = 25 } };
            Sprint sprint = new Sprint
            {
                Tasks = new List<TaskInKanban>
                {
                    taskInKanban1, taskInKanban2, taskInKanban3, taskInKanban4, taskInKanban5
                }
            };

            Assert.Equal(15, sprint.TotalPointsInSprintByLocation[location1.Description]);
            Assert.Equal(15, sprint.TotalPointsInSprintByLocation[location2.Description]);
            Assert.Equal(45, sprint.TotalPointsInSprintByLocation[location3.Description]);
        }
        [Fact]
        public void GetTotalPointsInSprintByLocation_TestWithoutTasks()
        {
            Sprint sprint = new Sprint
            {
                Tasks = new List<TaskInKanban>()
            };

            Assert.Empty(sprint.TotalPointsInSprintByLocation);
        }
    }
}
