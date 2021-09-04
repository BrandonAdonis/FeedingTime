using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedingTime.Data.Migrations
{
    public partial class StaffMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffMembersID",
                table: "StaffMembers",
                newName: "StaffMemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffMemberID",
                table: "StaffMembers",
                newName: "StaffMembersID");
        }
    }
}
