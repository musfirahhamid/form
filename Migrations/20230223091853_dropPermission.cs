﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace form.Migrations
{
    public partial class dropPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idPermission",
                table: "roleAssignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idPermission",
                table: "roleAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
