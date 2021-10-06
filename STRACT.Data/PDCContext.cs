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

namespace STRACT.Data
{
    public class PDCContext : AuditableIdentityContext
    {
        public PDCContext(DbContextOptions<PDCContext> options) : base(options)
        {

        }

        public DbSet<ActivityGroup> ActivityGroups { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityInGroup> ActivityInGroups { get; set; }
        public DbSet<UserInTeam> PDCUsers { get; set; }
        public DbSet<DeclarationItem> Declarations { get; set; }
        public DbSet<DeclarationSignature> DeclarationSignatures { get; set; }
        public DbSet<CertificateProductLine> CertificateProductLines { get; set; }
        public DbSet<CommissionForProject> CommissionForProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityGroup>().HasKey(m => m.ActivityGroupId);
            modelBuilder.Entity<Activity>().HasKey(m => m.ActivityId);
            modelBuilder.Entity<ActivityInGroup>().HasKey(m => m.ActivityId);
            modelBuilder.Entity<ActivityInGroup>().HasKey(m => m.ActivityGroupId);
            modelBuilder.Entity<UserInTeam>().HasKey(m => m.UserId);
            modelBuilder.Entity<DeclarationItem>().HasKey(m => m.DeclarationItemId);
            modelBuilder.Entity<DeclarationSignature>().HasKey(m => m.SignatureId);
            modelBuilder.Entity<CertificateProductLine>().HasKey(m => m.CertificateId);
            modelBuilder.Entity<CertificateProductLine>().HasKey(m => m.ProductLineId);
            modelBuilder.Entity<CommissionForProject>().HasKey(m => m.CommissionId);
            modelBuilder.Entity<CommissionForProject>().HasKey(m => m.ProjectId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
