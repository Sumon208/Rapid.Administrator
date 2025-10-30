using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAP.Administrator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankLists", x => x.Id);
                });

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
                name: "CandidateActionTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateActionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateListExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExportedBy = table.Column<int>(type: "int", nullable: true),
                    ExportData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateListExports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidatePositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLists", x => x.Id);
                });

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
                name: "CountryListEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryListEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusTypeId = table.Column<short>(type: "smallint", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentCodeTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCodeTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Durations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Durations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
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
                name: "InvoiceFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InVoiceFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceFormats", x => x.Id);
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
                name: "JobLocationExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLocationExports", x => x.Id);
                });

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
                name: "LoanTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTypeText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    Draft = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderByLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderByLists", x => x.Id);
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
                name: "RetirementExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
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
                name: "ShiftTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BreakTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentTypeLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentTypeLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IBANNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DraftedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferFromLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferFromLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferIqamas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferIqamas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IqamaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    FromLocationId = table.Column<int>(type: "int", nullable: true),
                    ToLocationId = table.Column<int>(type: "int", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferToLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferToLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_CandidatePositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "CandidatePositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Candidates_CandidateTeams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "CandidateTeams",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "CandidateLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternatePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateLists_CountryListEntity_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryListEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobLocations_CountryListEntity_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryListEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DivisionAudits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    ActionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    StatusTypeId = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DivisionAudits_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivisionExports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DivisionExports_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivisionLocalizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    LocalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalizedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DivisionLocalizations_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    StatusId = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypes_DocumentCodeTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "DocumentCodeTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurance_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Retirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Retirement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    Draft = table.Column<bool>(type: "bit", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retirements_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SafetyMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DurationId = table.Column<int>(type: "int", nullable: true),
                    NextDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyMaterials_Durations_DurationId",
                        column: x => x.DurationId,
                        principalTable: "Durations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyMaterials_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MSDBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BranchArabic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VATNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PrintFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BankListEntityId = table.Column<int>(type: "int", nullable: true),
                    CompanyListEntityId = table.Column<int>(type: "int", nullable: true),
                    CountryListEntityId = table.Column<int>(type: "int", nullable: true),
                    CurrencyListEntityId = table.Column<int>(type: "int", nullable: true),
                    InvoiceFormatListEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSDBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MSDBranches_BankLists_BankId",
                        column: x => x.BankId,
                        principalTable: "BankLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MSDBranches_BankLists_BankListEntityId",
                        column: x => x.BankListEntityId,
                        principalTable: "BankLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MSDBranches_CompanyLists_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MSDBranches_CompanyLists_CompanyListEntityId",
                        column: x => x.CompanyListEntityId,
                        principalTable: "CompanyLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MSDBranches_CountryListEntity_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryListEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MSDBranches_CountryListEntity_CountryListEntityId",
                        column: x => x.CountryListEntityId,
                        principalTable: "CountryListEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MSDBranches_CurrencyLists_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "CurrencyLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MSDBranches_CurrencyLists_CurrencyListEntityId",
                        column: x => x.CurrencyListEntityId,
                        principalTable: "CurrencyLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MSDBranches_InvoiceFormats_InvoiceFormatListEntityId",
                        column: x => x.InvoiceFormatListEntityId,
                        principalTable: "InvoiceFormats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MSDBranches_InvoiceFormats_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanTypeAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTypeId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_LoanTypeAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanTypeAudits_LoanTypes_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanTypeExports",
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
                    table.PrimaryKey("PK_LoanTypeExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanTypeExports_LoanTypes_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanTypeLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTypeId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTypeLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanTypeLocalizations_LoanTypes_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ShiftTypeAudits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ActionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BreakTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTypeAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftTypeAudits_ShiftTypes_ShiftTypeId",
                        column: x => x.ShiftTypeId,
                        principalTable: "ShiftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftTypeExports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTypeExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftTypeExports_ShiftTypes_ShiftTypeId",
                        column: x => x.ShiftTypeId,
                        principalTable: "ShiftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftTypeLocalizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftTypeId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    LocalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalizedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTypeLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftTypeLocalizations_ShiftTypes_ShiftTypeId",
                        column: x => x.ShiftTypeId,
                        principalTable: "ShiftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PINo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: true),
                    OrderById = table.Column<int>(type: "int", nullable: true),
                    ShipmentTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_OrderByLists_OrderById",
                        column: x => x.OrderById,
                        principalTable: "OrderByLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_ShipmentTypeLists_ShipmentTypeId",
                        column: x => x.ShipmentTypeId,
                        principalTable: "ShipmentTypeLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaxAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Latitude = table.Column<decimal>(type: "decimal(18,8)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,8)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaxEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxAudits_Taxes_TaxEntityId",
                        column: x => x.TaxEntityId,
                        principalTable: "Taxes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransferAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferId = table.Column<int>(type: "int", nullable: true),
                    IqamaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    FromLocationId = table.Column<int>(type: "int", nullable: true),
                    ToLocationId = table.Column<int>(type: "int", nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OldValuesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValuesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferAudits_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferId = table.Column<int>(type: "int", nullable: true),
                    ExportedById = table.Column<int>(type: "int", nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferExports_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferLocalizations_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateAudits_ActionType_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateAudits_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExportedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateExports_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    LocalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalizedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateLocalizations_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateListAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateListAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateListAudits_CandidateLists_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "CandidateLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateListLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateListLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateListLocalizations_CandidateLists_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "CandidateLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobLocationAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobLocationId = table.Column<int>(type: "int", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLocationAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobLocationAudits_JobLocations_JobLocationId",
                        column: x => x.JobLocationId,
                        principalTable: "JobLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobLocationLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobLocationId = table.Column<int>(type: "int", nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLocationLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobLocationLocalizations_JobLocations_JobLocationId",
                        column: x => x.JobLocationId,
                        principalTable: "JobLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypeAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    StatusId = table.Column<bool>(type: "bit", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OS = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MapURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,8)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,8)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypeAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypeAudits_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypeExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExportedBy = table.Column<int>(type: "int", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypeExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypeExports_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypeLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypeLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypeLocalizations_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportInsurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceId = table.Column<int>(type: "int", nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExportedByUserId = table.Column<int>(type: "int", nullable: true),
                    ExportFormat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportInsurance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportInsurance_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceAudit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceId = table.Column<int>(type: "int", nullable: true),
                    InsuranceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceAudit_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceLocalization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceLocalization_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetirementAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetirementId = table.Column<int>(type: "int", nullable: true),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetirementAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetirementAudits_Retirements_RetirementId",
                        column: x => x.RetirementId,
                        principalTable: "Retirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetirementLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetirementId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetirementLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetirementLocalizations_Retirements_RetirementId",
                        column: x => x.RetirementId,
                        principalTable: "Retirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SafetyMaterialsAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SafetyMaterialsId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    StatusId = table.Column<bool>(type: "bit", nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    ActionUserId = table.Column<int>(type: "int", nullable: false),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyMaterialsAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyMaterialsAudits_SafetyMaterials_SafetyMaterialsId",
                        column: x => x.SafetyMaterialsId,
                        principalTable: "SafetyMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SafetyMaterialsExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SafetyMaterialsId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExportedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyMaterialsExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyMaterialsExports_SafetyMaterials_SafetyMaterialsId",
                        column: x => x.SafetyMaterialsId,
                        principalTable: "SafetyMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SafetyMaterialsLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    SafetyMaterialsId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyMaterialsLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyMaterialsLocalizations_SafetyMaterials_SafetyMaterialsId",
                        column: x => x.SafetyMaterialsId,
                        principalTable: "SafetyMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchesAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
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
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionUserId = table.Column<int>(type: "int", nullable: true),
                    ActionUserAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchesAudits_MSDBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "MSDBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchesExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FileSizeBytes = table.Column<long>(type: "bigint", nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchesExports_MSDBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "MSDBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchesLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AddressLocalized = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchesLocalizations_MSDBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "MSDBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "DocumentAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_DocumentAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentAudits_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExportedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentExports_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentLocalizations_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_BranchesAudits_BranchId",
                table: "BranchesAudits",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesExports_BranchId",
                table: "BranchesExports",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesLocalizations_BranchId",
                table: "BranchesLocalizations",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAudits_ActionTypeId",
                table: "CandidateAudits",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAudits_CandidateId",
                table: "CandidateAudits",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExports_CandidateId",
                table: "CandidateExports",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateListAudits_CandidateId",
                table: "CandidateListAudits",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateListLocalizations_CandidateId",
                table: "CandidateListLocalizations",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLists_CountryId",
                table: "CandidateLists",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLocalizations_CandidateId",
                table: "CandidateLocalizations",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_PositionId",
                table: "Candidates",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_TeamId",
                table: "Candidates",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeAudits_ContactTypeId",
                table: "ContactTypeAudits",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeLocalizations_ContactTypeId",
                table: "ContactTypeLocalizations",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DivisionAudits_DivisionId",
                table: "DivisionAudits",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DivisionExports_DivisionId",
                table: "DivisionExports",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DivisionLocalizations_DivisionId",
                table: "DivisionLocalizations",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAudits_DocumentId",
                table: "DocumentAudits",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentExports_DocumentId",
                table: "DocumentExports",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLocalizations_DocumentId",
                table: "DocumentLocalizations",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_OrderById",
                table: "Documents",
                column: "OrderById");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ShipmentTypeId",
                table: "Documents",
                column: "ShipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypeAudits_DocumentTypeId",
                table: "DocumentTypeAudits",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypeExports_DocumentTypeId",
                table: "DocumentTypeExports",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypeLocalizations_DocumentTypeId",
                table: "DocumentTypeLocalizations",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_TemplateId",
                table: "DocumentTypes",
                column: "TemplateId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ExportInsurance_InsuranceId",
                table: "ExportInsurance",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_EmployeeId",
                table: "Insurance",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAudit_InsuranceId",
                table: "InsuranceAudit",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceLocalization_InsuranceId",
                table: "InsuranceLocalization",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_JobLocationAudits_JobLocationId",
                table: "JobLocationAudits",
                column: "JobLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobLocationLocalizations_JobLocationId",
                table: "JobLocationLocalizations",
                column: "JobLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobLocations_CountryId",
                table: "JobLocations",
                column: "CountryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_LoanTypeAudits_LoanTypeId",
                table: "LoanTypeAudits",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTypeExports_LoanTypeId",
                table: "LoanTypeExports",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTypeLocalizations_LoanTypeId",
                table: "LoanTypeLocalizations",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MSDBranches_BankId",
                table: "MSDBranches",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_MSDBranches_BankListEntityId",
                table: "MSDBranches",
                column: "BankListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MSDBranches_CompanyId",
                table: "MSDBranches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MSDBranches_CompanyListEntityId",
                table: "MSDBranches",
                column: "CompanyListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MSDBranches_CountryId",
                table: "MSDBranches",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MSDBranches_CountryListEntityId",
                table: "MSDBranches",
                column: "CountryListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MSDBranches_CurrencyId",
                table: "MSDBranches",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MSDBranches_CurrencyListEntityId",
                table: "MSDBranches",
                column: "CurrencyListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MSDBranches_InvoiceFormatListEntityId",
                table: "MSDBranches",
                column: "InvoiceFormatListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MSDBranches_InvoiceId",
                table: "MSDBranches",
                column: "InvoiceId");

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

            migrationBuilder.CreateIndex(
                name: "IX_RetirementAudits_RetirementId",
                table: "RetirementAudits",
                column: "RetirementId");

            migrationBuilder.CreateIndex(
                name: "IX_RetirementLocalizations_RetirementId",
                table: "RetirementLocalizations",
                column: "RetirementId");

            migrationBuilder.CreateIndex(
                name: "IX_Retirements_EmployeeId",
                table: "Retirements",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyMaterials_DurationId",
                table: "SafetyMaterials",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyMaterials_EmployeeId",
                table: "SafetyMaterials",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyMaterialsAudits_SafetyMaterialsId",
                table: "SafetyMaterialsAudits",
                column: "SafetyMaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyMaterialsExports_SafetyMaterialsId",
                table: "SafetyMaterialsExports",
                column: "SafetyMaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyMaterialsLocalizations_SafetyMaterialsId",
                table: "SafetyMaterialsLocalizations",
                column: "SafetyMaterialsId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTypeAudits_ShiftTypeId",
                table: "ShiftTypeAudits",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTypeExports_ShiftTypeId",
                table: "ShiftTypeExports",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTypeLocalizations_ShiftTypeId",
                table: "ShiftTypeLocalizations",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxAudits_TaxEntityId",
                table: "TaxAudits",
                column: "TaxEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferAudits_TransferId",
                table: "TransferAudits",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferExports_TransferId",
                table: "TransferExports",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferLocalizations_TransferId",
                table: "TransferLocalizations",
                column: "TransferId");

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
                name: "BranchesAudits");

            migrationBuilder.DropTable(
                name: "BranchesExports");

            migrationBuilder.DropTable(
                name: "BranchesLocalizations");

            migrationBuilder.DropTable(
                name: "CandidateActionTypes");

            migrationBuilder.DropTable(
                name: "CandidateAudits");

            migrationBuilder.DropTable(
                name: "CandidateExports");

            migrationBuilder.DropTable(
                name: "CandidateListAudits");

            migrationBuilder.DropTable(
                name: "CandidateListExports");

            migrationBuilder.DropTable(
                name: "CandidateListLocalizations");

            migrationBuilder.DropTable(
                name: "CandidateLocalizations");

            migrationBuilder.DropTable(
                name: "ContactTypeAudits");

            migrationBuilder.DropTable(
                name: "ContactTypeExports");

            migrationBuilder.DropTable(
                name: "ContactTypeLocalizations");

            migrationBuilder.DropTable(
                name: "DivisionAudits");

            migrationBuilder.DropTable(
                name: "DivisionExports");

            migrationBuilder.DropTable(
                name: "DivisionLocalizations");

            migrationBuilder.DropTable(
                name: "DocumentAudits");

            migrationBuilder.DropTable(
                name: "DocumentExports");

            migrationBuilder.DropTable(
                name: "DocumentLocalizations");

            migrationBuilder.DropTable(
                name: "DocumentTypeAudits");

            migrationBuilder.DropTable(
                name: "DocumentTypeExports");

            migrationBuilder.DropTable(
                name: "DocumentTypeLocalizations");

            migrationBuilder.DropTable(
                name: "EmployeeContractAudits");

            migrationBuilder.DropTable(
                name: "EmployeeContractExports");

            migrationBuilder.DropTable(
                name: "EmployeeContractLocalizations");

            migrationBuilder.DropTable(
                name: "ExportInsurance");

            migrationBuilder.DropTable(
                name: "InsuranceAudit");

            migrationBuilder.DropTable(
                name: "InsuranceLocalization");

            migrationBuilder.DropTable(
                name: "JobLocationAudits");

            migrationBuilder.DropTable(
                name: "JobLocationExports");

            migrationBuilder.DropTable(
                name: "JobLocationLocalizations");

            migrationBuilder.DropTable(
                name: "LoanTypeAudits");

            migrationBuilder.DropTable(
                name: "LoanTypeExports");

            migrationBuilder.DropTable(
                name: "LoanTypeLocalizations");

            migrationBuilder.DropTable(
                name: "ProjectContractAudits");

            migrationBuilder.DropTable(
                name: "ProjectContractExports");

            migrationBuilder.DropTable(
                name: "ProjectContractLocalizations");

            migrationBuilder.DropTable(
                name: "ProjectContractTypeAudits");

            migrationBuilder.DropTable(
                name: "ProjectContractTypeExports");

            migrationBuilder.DropTable(
                name: "ProjectContractTypeLocalizations");

            migrationBuilder.DropTable(
                name: "RetirementAudits");

            migrationBuilder.DropTable(
                name: "RetirementExports");

            migrationBuilder.DropTable(
                name: "RetirementLocalizations");

            migrationBuilder.DropTable(
                name: "SafetyMaterialsAudits");

            migrationBuilder.DropTable(
                name: "SafetyMaterialsExports");

            migrationBuilder.DropTable(
                name: "SafetyMaterialsLocalizations");

            migrationBuilder.DropTable(
                name: "SalaryAdvanceAudits");

            migrationBuilder.DropTable(
                name: "SalaryAdvanceExports");

            migrationBuilder.DropTable(
                name: "SalaryAdvanceLocalizations");

            migrationBuilder.DropTable(
                name: "ShiftTypeAudits");

            migrationBuilder.DropTable(
                name: "ShiftTypeExports");

            migrationBuilder.DropTable(
                name: "ShiftTypeLocalizations");

            migrationBuilder.DropTable(
                name: "TaxAudits");

            migrationBuilder.DropTable(
                name: "TransferAudits");

            migrationBuilder.DropTable(
                name: "TransferBranches");

            migrationBuilder.DropTable(
                name: "TransferExports");

            migrationBuilder.DropTable(
                name: "TransferFromLocations");

            migrationBuilder.DropTable(
                name: "TransferLocalizations");

            migrationBuilder.DropTable(
                name: "TransferToLocations");

            migrationBuilder.DropTable(
                name: "MSDBranches");

            migrationBuilder.DropTable(
                name: "ActionType");

            migrationBuilder.DropTable(
                name: "CandidateLists");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "ContactTypes");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "EmployeeContracts");

            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.DropTable(
                name: "JobLocations");

            migrationBuilder.DropTable(
                name: "LoanTypes");

            migrationBuilder.DropTable(
                name: "ProjectContracts");

            migrationBuilder.DropTable(
                name: "ProjectContractTypes");

            migrationBuilder.DropTable(
                name: "Retirements");

            migrationBuilder.DropTable(
                name: "SafetyMaterials");

            migrationBuilder.DropTable(
                name: "SalaryAdvances");

            migrationBuilder.DropTable(
                name: "ShiftTypes");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "BankLists");

            migrationBuilder.DropTable(
                name: "CompanyLists");

            migrationBuilder.DropTable(
                name: "CurrencyLists");

            migrationBuilder.DropTable(
                name: "InvoiceFormats");

            migrationBuilder.DropTable(
                name: "CandidatePositions");

            migrationBuilder.DropTable(
                name: "CandidateTeams");

            migrationBuilder.DropTable(
                name: "OrderByLists");

            migrationBuilder.DropTable(
                name: "ShipmentTypeLists");

            migrationBuilder.DropTable(
                name: "DocumentCodeTemplates");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropTable(
                name: "ContractStatus");

            migrationBuilder.DropTable(
                name: "SalaryAllowance");

            migrationBuilder.DropTable(
                name: "CountryListEntity");

            migrationBuilder.DropTable(
                name: "ProjectContractContractTypeLists");

            migrationBuilder.DropTable(
                name: "Durations");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "BranchList");

            migrationBuilder.DropTable(
                name: "PaymentModeList");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "IqmaList");

            migrationBuilder.DropTable(
                name: "LoanAudits");

            migrationBuilder.DropTable(
                name: "LoanExports");

            migrationBuilder.DropTable(
                name: "LoanLocalizations");

            migrationBuilder.DropTable(
                name: "LoansAuthority");

            migrationBuilder.DropTable(
                name: "TransferIqamas");
        }
    }
}
