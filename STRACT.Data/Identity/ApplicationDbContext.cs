using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using STRACT.Identity.Entities;
using STRACT.Entities.Declaration;
using STRACT.Entities.HumanResources;
using STRACT.Entities.Users;
using STRACT.Entities.Certifications;
using STRACT.Entities.CommissionProposals;
using STRACT.Entities.Kanban;
using STRACT.Entities.Chronogram;
using STRACT.Entities.Projects;
using STRACT.Entities.General;
using STRACT.Entities.Financial;

namespace STRACT.Data.Identity
{
    public class ApplicationDbContext : AuditableIdentityContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CertificateProductLine> CertificateProductLines { get; set; }
        public DbSet<CertificationInActionItem> CertificationInActionItems { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<LocationInKanban> LocationInKanbans { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("PDC"); 
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "ApplicationUser", "Identity");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role" ,"Identity");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "Identity");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Identity");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Identity");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims", "Identity");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity") ;
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
            builder.Entity<TaskInKanban>().HasOne(m =>m.Sprint).WithMany().HasForeignKey(m => m.SprintId);
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
            builder.Entity<UserInTeam>().HasKey(m => m.UserInTeamId);
            builder.Entity<UserInTeam>().Ignore(m => m.TasksNotCompleted);
            builder.Entity<UserInTeam>().Ignore(m => m.TaskItensInActiveSprints);

            builder.Entity<FinancialLine>().Ignore(u => u.AdjudicatedValueInEuro);
        }
    }
}
