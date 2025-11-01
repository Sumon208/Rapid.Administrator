using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAP.Administrator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleReceivings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveredLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveredLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceiverLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiverLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleReceivings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    DeliveredById = table.Column<int>(type: "int", nullable: true),
                    ReceivedById = table.Column<int>(type: "int", nullable: true),
                    ReceivingNo = table.Column<int>(type: "int", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerReference = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TypeOfSample = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RequiredTests = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NumberOfSample = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    OtherNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BranchListEntityId = table.Column<int>(type: "int", nullable: true),
                    CustomerListEntityId = table.Column<int>(type: "int", nullable: true),
                    DeliveredListEntityId = table.Column<int>(type: "int", nullable: true),
                    ReceiverListEntityId = table.Column<int>(type: "int", nullable: true),
                    SectionListEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleReceivings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleReceivings_BranchList_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BranchList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SampleReceivings_BranchList_BranchListEntityId",
                        column: x => x.BranchListEntityId,
                        principalTable: "BranchList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SampleReceivings_CustomerLists_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SampleReceivings_CustomerLists_CustomerListEntityId",
                        column: x => x.CustomerListEntityId,
                        principalTable: "CustomerLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SampleReceivings_DeliveredLists_DeliveredById",
                        column: x => x.DeliveredById,
                        principalTable: "DeliveredLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SampleReceivings_DeliveredLists_DeliveredListEntityId",
                        column: x => x.DeliveredListEntityId,
                        principalTable: "DeliveredLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SampleReceivings_ReceiverLists_ReceivedById",
                        column: x => x.ReceivedById,
                        principalTable: "ReceiverLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SampleReceivings_ReceiverLists_ReceiverListEntityId",
                        column: x => x.ReceiverListEntityId,
                        principalTable: "ReceiverLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SampleReceivings_SectionLists_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SectionLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SampleReceivings_SectionLists_SectionListEntityId",
                        column: x => x.SectionListEntityId,
                        principalTable: "SectionLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SampleReceivedAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_SampleReceivedAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleReceivedAudits_SampleReceivings_ReceivedId",
                        column: x => x.ReceivedId,
                        principalTable: "SampleReceivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleReceivedExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleReceivedExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleReceivedExports_SampleReceivings_ReceivedId",
                        column: x => x.ReceivedId,
                        principalTable: "SampleReceivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleReceivedLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    ReceivedId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleReceivedLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleReceivedLocalizations_SampleReceivings_ReceivedId",
                        column: x => x.ReceivedId,
                        principalTable: "SampleReceivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivedAudits_ReceivedId",
                table: "SampleReceivedAudits",
                column: "ReceivedId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivedExports_ReceivedId",
                table: "SampleReceivedExports",
                column: "ReceivedId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivedLocalizations_ReceivedId",
                table: "SampleReceivedLocalizations",
                column: "ReceivedId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivings_BranchId",
                table: "SampleReceivings",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivings_BranchListEntityId",
                table: "SampleReceivings",
                column: "BranchListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivings_CustomerId",
                table: "SampleReceivings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivings_CustomerListEntityId",
                table: "SampleReceivings",
                column: "CustomerListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivings_DeliveredById",
                table: "SampleReceivings",
                column: "DeliveredById");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivings_DeliveredListEntityId",
                table: "SampleReceivings",
                column: "DeliveredListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivings_ReceivedById",
                table: "SampleReceivings",
                column: "ReceivedById");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivings_ReceiverListEntityId",
                table: "SampleReceivings",
                column: "ReceiverListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivings_SectionId",
                table: "SampleReceivings",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleReceivings_SectionListEntityId",
                table: "SampleReceivings",
                column: "SectionListEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleReceivedAudits");

            migrationBuilder.DropTable(
                name: "SampleReceivedExports");

            migrationBuilder.DropTable(
                name: "SampleReceivedLocalizations");

            migrationBuilder.DropTable(
                name: "SampleReceivings");

            migrationBuilder.DropTable(
                name: "CustomerLists");

            migrationBuilder.DropTable(
                name: "DeliveredLists");

            migrationBuilder.DropTable(
                name: "ReceiverLists");

            migrationBuilder.DropTable(
                name: "SectionLists");
        }
    }
}
