using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using task.manager.data.DataContext;

#nullable disable

namespace Task.manager.Data.Models
{
    public partial class DatabaseContext : DbContext
    {
        public AppConfiguration settings { set; get; }
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=TaskManager;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Duration).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.ManagerId).HasColumnName("Manager_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remaining).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.WorkerId).HasColumnName("Worker_Id");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Project_Manager");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Project_Worker");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Estimation).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.ManagerId).HasColumnName("Manager_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("Project_Id");

                entity.Property(e => e.Remaining).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_Manager");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_Member");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_Project");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_Status");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("Worker");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
