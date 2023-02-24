using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace form.Migrations
{
    public partial class roleassignmentsstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "roleAssignments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "roleAssignments");
        }
    }
}
