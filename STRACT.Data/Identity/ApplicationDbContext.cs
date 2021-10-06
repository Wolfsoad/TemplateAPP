using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using STRACT.Identity.Entities;
using STRACT.Entities.Declaration;
using STRACT.Entities.HumanResources;
using STRACT.Entities.Users;
using STRACT.Entities.Certifications;
using STRACT.Entities.CommissionProposals;

namespace STRACT.Data.Identity
{
    public class ApplicationDbContext : AuditableIdentityContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ActivityGroup> ActivityGroups { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityInGroup> ActivityInGroups { get; set; }
        public DbSet<User> PDCUsers { get; set; }
        public DbSet<DeclarationItem> Declarations { get; set; }
        public DbSet<DeclarationSignature> DeclarationSignatures { get; set; }
        public DbSet<CertificateProductLine> CertificateProductLines { get; set; }
        public DbSet<CommissionForProject> CommissionForProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ActivityGroup>().HasKey(m => m.ActivityGroupId);
            builder.Entity<Activity>().HasKey(m => m.ActivityId);
            builder.Entity<ActivityInGroup>().HasKey(m => m.ActivityId);
            builder.Entity<ActivityInGroup>().HasKey(m => m.ActivityGroupId);
            builder.Entity<User>().HasKey(m => m.UserId);
            builder.Entity<DeclarationItem>().HasKey(m => m.DeclarationId);
            builder.Entity<DeclarationSignature>().HasKey(m => m.SignatureId);
            builder.Entity<CertificateProductLine>().HasKey(m => m.CertificateId);
            builder.Entity<CertificateProductLine>().HasKey(m => m.ProductLineId);
            builder.Entity<CommissionForProject>().HasKey(m => m.CommissionId);
            builder.Entity<CommissionForProject>().HasKey(m => m.ProjectId);
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
