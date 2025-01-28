using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroTender.Migrations
{
    /// <inheritdoc />
    public partial class RelationBetweenProjectApplicant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Applicants",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_ProjectId",
                table: "Applicants",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Projects_ProjectId",
                table: "Applicants",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Projects_ProjectId",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_ProjectId",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Applicants");
        }
    }
}
