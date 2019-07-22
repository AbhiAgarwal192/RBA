using Microsoft.EntityFrameworkCore;
using RBA.Data.Entities;
using System;

namespace RBA.Data
{
    public class RolesDbContext : DbContext
    {
        public RolesDbContext(DbContextOptions<RolesDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<ActionTypeRoleMapping> ActionTypeRoleMapping { get; set; }
        public virtual DbSet<ActionTypes> ActionTypes { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<ResourceRoleMapping> ResourceRoleMapping { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRolesMapping> UserRolesMapping { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ActionTypeRoleMapping>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__ActionTy__8AFACE1A4A9F188A");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.HasOne(d => d.ActionType)
                    .WithMany(p => p.ActionTypeRoleMapping)
                    .HasForeignKey(d => d.ActionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionTypeRoleMapping_ActionTypeTable");

                entity.HasOne(d => d.Role)
                    .WithOne(p => p.ActionTypeRoleMapping)
                    .HasForeignKey<ActionTypeRoleMapping>(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionTypeRoleMapping_RoleTable");
            });

            modelBuilder.Entity<ActionTypes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ResourceRoleMapping>(entity =>
            {
                entity.HasKey(e => e.ResourceId)
                    .HasName("PK__Resource__4ED1816F7B77AFCB");

                entity.Property(e => e.ResourceId).ValueGeneratedNever();

                entity.HasOne(d => d.Resource)
                    .WithOne(p => p.ResourceRoleMapping)
                    .HasForeignKey<ResourceRoleMapping>(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceRoleMapping_ResourceTable");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ResourceRoleMapping)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceRoleMapping_RoleTable");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserRolesMapping>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserRole__1788CC4CDC5F5B21");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRolesMapping)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRolesMapping_RolesTable");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserRolesMapping)
                    .HasForeignKey<UserRolesMapping>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRolesMapping_UserTable");
            });
        }

    }
}
