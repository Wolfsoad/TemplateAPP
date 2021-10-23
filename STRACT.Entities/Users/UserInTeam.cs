using STRACT.Entities.HumanResources;
using STRACT.Entities.Declaration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STRACT.Identity.Entities;
using STRACT.Entities.CommissionProposals;
using STRACT.Entities.Certifications;
using STRACT.Entities.Projects;
using STRACT.Entities.Kanban;
using STRACT.Entities.Chronogram;
using STRACT.Entities.General;

namespace STRACT.Entities.Users
{
    public class UserInTeam
    {
        public int UserInTeamId { get; set; }
        public bool Active { get; set; }
        public int OrganizationalRoleId { get; set; }
        public OrganizationalRole OrganizationalRole { get; set; }
        public ICollection<DeclarationItem> Declarations { get; set; }
        public ICollection<DeclarationRevision> DeclarationRevisions { get; set; }
        public ICollection<DeclarationSignature> DeclarationSignatures { get; set; }
        public ICollection<Proposal> Proposals { get; set; }
        public ICollection<Audit> Audits { get; set; }
        public ICollection<ActionPlanRevision> ActionPlanRevisions { get; set; }
        public ICollection<ProjectItem> ProjectsCoordinated { get; set; }
        public ICollection<ProjectMember> ProjectsInTeam { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; }
        public ICollection<ChronogramRevision> ChronogramRevisions { get; set; }
        public ICollection<ToDoTask> ToDoTasks { get; set; }
        public ICollection<UserHoliday> PersonalHolidays { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<DateTime> PersonalHolidaysDates
        {
            get
            {
                return PersonalHolidays.Select(p => p.DataOfHoliday).ToList();
            }
        }

        //Private properties
        private List<ToDoTask> _tasksNotCompleted;
        private List<TaskItem> _taskItensInActiveSprints;

        //Public extra properties
        public List<ToDoTask> TasksNotCompleted 
        { 
            get 
            {
                GetTasksNotCompleted();
                return _tasksNotCompleted;
            }
        }
        public List<TaskItem> TaskItensInActiveSprints
        {
            get
            {
                GetTasksInActiveSprints();
                return _taskItensInActiveSprints;
            }
        }

        //Private methods
        private void GetTasksNotCompleted()
        {
            _tasksNotCompleted = ToDoTasks.Where(t => !t.IsConcluded).ToList();
        }
        private void GetTasksInActiveSprints()
        {
            _taskItensInActiveSprints = TaskItems.Where(t => t.TaskInKanban.IsTaskInAnOpenSprint).ToList();
        }
    }
}
