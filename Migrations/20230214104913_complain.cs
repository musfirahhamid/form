using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace form.Migrations
{
    public partial class complain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComplainDescription",
                table: "registration",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainTitle",
                table: "registration",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "registration",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComplainDescription",
                table: "registration");

            migrationBuilder.DropColumn(
                name: "ComplainTitle",
                table: "registration");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "registration");
        }
    }
}
