using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Out_of_Office.Migrations
{
    public partial class AddEmployeeProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbsenceReasons",
                columns: table => new
                {
                    AbsenceReasonID = table.Column<long>(type: "INTEGER", nullable: false),
                    AbsenceReasonName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceReasons", x => x.AbsenceReasonID);
                });

            migrationBuilder.CreateTable(
                name: "LeaveStatuses",
                columns: table => new
                {
                    LeaveStatusID = table.Column<long>(type: "INTEGER", nullable: false),
                    LeaveStatusName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveStatuses", x => x.LeaveStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoID = table.Column<long>(type: "INTEGER", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<long>(type: "INTEGER", nullable: false),
                    PositionName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    ProjectTypeID = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.ProjectTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusID = table.Column<long>(type: "INTEGER", nullable: false),
                    StatusName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Subdivisions",
                columns: table => new
                {
                    SubdivisionID = table.Column<long>(type: "INTEGER", nullable: false),
                    SubdivisionName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivisions", x => x.SubdivisionID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<long>(type: "INTEGER", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    SubdivisionID = table.Column<long>(type: "INTEGER", nullable: false),
                    PositionID = table.Column<long>(type: "INTEGER", nullable: false),
                    StatusID = table.Column<long>(type: "INTEGER", nullable: false),
                    PeoplePartnerID = table.Column<long>(type: "INTEGER", nullable: false),
                    OutOfOfficeBalance = table.Column<double>(type: "REAL", nullable: false),
                    PhotoID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_PeoplePartnerID",
                        column: x => x.PeoplePartnerID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_Employees_Photos_PhotoID",
                        column: x => x.PhotoID,
                        principalTable: "Photos",
                        principalColumn: "PhotoID");
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID");
                    table.ForeignKey(
                        name: "FK_Employees_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID");
                    table.ForeignKey(
                        name: "FK_Employees_Subdivisions_SubdivisionID",
                        column: x => x.SubdivisionID,
                        principalTable: "Subdivisions",
                        principalColumn: "SubdivisionID");
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    LeaveRequestID = table.Column<long>(type: "INTEGER", nullable: false),
                    EmployeeID = table.Column<long>(type: "INTEGER", nullable: false),
                    AbsenceReasonID = table.Column<long>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<byte[]>(type: "datetime", nullable: false),
                    EndDate = table.Column<byte[]>(type: "datetime", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.LeaveRequestID);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_AbsenceReasons_AbsenceReasonID",
                        column: x => x.AbsenceReasonID,
                        principalTable: "AbsenceReasons",
                        principalColumn: "AbsenceReasonID");
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveStatuses_Status",
                        column: x => x.Status,
                        principalTable: "LeaveStatuses",
                        principalColumn: "LeaveStatusID");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectTypeID = table.Column<long>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<byte[]>(type: "datetime", nullable: false),
                    EndDate = table.Column<byte[]>(type: "datetime", nullable: true),
                    ProjectManagerID = table.Column<long>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    StatusID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_Projects_ProjectTypes_ProjectTypeID",
                        column: x => x.ProjectTypeID,
                        principalTable: "ProjectTypes",
                        principalColumn: "ProjectTypeID");
                    table.ForeignKey(
                        name: "FK_Projects_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID");
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRequests",
                columns: table => new
                {
                    ApprovalRequestID = table.Column<long>(type: "INTEGER", nullable: false),
                    ApproverID = table.Column<long>(type: "INTEGER", nullable: false),
                    LeaveRequestID = table.Column<long>(type: "INTEGER", nullable: false),
                    StatusID = table.Column<long>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequests", x => x.ApprovalRequestID);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_Employees_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_LeaveRequests_LeaveRequestID",
                        column: x => x.LeaveRequestID,
                        principalTable: "LeaveRequests",
                        principalColumn: "LeaveRequestID");
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_LeaveStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "LeaveStatuses",
                        principalColumn: "LeaveStatusID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_ApproverID",
                table: "ApprovalRequests",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_LeaveRequestID",
                table: "ApprovalRequests",
                column: "LeaveRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_StatusID",
                table: "ApprovalRequests",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_ProjectId",
                table: "EmployeeProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PeoplePartnerID",
                table: "Employees",
                column: "PeoplePartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PhotoID",
                table: "Employees",
                column: "PhotoID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionID",
                table: "Employees",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StatusID",
                table: "Employees",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SubdivisionID",
                table: "Employees",
                column: "SubdivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_AbsenceReasonID",
                table: "LeaveRequests",
                column: "AbsenceReasonID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeID",
                table: "LeaveRequests",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_Status",
                table: "LeaveRequests",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerID",
                table: "Projects",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeID",
                table: "Projects",
                column: "ProjectTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusID",
                table: "Projects",
                column: "StatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalRequests");

            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AbsenceReasons");

            migrationBuilder.DropTable(
                name: "LeaveStatuses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Subdivisions");
        }
    }
}
