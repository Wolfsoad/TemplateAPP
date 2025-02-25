﻿using STRACT.Entities.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class OrganizationalRole
    {
        public int OrganizationalRoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ActivityInOrganizationalRole> ActivityInOrganizationalRoles { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; }
    }
}
