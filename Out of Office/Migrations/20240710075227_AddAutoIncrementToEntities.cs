using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Out_of_Office.Migrations
{
    public partial class AddAutoIncrementToLeaveRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "LeaveRequestId",
            table: "LeaveRequests",
            nullable: false,
            oldClrType: typeof(int))
            .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
            name: "LeaveRequestId",
            table: "LeaveRequests",
            nullable: false,
            oldClrType: typeof(long))
            .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
