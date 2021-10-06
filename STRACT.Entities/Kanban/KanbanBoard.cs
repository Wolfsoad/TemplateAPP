using STRACT.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Kanban
{
    public class KanbanBoard
    {
        public int KanbanId { get; set; }
        public int ProjectItemId { get; set; }
        public ProjectItem ProjectItem { get; set; }
        public ICollection<Sprint> Sprints { get; set; }
        public ICollection<TaskInKanban> Tasks { get; set; }

    }
}
