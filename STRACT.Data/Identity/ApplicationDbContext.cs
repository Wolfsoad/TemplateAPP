using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
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
        public DbSet<DeclarationItem> Declarations { get; set; }
        public DbSet<ActionGroup> ActionGroups { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LineOfProduct> LinesOfProducts { get; set; }
        public DbSet<AlertType> AlertTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<FinancialLineType> FinancialLineTypes { get; set; }
        public DbSet<FinancialLineSubType> FinancialLineSubTypes { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityGroup> ActivityGroups { get; set; }
        public DbSet<ActivityInGroup> ActivityInGroups {  get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SkillGroup> SkillGroups { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<OrganizationalRole> OrganizationalRoles { get; set; }
        public DbSet<FunctionalRole> FunctionalRoles { get; set; }
        public DbSet<SkillInActivity> SkillInActivity { get; set; }
        public DbSet<UserHoliday> UserHolidays { get; set; }
        public DbSet<UserInTeam> UserInTeam { get; set; }
        public DbSet<UserSkillsEvaluation> UserSkillsEvaluations { get; set; }
        public DbSet<DeclarationItem> DeclarationItems { get; set; }
        public DbSet<DeclarationRevision> DeclarationRevisions { get; set; }
        public DbSet<DeclarationSignature> DeclarationSignatures { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<CertificationLine> CertificationLines { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<ContactPerson> ContactPeople { get; set; }
        public DbSet<CertificationInLocation> CertificationInLocations { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TaskInKanban> TaskInKanbans { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<KanbanBoard> KanbanBoards { get; set; }
        public DbSet<ProjectItem> ProjectItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("PDC");

            #region Identity DB Configuration
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
            #endregion

            #region Certifications DB Configuration
            builder.Entity<CertificateProductLine>().HasKey(m => new { m.CertificateId, m.ProductLineId });
            builder.Entity<CertificationInActionItem>().HasKey(m => new { m.ActionItemId, m.CertificationLineId });
            builder.Entity<CertificationInLocation>().HasKey(m => new { m.CertificationLineId, m.LocationId });
            builder.Entity<Audit>(entity => entity.ToTable("Audits"));
            builder.Entity<CertificationLine>(entity => entity.ToTable("CertificationLines"));
            builder.Entity<Entity>(entity => entity.ToTable("Entities"));
            builder.Entity<ContactPerson>(entity => entity.ToTable("ContactPeople"));
            builder.Entity<CertificationInLocation>(entity => entity.ToTable("CertificationInLocations"));
            builder.Entity<Certificate>(entity => entity.ToTable("Certificates"));
            #endregion

            #region Commissions DB Configuration
            builder.Entity<CommissionForProject>().HasKey(m => new { m.CommissionId, m.ProjectId });
            #endregion

            #region Declarations DB Configuration
            builder.Entity<DeclarationSignature>().HasKey(m => m.SignatureId);
            builder.Entity<DeclarationItem>(entity => entity.ToTable("DeclarationItems"));
            builder.Entity<DeclarationRevision>(entity => entity.ToTable("DeclarationRevisions"));
            builder.Entity<DeclarationSignature>(entity => entity.ToTable("DeclarationSignatures"));
            #endregion

            #region HumanResources DB Configuration
            builder.Entity<ActivityInGroup>().HasKey(m => new { m.ActivityGroupId, m.ActivityId });
            builder.Entity<ActivityInFunctionalRoles>().HasKey(m => new { m.FunctionalRoleId, m.ActivityId });
            builder.Entity<ActivityInOrganizationalRole>().HasKey(m => new { m.OrganizationalRoleId, m.ActivityId });
            builder.Entity<SkillInActivity>().HasKey(m => new { m.SkillId, m.ActivityId });
            builder.Entity<Activity>(entity => entity.ToTable("Activities"));
            builder.Entity<ActivityGroup>(entity => entity.ToTable("ActivityGroups"));
            builder.Entity<ActivityInGroup>(entity => entity.ToTable("ActivityInGroups"));
            builder.Entity<Department>(entity => entity.ToTable("Departments"));
            builder.Entity<SkillGroup>(entity => entity.ToTable("SkillGroups"));
            builder.Entity<Skill>(entity => entity.ToTable("Skills"));
            builder.Entity<OrganizationalRole>(entity => entity.ToTable("OrganizationalRoles"));
            builder.Entity<FunctionalRole>(entity => entity.ToTable("FuntionalRoles"));
            builder.Entity<SkillInActivity>(entity => entity.ToTable("SkillInActivity"));
            builder.Entity<UserHoliday>(entity => entity.ToTable("UserHolidays"));
            #endregion

            #region Kanban DB Configuration
            builder.Entity<KanbanBoard>().HasKey(m => m.KanbanId);
            builder.Entity<TaskInKanban>().HasKey(m => new { m.KanbanBoardId, m.LocationInKanbanId, m.TaskItemId });
            builder.Entity<TaskInKanban>().HasOne(m => m.Sprint).WithMany().HasForeignKey(m => m.SprintId);
            builder.Entity<TaskType>(entity => entity.ToTable("TaskTypes"));
            builder.Entity<LocationInKanban>(entity => entity.ToTable("LocationInKanbans"));
            builder.Entity<TaskItem>(entity => entity.ToTable("TaskItems"));
            builder.Entity<TaskInKanban>(entity => entity.ToTable("TaskInKanbans"));
            builder.Entity<Sprint>(entity => entity.ToTable("Sprints"));
            builder.Entity<KanbanBoard>(entity => entity.ToTable("KanbanBoards"));
            #endregion

            #region Project DB Configuration
            builder.Entity<AlertInProject>().HasKey(m => new { m.AlertTypeId, m.ProjectItemId });
            builder.Entity<LocationsForAction>().HasKey(m => new { m.ActionLineId, m.LocationId});
            builder.Entity<ProjectMember>().HasKey(m => new { m.ProjectItemId, m.UserId, m.FunctionalRoleId });
            builder.Entity<TopicInProject>().HasKey(m => new { m.TopicId, m.ProjectItemId });
            builder.Entity<ActionGroup>(entity => entity.ToTable("ActionGroups"));
            builder.Entity<ProjectItem>(entity => entity.ToTable("ProjectItems"));
            #endregion

            #region General DB Configuration
            builder.Entity<Topic>(entity => entity.ToTable("Topics"));
            builder.Entity<Location>(entity => entity.ToTable("Locations"));
            builder.Entity<LineOfProduct>(entity => entity.ToTable("LinesOfProducts"));
            builder.Entity<AlertType>(entity => entity.ToTable("AlertTypes"));
            #endregion

            #region Users DB Configuration
            builder.Entity<UserSkillsEvaluation>(entity => entity.ToTable("UserSkillsEvaluations"));
            builder.Entity<UserSkillsEvaluation>().HasKey(m => new {m.UserId, m.SkillId});
            builder.Entity<UserInTeam>().HasKey(m => m.UserInTeamId);
            builder.Entity<UserInTeam>().HasOne(m => m.ApplicationUser)
                .WithOne();
            builder.Entity<UserInTeam>().Ignore(u => u.TasksNotCompleted);
            builder.Entity<UserInTeam>().Ignore(u => u.TaskItensInActiveSprints);
            #endregion

            #region Financial DB Configuration
            builder.Entity<FinancialLine>().Ignore(u => u.AdjudicatedValueInEuro);
            builder.Entity<Currency>(entity => entity.ToTable("Currencies"));
            builder.Entity<FinancialLineType>(entity => entity.ToTable("FinancialLineTypes"));
            builder.Entity<FinancialLineSubType>(entity => entity.ToTable("FinancialLineSubTypes"));
            #endregion

        }
    }
}
