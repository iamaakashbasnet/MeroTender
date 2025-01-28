using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroTender.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicantModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyRegNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyPhone = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyEmail = table.Column<string>(type: "TEXT", nullable: false),
                    BiddingRate = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}
