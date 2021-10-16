using STRACT.Entities.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STRACT.Entities.Test.Kanban
{
    public class KanbanBoardTests
    {
        [Fact]
        public void RunningSprint_TestSprintIsRunning()
        {
            Sprint sprint = new Sprint { IsSprintEnded = false };
            List<Sprint> sprints = new List<Sprint>
            {
                sprint,
                new Sprint { IsSprintEnded = true},
                new Sprint { IsSprintEnded = true}
            };
            KanbanBoard kanbanBoard = new KanbanBoard { Sprints = sprints};

            Assert.Equal(sprint, kanbanBoard.RunningSprint);
        }
        [Fact]
        public void RunningSprint_TestNoSprintIsRunning()
        {
            List<Sprint> sprints = new List<Sprint>
            {
                new Sprint { IsSprintEnded = true},
                new Sprint { IsSprintEnded = true}
            };
            KanbanBoard kanbanBoard = new KanbanBoard { Sprints = sprints };

            Assert.Null(kanbanBoard.RunningSprint);
        }
    }
}
