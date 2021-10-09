using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class LinkUserAndAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "PDCUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "PDCUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "PDCUsers",
                newName: "ApplicationUserId1");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "PDCUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsernameChangeLimit",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PDCUsers_ApplicationUserId1",
                table: "PDCUsers",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PDCUsers_AspNetUsers_ApplicationUserId1",
                table: "PDCUsers",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PDCUsers_AspNetUsers_ApplicationUserId1",
                table: "PDCUsers");

            migrationBuilder.DropIndex(
                name: "IX_PDCUsers_ApplicationUserId1",
                table: "PDCUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "PDCUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsernameChangeLimit",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId1",
                table: "PDCUsers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PDCUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "PDCUsers",
                type: "TEXT",
                nullable: true);
        }
    }
}
