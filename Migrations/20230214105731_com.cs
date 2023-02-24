using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace form.Migrations
{
    public partial class com : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "complains",
                columns: table => new
                {
                    ComplainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complains", x => x.ComplainId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "complains");

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
    }
}
