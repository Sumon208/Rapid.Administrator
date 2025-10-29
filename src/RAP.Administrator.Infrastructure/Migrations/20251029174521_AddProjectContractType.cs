using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAP.Administrator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectContractType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectContractTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContractTypeAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectContractTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanTypeText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    Draft = table.Column<bool>(type: "bit", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MapURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContractTypeAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectContractTypeAudits_ProjectContractTypes_ProjectContractTypeId",
                        column: x => x.ProjectContractTypeId,
                        principalTable: "ProjectContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContractTypeExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTypeId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SizeBytes = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContractTypeExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectContractTypeExports_ProjectContractTypes_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "ProjectContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContractTypeLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectContractTypeId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContractTypeLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectContractTypeLocalizations_ProjectContractTypes_ProjectContractTypeId",
                        column: x => x.ProjectContractTypeId,
                        principalTable: "ProjectContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContractTypeAudits_ProjectContractTypeId",
                table: "ProjectContractTypeAudits",
                column: "ProjectContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContractTypeExports_LoanTypeId",
                table: "ProjectContractTypeExports",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContractTypeLocalizations_ProjectContractTypeId",
                table: "ProjectContractTypeLocalizations",
                column: "ProjectContractTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectContractTypeAudits");

            migrationBuilder.DropTable(
                name: "ProjectContractTypeExports");

            migrationBuilder.DropTable(
                name: "ProjectContractTypeLocalizations");

            migrationBuilder.DropTable(
                name: "ProjectContractTypes");
        }
    }
}
