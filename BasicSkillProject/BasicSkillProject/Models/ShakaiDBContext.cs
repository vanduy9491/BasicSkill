using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BasicSkillProject.Models
{
    public partial class ShakaiDBContext : DbContext
    {
        public ShakaiDBContext()
        {
        }

        public ShakaiDBContext(DbContextOptions<ShakaiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbilityFactor> AbilityFactors { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventRegit> EventRegits { get; set; }
        public virtual DbSet<SchoolYear> SchoolYears { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<UserOfSchoolYear> UserOfSchoolYears { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ShakaiDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AbilityFactor>(entity =>
            {
                entity.HasIndex(e => e.SkillId, "IX_AbilityFactors_Skill_id");

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SkillId).HasColumnName("Skill_id");

                entity.Property(e => e.Tags).HasMaxLength(50);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.AbilityFactors)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_AbilityFactors_SKills");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Avatar)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.StudentCode)
                    .HasMaxLength(250)
                    .HasColumnName("Student_Code");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.EnventRegitsId, "IX_Comments_EnventRegits_Id");

                entity.HasIndex(e => e.UserId, "IX_Comments_User_Id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EnventRegitsId).HasColumnName("EnventRegits_Id");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.EnventRegits)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.EnventRegitsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_EventRegits");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comments_Users");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Icons).HasMaxLength(50);
            });

            modelBuilder.Entity<EventRegit>(entity =>
            {
                entity.HasIndex(e => e.EventId, "IX_EventRegits_Event_Id");

                entity.HasIndex(e => e.UserId, "IX_EventRegits_User_Id");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.DevelopedCapacity)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EventId).HasColumnName("Event_Id");

                entity.Property(e => e.OwnAction)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PowerExerted)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SchoolActivitie)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SchoolYear).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.WhatWasThought)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventRegits)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRegits_Events");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventRegits)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_EventRegits_Userss");
            });

            modelBuilder.Entity<SchoolYear>(entity =>
            {
                entity.Property(e => e.SchoolYear1)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("SchoolYear");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("SKills");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("SKillName");
            });

            modelBuilder.Entity<UserOfSchoolYear>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SchoolYearId });

                entity.HasIndex(e => e.SchoolYearId, "IX_UserOfSchoolYears_SchoolYear_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.SchoolYearId).HasColumnName("SchoolYear_Id");

                entity.HasOne(d => d.SchoolYear)
                    .WithMany(p => p.UserOfSchoolYears)
                    .HasForeignKey(d => d.SchoolYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOfSchoolYears_SchoolYears");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOfSchoolYears)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOfSchoolYears_Userss");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SkillId })
                    .HasName("PK_User_Skills_1");

                entity.ToTable("User_Skills");

                entity.HasIndex(e => e.SkillId, "IX_User_Skills_Skill_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.SkillId).HasColumnName("Skill_Id");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Skill_SKills");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Skill_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
