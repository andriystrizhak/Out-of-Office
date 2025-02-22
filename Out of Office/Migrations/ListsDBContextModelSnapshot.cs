﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutOfOffice.Models;

#nullable disable

namespace Out_of_Office.Migrations
{
    [DbContext(typeof(ListsDbContext))]
    partial class ListsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.31");

            modelBuilder.Entity("Out_of_Office.Models.EmployeeProject", b =>
                {
                    b.Property<long>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("OutOfOffice.Models.AbsenceReason", b =>
                {
                    b.Property<long>("AbsenceReasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("AbsenceReasonID");

                    b.Property<string>("AbsenceReasonName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AbsenceReasonId");

                    b.ToTable("AbsenceReasons");
                });

            modelBuilder.Entity("OutOfOffice.Models.ApprovalRequest", b =>
                {
                    b.Property<long>("ApprovalRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ApprovalRequestID");

                    b.Property<long>("ApproverId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ApproverID");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<long>("LeaveRequestId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("LeaveRequestID");

                    b.Property<long>("StatusId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("StatusID");

                    b.HasKey("ApprovalRequestId");

                    b.HasIndex("ApproverId");

                    b.HasIndex("LeaveRequestId");

                    b.HasIndex("StatusId");

                    b.ToTable("ApprovalRequests");
                });

            modelBuilder.Entity("OutOfOffice.Models.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("OutOfOfficeBalance")
                        .HasColumnType("REAL");

                    b.Property<long>("PeoplePartnerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("PeoplePartnerID");

                    b.Property<long?>("PhotoId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("PhotoID");

                    b.Property<long>("PositionId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("PositionID");

                    b.Property<long>("StatusId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("StatusID");

                    b.Property<long>("SubdivisionId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("SubdivisionID");

                    b.HasKey("EmployeeId");

                    b.HasIndex("PeoplePartnerId");

                    b.HasIndex("PhotoId");

                    b.HasIndex("PositionId");

                    b.HasIndex("StatusId");

                    b.HasIndex("SubdivisionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OutOfOffice.Models.LeaveRequest", b =>
                {
                    b.Property<long>("LeaveRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("LeaveRequestID");

                    b.Property<long>("AbsenceReasonId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("AbsenceReasonID");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("EmployeeID");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<long>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("LeaveRequestId");

                    b.HasIndex("AbsenceReasonId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("Status");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("OutOfOffice.Models.LeaveStatus", b =>
                {
                    b.Property<long>("LeaveStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("LeaveStatusID");

                    b.Property<string>("LeaveStatusName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LeaveStatusId");

                    b.ToTable("LeaveStatuses");
                });

            modelBuilder.Entity("OutOfOffice.Models.Photo", b =>
                {
                    b.Property<long>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("PhotoID");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PhotoId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("OutOfOffice.Models.Position", b =>
                {
                    b.Property<long>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("PositionID");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("OutOfOffice.Models.Project", b =>
                {
                    b.Property<long>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ProjectID");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<long>("ProjectManagerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ProjectManagerID");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("ProjectTypeId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ProjectTypeID");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<long>("StatusId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("StatusID");

                    b.HasKey("ProjectId");

                    b.HasIndex("ProjectManagerId");

                    b.HasIndex("ProjectTypeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("OutOfOffice.Models.ProjectType", b =>
                {
                    b.Property<long>("ProjectTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ProjectTypeID");

                    b.Property<string>("ProjectTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProjectTypeId");

                    b.ToTable("ProjectTypes");
                });

            modelBuilder.Entity("OutOfOffice.Models.Status", b =>
                {
                    b.Property<long>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("StatusID");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("OutOfOffice.Models.Subdivision", b =>
                {
                    b.Property<long>("SubdivisionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("SubdivisionID");

                    b.Property<string>("SubdivisionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SubdivisionId");

                    b.ToTable("Subdivisions");
                });

            modelBuilder.Entity("Out_of_Office.Models.EmployeeProject", b =>
                {
                    b.HasOne("OutOfOffice.Models.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("OutOfOffice.Models.ApprovalRequest", b =>
                {
                    b.HasOne("OutOfOffice.Models.Employee", "Approver")
                        .WithMany("ApprovalRequests")
                        .HasForeignKey("ApproverId")
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.LeaveRequest", "LeaveRequest")
                        .WithMany("ApprovalRequests")
                        .HasForeignKey("LeaveRequestId")
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.LeaveStatus", "Status")
                        .WithMany("ApprovalRequests")
                        .HasForeignKey("StatusId")
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("LeaveRequest");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("OutOfOffice.Models.Employee", b =>
                {
                    b.HasOne("OutOfOffice.Models.Employee", "PeoplePartner")
                        .WithMany("InversePeoplePartner")
                        .HasForeignKey("PeoplePartnerId")
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.Photo", "Photo")
                        .WithMany("Employees")
                        .HasForeignKey("PhotoId");

                    b.HasOne("OutOfOffice.Models.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.Status", "Status")
                        .WithMany("Employees")
                        .HasForeignKey("StatusId")
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.Subdivision", "Subdivision")
                        .WithMany("Employees")
                        .HasForeignKey("SubdivisionId")
                        .IsRequired();

                    b.Navigation("PeoplePartner");

                    b.Navigation("Photo");

                    b.Navigation("Position");

                    b.Navigation("Status");

                    b.Navigation("Subdivision");
                });

            modelBuilder.Entity("OutOfOffice.Models.LeaveRequest", b =>
                {
                    b.HasOne("OutOfOffice.Models.AbsenceReason", "AbsenceReason")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("AbsenceReasonId")
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.Employee", "Employee")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("EmployeeId")
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.LeaveStatus", "StatusNavigation")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("Status")
                        .IsRequired();

                    b.Navigation("AbsenceReason");

                    b.Navigation("Employee");

                    b.Navigation("StatusNavigation");
                });

            modelBuilder.Entity("OutOfOffice.Models.Project", b =>
                {
                    b.HasOne("OutOfOffice.Models.Employee", "ProjectManager")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectManagerId")
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.ProjectType", "ProjectType")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectTypeId")
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.Status", "Status")
                        .WithMany("Projects")
                        .HasForeignKey("StatusId")
                        .IsRequired();

                    b.Navigation("ProjectManager");

                    b.Navigation("ProjectType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("OutOfOffice.Models.AbsenceReason", b =>
                {
                    b.Navigation("LeaveRequests");
                });

            modelBuilder.Entity("OutOfOffice.Models.Employee", b =>
                {
                    b.Navigation("ApprovalRequests");

                    b.Navigation("EmployeeProjects");

                    b.Navigation("InversePeoplePartner");

                    b.Navigation("LeaveRequests");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("OutOfOffice.Models.LeaveRequest", b =>
                {
                    b.Navigation("ApprovalRequests");
                });

            modelBuilder.Entity("OutOfOffice.Models.LeaveStatus", b =>
                {
                    b.Navigation("ApprovalRequests");

                    b.Navigation("LeaveRequests");
                });

            modelBuilder.Entity("OutOfOffice.Models.Photo", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("OutOfOffice.Models.Position", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("OutOfOffice.Models.Project", b =>
                {
                    b.Navigation("EmployeeProjects");
                });

            modelBuilder.Entity("OutOfOffice.Models.ProjectType", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("OutOfOffice.Models.Status", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("OutOfOffice.Models.Subdivision", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
