using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STRACT.Entities.HumanResources;
using STRACT.Entities.Users;
using STRACT.Data.Identity;
using STRACT.Entities.Declaration;
using STRACT.Entities.Certifications;
using STRACT.Entities.CommissionProposals;
using STRACT.Entities.Kanban;
using STRACT.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using STRACT.Entities.Projects;
using STRACT.Entities.General;

namespace STRACT.Data
{
    public class PDCContext : AuditableIdentityContext
    {
        public PDCContext(DbContextOptions<PDCContext> options) : base(options)
        {

        }

        public DbSet<CertificateProductLine> CertificateProductLines { get; set; }
        public DbSet<CertificationInActionItem> CertificationInActionItems { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<LocationInKanban> LocationInKanbans { get; set; }
        public DbSet<ActivityGroup> ActivityGroups { get; set; }
        public DbSet<DeclarationItem> Declarations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("PDC");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User", "Identity");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role", "Identity");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "Identity").HasKey(n => new {n.RoleId, n.UserId });
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Identity");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Identity").HasKey(n => n.UserId);
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims", "Identity");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity").HasKey(c => c.UserId);
            });

            builder.Entity<CertificateProductLine>().HasKey(m => m.CertificateId);
            builder.Entity<CertificateProductLine>().HasKey(m => m.ProductLineId);
            builder.Entity<CertificationInActionItem>().HasKey(m => m.ActionItemId);
            builder.Entity<CertificationInActionItem>().HasKey(m => m.CertificationLineId);

            builder.Entity<CommissionForProject>().HasKey(m => m.CommissionId);
            builder.Entity<CommissionForProject>().HasKey(m => m.ProjectId);

            builder.Entity<DeclarationSignature>().HasKey(m => m.DeclarationItemId);
            builder.Entity<DeclarationSignature>().HasKey(m => m.SignatureId);

            builder.Entity<ActivityInGroup>().HasKey(m => m.ActivityGroupId);
            builder.Entity<ActivityInGroup>().HasKey(m => m.ActivityId);

            builder.Entity<KanbanBoard>().HasKey(m => m.KanbanId);
            builder.Entity<TaskInKanban>().HasKey(m => m.KanbanBoardId);
            builder.Entity<TaskInKanban>().HasKey(m => m.LocationInKanbanId);
            builder.Entity<TaskInKanban>().HasKey(m => m.TaskItemId);
            builder.Entity<TaskInKanban>().HasOne(m => m.Sprint).WithMany().HasForeignKey(m => m.SprintId);
            builder.Entity<TaskType>(entity => entity.ToTable("TaskTypes"));
            builder.Entity<LocationInKanban>(entity => entity.ToTable("LocationInKanbans"));

            builder.Entity<AlertInProject>().HasKey(m => m.AlertTypeId);
            builder.Entity<AlertInProject>().HasKey(m => m.ProjectItemId);
            builder.Entity<LocationsForAction>().HasKey(m => m.ActionLineId);
            builder.Entity<LocationsForAction>().HasKey(m => m.LocationId);
            builder.Entity<ProjectMember>().HasKey(m => m.FunctionalRoleId);
            builder.Entity<ProjectMember>().HasKey(m => m.ProjectItemId);
            builder.Entity<ProjectMember>().HasKey(m => m.UserId);
            builder.Entity<TopicInProject>().HasKey(m => m.TopicId);
            builder.Entity<TopicInProject>().HasKey(m => m.ProjectItemId);

            builder.Entity<UserInTeam>().HasKey(m => m.UserId);

            builder.Entity<ToDoTask>().HasOne(user => user.User).WithMany().HasForeignKey(user => user.UserInTeamId);
            builder.Entity<UserInTeam>().HasMany(user => user.ToDoTasks);
            builder.Entity<TaskItem>().HasOne(user => user.Responsible).WithMany().HasForeignKey(user => user.UserId);
            builder.Entity<UserInTeam>().HasMany(user => user.TaskItems);
        }
    }
}
