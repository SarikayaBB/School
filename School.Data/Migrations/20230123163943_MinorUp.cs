using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Data.Migrations
{
    /// <inheritdoc />
    public partial class MinorUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppUserRoleId",
                table: "AppUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_AppUserRoleId",
                table: "AppUser",
                column: "AppUserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_AppUserRoles_AppUserRoleId",
                table: "AppUser",
                column: "AppUserRoleId",
                principalTable: "AppUserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_AppUserRoles_AppUserRoleId",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_AppUserRoleId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "AppUserRoleId",
                table: "AppUser");
        }
    }
}
