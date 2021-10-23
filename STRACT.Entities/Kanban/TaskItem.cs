using STRACT.Entities.Certifications;
using STRACT.Entities.HumanResources;
using STRACT.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Kanban
{
    public class TaskItem
    {
        public int TaskItemId { get; set; }
        public string FeatureActivity { get; set; }
        public string Reason { get; set; }
        public string Details { get; set; }
        public int Points { get; set; }
        public double Hours { get; set; }
        public bool IsRepeatable { get; set; }
        public int? UserInTeamId { get; set; }
        public UserInTeam UserResponsible { get; set; }
        public int OrganizationRoleId { get; set; }
        public OrganizationalRole OrganizationalRole { get; set; }
        public int TaskTypeId { get; set; }
        public TaskType TaskType { get; set; }
        public int AuditId { get; set; }
        public Audit Audit { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public int DepartmentId { get; set; }
        public Department RequestedBy { get; set; }
        public TaskInKanban TaskInKanban { get; set; }
    }
}
