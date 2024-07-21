using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamForge.Model
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSet properties for your entities
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("AspNetUsers");
            });

            builder.Entity<IdentityRole<Guid>>(entity =>
            {
                entity.ToTable("AspNetRoles");
            });

            builder.Entity<IdentityUserRole<Guid>>(entity =>
            {
                entity.ToTable("AspNetUserRoles");
            });

            builder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable("AspNetUserClaims");
            });

            builder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.ToTable("AspNetUserLogins");
            });

            builder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable("AspNetRoleClaims");
            });

            builder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable("AspNetUserTokens");
            });

            // Additional configuration for your custom entities
            builder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                      .WithOne()
                      .HasForeignKey<Player>(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Coach>(entity =>
            {
                entity.ToTable("Coach");
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                      .WithOne()
                      .HasForeignKey<Coach>(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                      .WithOne()
                      .HasForeignKey<Admin>(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");
                entity.HasKey(e => e.Id);
            });

            builder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");
                entity.HasKey(e => e.Id);
            });

            builder.Entity<Score>(entity =>
            {
                entity.ToTable("Score");
                entity.HasKey(e => e.Id);
            });
        }
    }
}
