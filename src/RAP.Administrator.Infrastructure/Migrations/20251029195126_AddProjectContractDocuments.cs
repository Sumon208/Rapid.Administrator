using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAP.Administrator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectContractDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectContractContractTypeLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContractContractTypeLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractTypeId = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContractValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    Draft = table.Column<bool>(type: "bit", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectContracts_ProjectContractContractTypeLists_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ProjectContractContractTypeLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContractAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectContractId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ProjectContractAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectContractAudits_ProjectContracts_ProjectContractId",
                        column: x => x.ProjectContractId,
                        principalTable: "ProjectContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContractExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectContractId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContractExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectContractExports_ProjectContracts_ProjectContractId",
                        column: x => x.ProjectContractId,
                        principalTable: "ProjectContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContractLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectContractId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContractLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectContractLocalizations_ProjectContracts_ProjectContractId",
                        column: x => x.ProjectContractId,
                        principalTable: "ProjectContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContractAudits_ProjectContractId",
                table: "ProjectContractAudits",
                column: "ProjectContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContractExports_ProjectContractId",
                table: "ProjectContractExports",
                column: "ProjectContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContractLocalizations_ProjectContractId",
                table: "ProjectContractLocalizations",
                column: "ProjectContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContracts_ContractTypeId",
                table: "ProjectContracts",
                column: "ContractTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectContractAudits");

            migrationBuilder.DropTable(
                name: "ProjectContractExports");

            migrationBuilder.DropTable(
                name: "ProjectContractLocalizations");

            migrationBuilder.DropTable(
                name: "ProjectContracts");

            migrationBuilder.DropTable(
                name: "ProjectContractContractTypeLists");
        }
    }
}
