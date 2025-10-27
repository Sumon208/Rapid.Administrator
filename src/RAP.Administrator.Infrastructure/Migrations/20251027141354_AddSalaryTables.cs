using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAP.Administrator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSalaryTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IqmaList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IqmaNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IqmaList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryAdvances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IqmaId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentModeId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BranchListEntityId = table.Column<int>(type: "int", nullable: true),
                    IqmaListEntityId = table.Column<int>(type: "int", nullable: true),
                    PaymentModeListEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAdvances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryAdvances_BranchList_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BranchList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalaryAdvances_BranchList_BranchListEntityId",
                        column: x => x.BranchListEntityId,
                        principalTable: "BranchList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalaryAdvances_IqmaList_IqmaId",
                        column: x => x.IqmaId,
                        principalTable: "IqmaList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalaryAdvances_IqmaList_IqmaListEntityId",
                        column: x => x.IqmaListEntityId,
                        principalTable: "IqmaList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalaryAdvances_PaymentModeList_PaymentModeId",
                        column: x => x.PaymentModeId,
                        principalTable: "PaymentModeList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalaryAdvances_PaymentModeList_PaymentModeListEntityId",
                        column: x => x.PaymentModeListEntityId,
                        principalTable: "PaymentModeList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalaryAdvanceAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryAdvanceId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    StatusId = table.Column<bool>(type: "bit", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAdvanceAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryAdvanceAudits_SalaryAdvances_SalaryAdvanceId",
                        column: x => x.SalaryAdvanceId,
                        principalTable: "SalaryAdvances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryAdvanceExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryAdvanceId = table.Column<int>(type: "int", nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExportedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAdvanceExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryAdvanceExports_SalaryAdvances_SalaryAdvanceId",
                        column: x => x.SalaryAdvanceId,
                        principalTable: "SalaryAdvances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryAdvanceLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryAdvanceId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAdvanceLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryAdvanceLocalizations_SalaryAdvances_SalaryAdvanceId",
                        column: x => x.SalaryAdvanceId,
                        principalTable: "SalaryAdvances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvanceAudits_SalaryAdvanceId",
                table: "SalaryAdvanceAudits",
                column: "SalaryAdvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvanceExports_SalaryAdvanceId",
                table: "SalaryAdvanceExports",
                column: "SalaryAdvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvanceLocalizations_SalaryAdvanceId",
                table: "SalaryAdvanceLocalizations",
                column: "SalaryAdvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvances_BranchId",
                table: "SalaryAdvances",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvances_BranchListEntityId",
                table: "SalaryAdvances",
                column: "BranchListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvances_IqmaId",
                table: "SalaryAdvances",
                column: "IqmaId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvances_IqmaListEntityId",
                table: "SalaryAdvances",
                column: "IqmaListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvances_PaymentModeId",
                table: "SalaryAdvances",
                column: "PaymentModeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvances_PaymentModeListEntityId",
                table: "SalaryAdvances",
                column: "PaymentModeListEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryAdvanceAudits");

            migrationBuilder.DropTable(
                name: "SalaryAdvanceExports");

            migrationBuilder.DropTable(
                name: "SalaryAdvanceLocalizations");

            migrationBuilder.DropTable(
                name: "SalaryAdvances");

            migrationBuilder.DropTable(
                name: "BranchList");

            migrationBuilder.DropTable(
                name: "IqmaList");

            migrationBuilder.DropTable(
                name: "PaymentModeList");
        }
    }
}
