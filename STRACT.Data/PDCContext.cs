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
using STRACT.Entities.Financial;

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
        public DbSet<ActionGroup> ActionGroups { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LineOfProduct> LinesOfProducts { get; set; }
        public DbSet<AlertType> AlertTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<FinancialLineType> FinancialLineTypes { get; set; }
        public DbSet<FinancialLineSubType> FinancialLineSubTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "ApplicationUser");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles").HasKey(n => new {n.RoleId, n.UserId });
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins").HasKey(n => n.UserId);
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens").HasKey(c => c.UserId);
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
            builder.Entity<ActionGroup>(entity => entity.ToTable("ActionGroups"));

            builder.Entity<Topic>(entity => entity.ToTable("Topics"));
            builder.Entity<Location>(entity => entity.ToTable("Locations"));
            builder.Entity<LineOfProduct>(entity => entity.ToTable("LinesOfProducts"));
            builder.Entity<AlertType>(entity => entity.ToTable("AlertTypes"));

            builder.Entity<UserInTeam>().HasKey(m => m.UserInTeamId);

            builder.Entity<UserInTeam>().Ignore(u => u.TasksNotCompleted);
            builder.Entity<UserInTeam>().Ignore(u => u.TaskItensInActiveSprints);

            builder.Entity<FinancialLine>().Ignore(u => u.AdjudicatedValueInEuro);
            builder.Entity<Currency>(entity => entity.ToTable("Currencies"));
            builder.Entity<FinancialLineType>(entity => entity.ToTable("FinancialLineTypes"));
            builder.Entity<FinancialLineSubType>(entity => entity.ToTable("FinancialLineSubTypes"));

        }
    }
}
