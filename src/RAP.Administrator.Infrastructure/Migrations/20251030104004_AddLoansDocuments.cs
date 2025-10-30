using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAP.Administrator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLoansDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoansAuthority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoansAuthority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanId = table.Column<int>(type: "int", nullable: true),
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
                    Latitude = table.Column<decimal>(type: "decimal(10,7)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(10,7)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanExports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanLocalizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepaymentFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IqmaId = table.Column<int>(type: "int", nullable: true),
                    IqmaId1 = table.Column<int>(type: "int", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermittedById = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InterestPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InstallmentPeriod = table.Column<int>(type: "int", nullable: true),
                    RepaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Installment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LoanDetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LoanStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: true),
                    LoanAuditId = table.Column<int>(type: "int", nullable: true),
                    LoanExportId = table.Column<int>(type: "int", nullable: true),
                    LoanLocalizationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_IqmaList_IqmaId1",
                        column: x => x.IqmaId1,
                        principalTable: "IqmaList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loans_LoanAudits_LoanAuditId",
                        column: x => x.LoanAuditId,
                        principalTable: "LoanAudits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loans_LoanExports_LoanExportId",
                        column: x => x.LoanExportId,
                        principalTable: "LoanExports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loans_LoanLocalizations_LoanLocalizationId",
                        column: x => x.LoanLocalizationId,
                        principalTable: "LoanLocalizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loans_LoansAuthority_PermittedById",
                        column: x => x.PermittedById,
                        principalTable: "LoansAuthority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loans_TransferIqamas_IqmaId",
                        column: x => x.IqmaId,
                        principalTable: "TransferIqamas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanAudits_LoanId",
                table: "LoanAudits",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanExports_LoanId",
                table: "LoanExports",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanLocalizations_LoanId",
                table: "LoanLocalizations",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_IqmaId",
                table: "Loans",
                column: "IqmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_IqmaId1",
                table: "Loans",
                column: "IqmaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_LoanAuditId",
                table: "Loans",
                column: "LoanAuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_LoanExportId",
                table: "Loans",
                column: "LoanExportId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_LoanLocalizationId",
                table: "Loans",
                column: "LoanLocalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_PermittedById",
                table: "Loans",
                column: "PermittedById");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanAudits_Loans_LoanId",
                table: "LoanAudits",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanExports_Loans_LoanId",
                table: "LoanExports",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanLocalizations_Loans_LoanId",
                table: "LoanLocalizations",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanAudits_Loans_LoanId",
                table: "LoanAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanExports_Loans_LoanId",
                table: "LoanExports");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanLocalizations_Loans_LoanId",
                table: "LoanLocalizations");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "LoanAudits");

            migrationBuilder.DropTable(
                name: "LoanExports");

            migrationBuilder.DropTable(
                name: "LoanLocalizations");

            migrationBuilder.DropTable(
                name: "LoansAuthority");
        }
    }
}
