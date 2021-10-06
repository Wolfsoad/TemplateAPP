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
        public int UserId { get; set; }
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
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
