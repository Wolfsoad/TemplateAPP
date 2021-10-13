using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Kanban
{
    public class LocationInKanban
    {
        public int LocationInKanbanId { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public ICollection<TaskInKanban> Tasks { get; set; }
    }
}
