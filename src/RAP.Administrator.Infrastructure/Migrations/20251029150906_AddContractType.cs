using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAP.Administrator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContractType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContractExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeContractId = table.Column<int>(type: "int", nullable: true),
                    ExportedField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExportedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContractExports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryAllowance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAllowance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    ContactTypeId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    SalaryAllowanceId = table.Column<int>(type: "int", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactTypeId1 = table.Column<int>(type: "int", nullable: true),
                    ContractStatusId = table.Column<int>(type: "int", nullable: true),
                    EmployeeEntityId = table.Column<int>(type: "int", nullable: true),
                    SalaryAllowanceId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContracts_ContactType_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeContracts_ContactType_ContactTypeId1",
                        column: x => x.ContactTypeId1,
                        principalTable: "ContactType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeContracts_ContractStatus_ContractStatusId",
                        column: x => x.ContractStatusId,
                        principalTable: "ContractStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeContracts_ContractStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ContractStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeContracts_Employee_EmployeeEntityId",
                        column: x => x.EmployeeEntityId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeContracts_Employee_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeContracts_SalaryAllowance_SalaryAllowanceId",
                        column: x => x.SalaryAllowanceId,
                        principalTable: "SalaryAllowance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeContracts_SalaryAllowance_SalaryAllowanceId1",
                        column: x => x.SalaryAllowanceId1,
                        principalTable: "SalaryAllowance",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContractAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeContractId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeContractEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContractAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContractAudits_EmployeeContracts_EmployeeContractEntityId",
                        column: x => x.EmployeeContractEntityId,
                        principalTable: "EmployeeContracts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContractLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeContractId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeContractEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContractLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContractLocalizations_EmployeeContracts_EmployeeContractEntityId",
                        column: x => x.EmployeeContractEntityId,
                        principalTable: "EmployeeContracts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContractAudits_EmployeeContractEntityId",
                table: "EmployeeContractAudits",
                column: "EmployeeContractEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContractLocalizations_EmployeeContractEntityId",
                table: "EmployeeContractLocalizations",
                column: "EmployeeContractEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_ContactTypeId",
                table: "EmployeeContracts",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_ContactTypeId1",
                table: "EmployeeContracts",
                column: "ContactTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_ContractStatusId",
                table: "EmployeeContracts",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_EmployeeEntityId",
                table: "EmployeeContracts",
                column: "EmployeeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_SalaryAllowanceId",
                table: "EmployeeContracts",
                column: "SalaryAllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_SalaryAllowanceId1",
                table: "EmployeeContracts",
                column: "SalaryAllowanceId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_StaffId",
                table: "EmployeeContracts",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_StatusId",
                table: "EmployeeContracts",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeContractAudits");

            migrationBuilder.DropTable(
                name: "EmployeeContractExports");

            migrationBuilder.DropTable(
                name: "EmployeeContractLocalizations");

            migrationBuilder.DropTable(
                name: "EmployeeContracts");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropTable(
                name: "ContractStatus");

            migrationBuilder.DropTable(
                name: "SalaryAllowance");
        }
    }
}
