using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDAL.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Clients_ClientId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_ClientId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DateLesson",
                table: "Lessons");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Societies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Societies");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLesson",
                table: "Lessons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ClientId",
                table: "Lessons",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Clients_ClientId",
                table: "Lessons",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
