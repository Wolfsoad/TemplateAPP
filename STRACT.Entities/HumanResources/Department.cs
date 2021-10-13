using STRACT.Entities.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; }
    }
}
