using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Kanban
{
    public class TaskInKanban
    {
        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
        public int KanbanBoardId { get; set; }
        public KanbanBoard KanbanBoard { get; set; }
        public int? SprintId { get; set; }
        public Sprint Sprint { get; set; }
        public int LocationInKanbanId { get; set; }
        public LocationInKanban LocationInKanban { get; set; }
    }
}
