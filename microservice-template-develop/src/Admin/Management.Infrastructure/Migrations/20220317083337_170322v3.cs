using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Management.Infrastructure.Migrations
{
    public partial class _170322v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationUser_Users_UserId",
                table: "OrganizationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationUser",
                table: "OrganizationUser");

            migrationBuilder.RenameTable(
                name: "OrganizationUser",
                newName: "OrganizationUsers");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationUser_UserId",
                table: "OrganizationUsers",
                newName: "IX_OrganizationUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationUsers",
                table: "OrganizationUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUsers_OrganizationId",
                table: "OrganizationUsers",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationUsers_Organizations_OrganizationId",
                table: "OrganizationUsers",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationUsers_Users_UserId",
                table: "OrganizationUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationUsers_Organizations_OrganizationId",
                table: "OrganizationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationUsers_Users_UserId",
                table: "OrganizationUsers");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationUsers",
                table: "OrganizationUsers");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationUsers_OrganizationId",
                table: "OrganizationUsers");

            migrationBuilder.RenameTable(
                name: "OrganizationUsers",
                newName: "OrganizationUser");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationUsers_UserId",
                table: "OrganizationUser",
                newName: "IX_OrganizationUser_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationUser",
                table: "OrganizationUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationUser_Users_UserId",
                table: "OrganizationUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
