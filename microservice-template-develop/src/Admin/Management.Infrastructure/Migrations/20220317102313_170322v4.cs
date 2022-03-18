using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Management.Infrastructure.Migrations
{
    public partial class _170322v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OrganizationUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OrganizationUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrganizationUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "OrganizationUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "OrganizationUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "OrganizationUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OrganizationUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrganizationUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "OrganizationUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "OrganizationUsers",
                type: "datetime2",
                nullable: true);
        }
    }
}
