using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspMvcConferenceEkzamen.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Conferenceid",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Conferenceid",
                table: "Users",
                column: "Conferenceid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Conferences_Conferenceid",
                table: "Users",
                column: "Conferenceid",
                principalTable: "Conferences",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Conferences_Conferenceid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Conferenceid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Conferenceid",
                table: "Users");
        }
    }
}
