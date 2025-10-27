using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAP.Administrator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContactTypeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactTypeExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypeExports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypeAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    StatusId = table.Column<bool>(type: "bit", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,8)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,8)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypeAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactTypeAudits_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypeLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactTypeId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypeLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactTypeLocalizations_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeAudits_ContactTypeId",
                table: "ContactTypeAudits",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeLocalizations_ContactTypeId",
                table: "ContactTypeLocalizations",
                column: "ContactTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactTypeAudits");

            migrationBuilder.DropTable(
                name: "ContactTypeExports");

            migrationBuilder.DropTable(
                name: "ContactTypeLocalizations");

            migrationBuilder.DropTable(
                name: "ContactTypes");
        }
    }
}
