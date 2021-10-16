using STRACT.Entities.General;
using STRACT.Entities.Kanban;
using STRACT.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace STRACT.Entities.Test.Users
{
    public class UserInTeamTests
    {
        [Fact]
        public void GetTasksNotCompleted_AllTasksNotCompletedTest()
        {
            var tasks = new List<ToDoTask> 
            {
                new ToDoTask { IsConcluded = false},
                new ToDoTask { IsConcluded = false},
                new ToDoTask { IsConcluded = false}
            };
            UserInTeam userInTeam = new UserInTeam { ToDoTasks = tasks};

            Assert.Equal(tasks.Count, userInTeam.TasksNotCompleted.Count);
        }
        [Fact]
        public void GetTasksNotCompleted_SomeTasksNotCompletedTest()
        {
            var tasks = new List<ToDoTask>
            {
                new ToDoTask { IsConcluded = false},
                new ToDoTask { IsConcluded = false},
                new ToDoTask { IsConcluded = true}
            };
            UserInTeam userInTeam = new UserInTeam { ToDoTasks = tasks };

            Assert.Equal(tasks.Count-1, userInTeam.TasksNotCompleted.Count);
        }
        [Fact]
        public void GetTasksNotCompleted_NoTasksNotCompletedTest()
        {
            var tasks = new List<ToDoTask>
            {
                new ToDoTask { IsConcluded = true},
                new ToDoTask { IsConcluded = true},
                new ToDoTask { IsConcluded = true}
            };
            UserInTeam userInTeam = new UserInTeam { ToDoTasks = tasks };

            Assert.Empty(userInTeam.TasksNotCompleted);
        }
        [Fact]
        public void GetTasksInActiveSprints_TaskItensExistsInActiveSprints()
        {
            #region Task1
            TaskItem taskItem = new TaskItem();
            Sprint sprint = new Sprint { IsSprintEnded = false};
            TaskInKanban taskInKanban = new TaskInKanban { TaskItem = taskItem, Sprint = sprint};
            taskItem.TaskInKanban = taskInKanban;
            #endregion
            UserInTeam userInTeam = new UserInTeam 
            { 
                TaskItems = new List<TaskItem> { taskItem} 
            };

            Assert.Contains(taskItem, userInTeam.TaskItensInActiveSprints);
        }
        [Fact]
        public void GetTasksInActiveSprints_TaskItensExistsInActiveSprintsAndOtherInInactiveSprint()
        {
            #region Task1
            TaskItem taskItem = new TaskItem();
            Sprint sprint = new Sprint { IsSprintEnded = false };
            TaskInKanban taskInKanban = new TaskInKanban { TaskItem = taskItem, Sprint = sprint };
            taskItem.TaskInKanban = taskInKanban;
            #endregion
            #region Task2
            TaskItem taskItem2 = new TaskItem();
            Sprint sprint2 = new Sprint { IsSprintEnded = true };
            TaskInKanban taskInKanban2 = new TaskInKanban { TaskItem = taskItem2, Sprint = sprint2 };
            taskItem2.TaskInKanban = taskInKanban2;
            #endregion
            UserInTeam userInTeam = new UserInTeam
            {
                TaskItems = new List<TaskItem> 
                { 
                    taskItem,
                    taskItem2
                }
            };

            Assert.Contains(taskItem, userInTeam.TaskItensInActiveSprints);
            Assert.DoesNotContain(taskItem2, userInTeam.TaskItensInActiveSprints);
        }
        [Fact]
        public void GetTasksInActiveSprints_OnlyTasksInInactiveSprints()
        {
            #region Task1
            TaskItem taskItem = new TaskItem();
            Sprint sprint = new Sprint { IsSprintEnded = true };
            TaskInKanban taskInKanban = new TaskInKanban { TaskItem = taskItem, Sprint = sprint };
            taskItem.TaskInKanban = taskInKanban;
            #endregion
            #region Task2
            TaskItem taskItem2 = new TaskItem();
            Sprint sprint2 = new Sprint { IsSprintEnded = true };
            TaskInKanban taskInKanban2 = new TaskInKanban { TaskItem = taskItem2, Sprint = sprint2 };
            taskItem2.TaskInKanban = taskInKanban2;
            #endregion
            UserInTeam userInTeam = new UserInTeam
            {
                TaskItems = new List<TaskItem>
                {
                    taskItem,
                    taskItem2
                }
            };

            Assert.Empty(userInTeam.TaskItensInActiveSprints);
        }
    }
}
