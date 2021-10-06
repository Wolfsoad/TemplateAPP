﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Kanban
{
    public class TaskType
    {
        public int TaskTypeId { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; }
    }
}
