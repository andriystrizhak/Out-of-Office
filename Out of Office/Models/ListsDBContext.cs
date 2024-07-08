using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Out_of_Office.Models;

namespace OutOfOffice.Models
{
    public partial class ListsDbContext : DbContext
    {
        private readonly string _connectionString = "Data Source=Database\\ListsDB.db";

        public ListsDbContext()
        {
        }

        public ListsDbContext(string connectionStr) : this()
        {
            _connectionString = connectionStr;
        }

        public ListsDbContext(DbContextOptions<ListsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbsenceReason> AbsenceReasons { get; set; }
        public virtual DbSet<ApprovalRequest> ApprovalRequests { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }
        public virtual DbSet<LeaveStatus> LeaveStatuses { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectType> ProjectTypes { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Subdivision> Subdivisions { get; set; }
        public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbsenceReason>(entity =>
            {
                entity.Property(e => e.AbsenceReasonId)
                    .ValueGeneratedNever()
                    .HasColumnName("AbsenceReasonID");
            });

            modelBuilder.Entity<ApprovalRequest>(entity =>
            {
                entity.Property(e => e.ApprovalRequestId)
                    .ValueGeneratedNever()
                    .HasColumnName("ApprovalRequestID");

                entity.Property(e => e.ApproverId).HasColumnName("ApproverID");

                entity.Property(e => e.LeaveRequestId).HasColumnName("LeaveRequestID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Approver)
                    .WithMany(p => p.ApprovalRequests)
                    .HasForeignKey(d => d.ApproverId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.LeaveRequest)
                    .WithMany(p => p.ApprovalRequests)
                    .HasForeignKey(d => d.LeaveRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ApprovalRequests)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.PeoplePartnerId).HasColumnName("PeoplePartnerID");

                entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.SubdivisionId).HasColumnName("SubdivisionID");

                entity.HasOne(d => d.PeoplePartner)
                    .WithMany(p => p.InversePeoplePartner)
                    .HasForeignKey(d => d.PeoplePartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PhotoId);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Subdivision)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SubdivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(e => e.EmployeeProjects)
                    .WithOne(ep => ep.Employee)
                    .HasForeignKey(ep => ep.EmployeeId);
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

                entity.HasOne(ep => ep.Employee)
                    .WithMany(e => e.EmployeeProjects)
                    .HasForeignKey(ep => ep.EmployeeId);

                entity.HasOne(ep => ep.Project)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(ep => ep.ProjectId);
            });

            modelBuilder.Entity<LeaveRequest>(entity =>
            {
                entity.Property(e => e.LeaveRequestId)
                    .ValueGeneratedNever()
                    .HasColumnName("LeaveRequestID");

                entity.Property(e => e.AbsenceReasonId).HasColumnName("AbsenceReasonID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.AbsenceReason)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.AbsenceReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LeaveStatus>(entity =>
            {
                entity.Property(e => e.LeaveStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("LeaveStatusID");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.PhotoId)
                    .ValueGeneratedNever()
                    .HasColumnName("PhotoID");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId)
                    .ValueGeneratedNever()
                    .HasColumnName("PositionID");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProjectID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectManagerId).HasColumnName("ProjectManagerID");

                entity.Property(e => e.ProjectTypeId).HasColumnName("ProjectTypeID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.ProjectManager)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ProjectType)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(p => p.EmployeeProjects)
                    .WithOne(ep => ep.Project)
                    .HasForeignKey(ep => ep.ProjectId);
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.Property(e => e.ProjectTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProjectTypeID");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("StatusID");
            });

            modelBuilder.Entity<Subdivision>(entity =>
            {
                entity.Property(e => e.SubdivisionId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubdivisionID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
