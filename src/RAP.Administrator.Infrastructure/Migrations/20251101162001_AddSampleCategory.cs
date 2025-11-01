using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAP.Administrator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SampleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    StatusTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleCategoryAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Dail = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    StatusId = table.Column<bool>(type: "bit", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    OS = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MapURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleCategoryAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleCategoryAudits_SampleCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SampleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleCategoryExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleCategoryExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleCategoryExports_SampleCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SampleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleCategoryLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleCategoryLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleCategoryLocalizations_SampleCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SampleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SampleCategoryAudits_CategoryId",
                table: "SampleCategoryAudits",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleCategoryExports_CategoryId",
                table: "SampleCategoryExports",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleCategoryLocalizations_CategoryId",
                table: "SampleCategoryLocalizations",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleCategoryAudits");

            migrationBuilder.DropTable(
                name: "SampleCategoryExports");

            migrationBuilder.DropTable(
                name: "SampleCategoryLocalizations");

            migrationBuilder.DropTable(
                name: "SampleCategories");
        }
    }
}
