using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RAP.Administrator.Domain.Models.Branches;
using RAP.Administrator.Domain.Models.CandidateList;
using RAP.Administrator.Domain.Models.CandidateSelection;
using RAP.Administrator.Domain.Models.ContactType;
using RAP.Administrator.Domain.Models.Divisions;
using RAP.Administrator.Domain.Models.Document;
using RAP.Administrator.Domain.Models.DocumentType;
using RAP.Administrator.Domain.Models.EmployeeContract;
using RAP.Administrator.Domain.Models.Insurance;
using RAP.Administrator.Domain.Models.JobLocation;
using RAP.Administrator.Domain.Models.Loan;
using RAP.Administrator.Domain.Models.LoanType;
using RAP.Administrator.Domain.Models.ProjectContract;
using RAP.Administrator.Domain.Models.ProjectContractType;
using RAP.Administrator.Domain.Models.Retirement;
using RAP.Administrator.Domain.Models.SafetyMaterials;
using RAP.Administrator.Domain.Models.SalaryAdvance;
using RAP.Administrator.Domain.Models.ShiftType;
using RAP.Administrator.Domain.Models.Tax;
using RAP.Administrator.Domain.Models.Transfer;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }


    // Branch Master & related
    public DbSet<BranchEntity> MSDBranches { get; set; }
    public DbSet<BranchLocalization> BranchesLocalizations { get; set; }
    public DbSet<BranchAuditEntity> BranchesAudits { get; set; }
    public DbSet<BranchExport> BranchesExports { get; set; }

    // Branch Dropdowns
    public DbSet<CompanyListEntity> CompanyLists { get; set; }
    public DbSet<CurrencyListEntity> CurrencyLists { get; set; }
    public DbSet<BankListEntity> BankLists { get; set; }
    public DbSet<InvoiceFormatListEntity> InvoiceFormats { get; set; }

    // safety-materials
    public DbSet<SafetyMaterialsEntity> SafetyMaterials { get; set; }
    public DbSet<SafetyMaterialsAuditEntity> SafetyMaterialsAudits { get; set; }
    public DbSet<SafetyMaterialsLocalizationEntity> SafetyMaterialsLocalizations { get; set; }
    public DbSet<SafetyMaterialsExportEntity> SafetyMaterialsExports { get; set; }
    public DbSet<DurationEntity> Durations { get; set; }

    public DbSet<EmployeeContractEntity> EmployeeContracts { get; set; }
    public DbSet<EmployeeContractLocalization> EmployeeContractLocalizations { get; set; }
    public DbSet<EmployeeContractAudit> EmployeeContractAudits { get; set; }
    // Tax Tables
    public DbSet<TaxEntity> Taxes { get; set; }
    public DbSet<TaxAuditEntity> TaxAudits { get; set; }

    // Division Tables
    public DbSet<Division> Divisions { get; set; }
    public DbSet<DivisionLocalization> DivisionLocalizations { get; set; }
    public DbSet<DivisionAudit> DivisionAudits { get; set; }
    public DbSet<DivisionExport> DivisionExports { get; set; }

    // ShiftType Tables
    public DbSet<ShiftType> ShiftTypes { get; set; }
    public DbSet<ShiftTypeLocalization> ShiftTypeLocalizations { get; set; }
    public DbSet<ShiftTypeAudit> ShiftTypeAudits { get; set; }
    public DbSet<ShiftTypeExport> ShiftTypeExports { get; set; }

    // Candidate Tables
    public DbSet<CandidateEntity> Candidates { get; set; }
    public DbSet<CandidateLocalization> CandidateLocalizations { get; set; }
    public DbSet<CandidateAudit> CandidateAudits { get; set; }
    public DbSet<CandidateExport> CandidateExports { get; set; }

    public DbSet<Position> Positions { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<RAP.Administrator.Domain.Models.Divisions.ActionType> CandidateActionTypes { get; set; }
    // Insurances tables
    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<InsuranceEntity> Insurances { get; set; }
    public DbSet<InsuranceAuditEntity> InsuranceAudits { get; set; }
    public DbSet<InsuranceLocalization> InsuranceLocalizations { get; set; }
    public DbSet<ExportInsuranceEntity> ExportInsurances { get; set; }
    // Transfer Tables
    public DbSet<TransferEntity> Transfers { get; set; }
    public DbSet<TransferLocalization> TransferLocalizations { get; set; }
    public DbSet<TransferAudit> TransferAudits { get; set; }
    public DbSet<TransferExport> TransferExports { get; set; }

    // Transfer Dropdown Tables
    public DbSet<TransferFromLocationEntity> TransferFromLocations { get; set; }
    public DbSet<TransferToLocationEntity> TransferToLocations { get; set; }
    public DbSet<TransferBranchEntity> TransferBranches { get; set; }
    public DbSet<TransferIqamaEntity> TransferIqamas { get; set; }

    // Retirement Tables
    public DbSet<RetirementEntity> Retirements { get; set; }
    public DbSet<RetirementLocalization> RetirementLocalizations { get; set; }
    public DbSet<RetirementAudit> RetirementAudits { get; set; }
    public DbSet<RetirementExport> RetirementExports { get; set; }
    //Candidate list
    public DbSet<CandidateListEntity> CandidateLists { get; set; }
    public DbSet<CandidateListLocalization> CandidateListLocalizations { get; set; }
    public DbSet<CandidateListAudit> CandidateListAudits { get; set; }
    public DbSet<CandidateListExport> CandidateListExports { get; set; }

    
   
    
    // JobLocation Tables
    public DbSet<RAP.Administrator.Domain.Models.JobLocation.JobLocationEntity> JobLocations { get; set; }
    public DbSet<RAP.Administrator.Domain.Models.JobLocation.JobLocationLocalizationEntity> JobLocationLocalizations { get; set; }
    public DbSet<RAP.Administrator.Domain.Models.JobLocation.JobLocationAuditEntity> JobLocationAudits { get; set; }
    public DbSet<RAP.Administrator.Domain.Models.JobLocation.JobLocationExportEntity> JobLocationExports { get; set; }

    // SalaryAdvance Tables
    public DbSet<SalaryAdvanceEntity> SalaryAdvances { get; set; }
    public DbSet<SalaryAdvanceLocalization> SalaryAdvanceLocalizations { get; set; }
    public DbSet<SalaryAdvanceAudit> SalaryAdvanceAudits { get; set; }
    public DbSet<SalaryAdvanceExport> SalaryAdvanceExports { get; set; }

    public DbSet<IqmaListEntity> Iqmas { get; set; } // dropdown
    public DbSet<PaymentModeListEntity> PaymentModes { get; set; } // dropdown
    public DbSet<BranchListEntity> Branches { get; set; }

    // Contact Type Tables
    public DbSet<RAP.Administrator.Domain.Models.ContactType.ContactTypeEntity> ContactTypes { get; set; }
    public DbSet<RAP.Administrator.Domain.Models.ContactType.ContactTypeLocalizationEntity> ContactTypeLocalizations { get; set; }
    public DbSet<RAP.Administrator.Domain.Models.ContactType.ContactTypeAuditEntity> ContactTypeAudits { get; set; }
    public DbSet<RAP.Administrator.Domain.Models.ContactType.ContactTypeExportEntity> ContactTypeExports { get; set; }

    // Document Type Tables
    public DbSet<DocumentTypeEntity> DocumentTypes { get; set; }
    public DbSet<DocumentTypeLocalization> DocumentTypeLocalizations { get; set; }
    public DbSet<DocumentTypeAudit> DocumentTypeAudits { get; set; }
    public DbSet<DocumentTypeExport> DocumentTypeExports { get; set; }
    public DbSet<DocumentCodeTemplate> DocumentCodeTemplates { get; set; }
    // Document Tables
    public DbSet<DocumentEntity> Documents { get; set; }
    public DbSet<DocumentLocalizationEntity> DocumentLocalizations { get; set; }
    public DbSet<DocumentAuditEntity> DocumentAudits { get; set; }
    public DbSet<DocumentExportEntity> DocumentExports { get; set; }

    // Document Dropdown Tables
    public DbSet<OrderByEntity> OrderByLists { get; set; }
    public DbSet<ShipmentTypeEntity> ShipmentTypeLists { get; set; }

    // LoanType Tables
    public DbSet<LoanTypeEntity> LoanTypes { get; set; }
    public DbSet<LoanTypeLocalization> LoanTypeLocalizations { get; set; }
    public DbSet<LoanTypeAudit> LoanTypeAudits { get; set; }
    public DbSet<LoanTypeExport> LoanTypeExports { get; set; }
    // ContactType Tables
    public DbSet<ContactTypeEntity> Contracts { get; set; }
    public DbSet<ContactTypeLocalizationEntity> ContractTypeLocalizations { get; set; }
    public DbSet<ContactTypeAuditEntity> ContractTypeAudits { get; set; }
    public DbSet<ContactTypeExportEntity> ContractTypeExports { get; set; }

    
    public DbSet<ContactType> ContractTypes { get; set; }
    public DbSet<ContractStatus> ContractStatuses { get; set; }
    public DbSet<SalaryAllowance> SalaryAllowances { get; set; }

    // Project Contract Type Tables
    public DbSet<ProjectContractTypeEntity> ProjectContractTypes { get; set; }
    public DbSet<ProjectContractTypeLocalization> ProjectContractTypeLocalizations { get; set; }
    public DbSet<ProjectContractTypeAudit> ProjectContractTypeAudits { get; set; }
    public DbSet<ProjectContractTypeExport> ProjectContractTypeExports { get; set; }

    public DbSet<ProjectContractEntity> ProjectContracts { get; set; }
    public DbSet<ProjectContractAudit> ProjectContractAudits { get; set; }
    public DbSet<ProjectContractLocalization> ProjectContractLocalizations { get; set; }
    public DbSet<ProjectContractExport> ProjectContractExports { get; set; }

    public DbSet<ProjectContractEntity.ContractTypeList> ProjectContractContractTypeLists { get; set; }

    // Loan Tables
    public DbSet<LoanEntity> Loans { get; set; }
    public DbSet<LoanLocalization> LoanLocalizations { get; set; }
    public DbSet<LoanAudit> LoanAudits { get; set; }
    public DbSet<LoanExport> LoanExports { get; set; }

    public DbSet<AuthorityEntity> LoansAuthority { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Table mappings
        // Branch Master 
        modelBuilder.Entity<BranchEntity>().ToTable("MSDBranches");
        modelBuilder.Entity<BranchLocalization>().ToTable("BranchesLocalizations");
        modelBuilder.Entity<BranchAuditEntity>().ToTable("BranchesAudits");
        modelBuilder.Entity<BranchExport>().ToTable("BranchesExports");


        modelBuilder.Entity<CompanyListEntity>().ToTable("CompanyLists");
        modelBuilder.Entity<CurrencyListEntity>().ToTable("CurrencyLists");
        modelBuilder.Entity<BankListEntity>().ToTable("BankLists");
        modelBuilder.Entity<InvoiceFormatListEntity>().ToTable("InvoiceFormats");

        // Safety-materials
        modelBuilder.Entity<SafetyMaterialsEntity>().ToTable("SafetyMaterials");
        modelBuilder.Entity<SafetyMaterialsAuditEntity>().ToTable("SafetyMaterialsAudits");
        modelBuilder.Entity<SafetyMaterialsExportEntity>().ToTable("SafetyMaterialsExports");
        modelBuilder.Entity<DurationEntity>().ToTable("Durations");
        // Loan Tables
        modelBuilder.Entity<LoanEntity>().ToTable("Loans");
        modelBuilder.Entity<LoanLocalization>().ToTable("LoanLocalizations");
        modelBuilder.Entity<LoanAudit>().ToTable("LoanAudits");
        modelBuilder.Entity<LoanExport>().ToTable("LoanExports");

        // Authority (Permitted By)
        modelBuilder.Entity<AuthorityEntity>().ToTable("LoansAuthority");



        //ProjectContract
        modelBuilder.Entity<ProjectContractEntity>().ToTable("ProjectContracts");
        modelBuilder.Entity<ProjectContractLocalization>().ToTable("ProjectContractLocalizations");
        modelBuilder.Entity<ProjectContractAudit>().ToTable("ProjectContractAudits");
        modelBuilder.Entity<ProjectContractExport>().ToTable("ProjectContractExports");
        modelBuilder.Entity<ProjectContractEntity.ContractTypeList>().ToTable("ProjectContractContractTypeLists");

        // Project Contract Type Tables
        modelBuilder.Entity<ProjectContractTypeEntity>().ToTable("ProjectContractTypes");
        modelBuilder.Entity<ProjectContractTypeLocalization>().ToTable("ProjectContractTypeLocalizations");
        modelBuilder.Entity<ProjectContractTypeAudit>().ToTable("ProjectContractTypeAudits");
        modelBuilder.Entity<ProjectContractTypeExport>().ToTable("ProjectContractTypeExports");

        modelBuilder.Entity<EmployeeContractEntity>().ToTable("EmployeeContracts");
        modelBuilder.Entity<EmployeeContractLocalization>().ToTable("EmployeeContractLocalizations");
        modelBuilder.Entity<EmployeeContractAudit>().ToTable("EmployeeContractAudits");
        modelBuilder.Entity<EmployeeContractExport>().ToTable("EmployeeContractExports");

        modelBuilder.Entity<ContactType>().ToTable("ContactType");
        modelBuilder.Entity<ContractStatus>().ToTable("ContractStatus");
        modelBuilder.Entity<SalaryAllowance>().ToTable("SalaryAllowance");


        modelBuilder.Entity<TaxEntity>().ToTable("Taxes");
        modelBuilder.Entity<TaxAuditEntity>().ToTable("TaxAudits");

        modelBuilder.Entity<Division>().ToTable("Divisions");
        modelBuilder.Entity<DivisionLocalization>().ToTable("DivisionLocalizations");
        modelBuilder.Entity<DivisionAudit>().ToTable("DivisionAudits");
        modelBuilder.Entity<DivisionExport>().ToTable("DivisionExports");

        modelBuilder.Entity<ShiftType>().ToTable("ShiftTypes");
        modelBuilder.Entity<ShiftTypeLocalization>().ToTable("ShiftTypeLocalizations");
        modelBuilder.Entity<ShiftTypeAudit>().ToTable("ShiftTypeAudits");
        modelBuilder.Entity<ShiftTypeExport>().ToTable("ShiftTypeExports");

        modelBuilder.Entity<CandidateEntity>().ToTable("Candidates");
        modelBuilder.Entity<CandidateLocalization>().ToTable("CandidateLocalizations");
        modelBuilder.Entity<CandidateAudit>().ToTable("CandidateAudits");
        modelBuilder.Entity<CandidateExport>().ToTable("CandidateExports");

        modelBuilder.Entity<Position>().ToTable("CandidatePositions");
        modelBuilder.Entity<Team>().ToTable("CandidateTeams");
        modelBuilder.Entity<RAP.Administrator.Domain.Models.Divisions.ActionType>().ToTable("CandidateActionTypes");
        //  Table naming convention 
        modelBuilder.Entity<EmployeeEntity>().ToTable("Employee");
        modelBuilder.Entity<InsuranceEntity>().ToTable("Insurance");
        modelBuilder.Entity<InsuranceAuditEntity>().ToTable("InsuranceAudit");
        modelBuilder.Entity<InsuranceLocalization>().ToTable("InsuranceLocalization");
        modelBuilder.Entity<ExportInsuranceEntity>().ToTable("ExportInsurance");
        // Transfer Tables 
        modelBuilder.Entity<TransferEntity>().ToTable("Transfers");
        modelBuilder.Entity<TransferLocalization>().ToTable("TransferLocalizations");
        modelBuilder.Entity<TransferAudit>().ToTable("TransferAudits");
        modelBuilder.Entity<TransferExport>().ToTable("TransferExports");

        modelBuilder.Entity<TransferFromLocationEntity>().ToTable("TransferFromLocations");
        modelBuilder.Entity<TransferToLocationEntity>().ToTable("TransferToLocations");
        modelBuilder.Entity<TransferBranchEntity>().ToTable("TransferBranches");
        modelBuilder.Entity<TransferIqamaEntity>().ToTable("TransferIqamas");

        modelBuilder.Entity<RetirementEntity>().ToTable("Retirements");
        modelBuilder.Entity<RetirementLocalization>().ToTable("RetirementLocalizations");
        modelBuilder.Entity<RetirementAudit>().ToTable("RetirementAudits");
        modelBuilder.Entity<RetirementExport>().ToTable("RetirementExports");


        modelBuilder.Entity<CandidateListEntity>().ToTable("CandidateLists");
        modelBuilder.Entity<CandidateListLocalization>().ToTable("CandidateListLocalizations");
        modelBuilder.Entity<CandidateListAudit>().ToTable("CandidateListAudits");
        modelBuilder.Entity<CandidateListExport>().ToTable("CandidateListExports");
        

        // JobLocation Table Mappings
        modelBuilder.Entity<RAP.Administrator.Domain.Models.JobLocation.JobLocationEntity>().ToTable("JobLocations");
        modelBuilder.Entity<RAP.Administrator.Domain.Models.JobLocation.JobLocationLocalizationEntity>().ToTable("JobLocationLocalizations");
        modelBuilder.Entity<RAP.Administrator.Domain.Models.JobLocation.JobLocationAuditEntity>().ToTable("JobLocationAudits");
        modelBuilder.Entity<RAP.Administrator.Domain.Models.JobLocation.JobLocationExportEntity>().ToTable("JobLocationExports");

        // SalaryAdvance
        modelBuilder.Entity<SalaryAdvanceEntity>().ToTable("SalaryAdvances");
        modelBuilder.Entity<SalaryAdvanceLocalization>().ToTable("SalaryAdvanceLocalizations");
        modelBuilder.Entity<SalaryAdvanceAudit>().ToTable("SalaryAdvanceAudits");
        modelBuilder.Entity<SalaryAdvanceExport>().ToTable("SalaryAdvanceExports");

        modelBuilder.Entity<IqmaListEntity>().ToTable("IqmaList");
        modelBuilder.Entity<PaymentModeListEntity>().ToTable("PaymentModeList");
        modelBuilder.Entity<BranchListEntity>().ToTable("BranchList");

        // ContactType Table Mappings
        modelBuilder.Entity<ContactTypeEntity>().ToTable("ContactTypes");
        modelBuilder.Entity<ContactTypeLocalizationEntity>().ToTable("ContactTypeLocalizations");
        modelBuilder.Entity<ContactTypeAuditEntity>().ToTable("ContactTypeAudits");
        modelBuilder.Entity<ContactTypeExportEntity>().ToTable("ContactTypeExports");

        //DocumentType
        modelBuilder.Entity<DocumentTypeEntity>().ToTable("DocumentTypes");
        modelBuilder.Entity<DocumentTypeLocalization>().ToTable("DocumentTypeLocalizations");
        modelBuilder.Entity<DocumentTypeAudit>().ToTable("DocumentTypeAudits");
        modelBuilder.Entity<DocumentTypeExport>().ToTable("DocumentTypeExports");
        modelBuilder.Entity<DocumentCodeTemplate>().ToTable("DocumentCodeTemplates");

        // Document Tables
        modelBuilder.Entity<DocumentEntity>().ToTable("Documents");
        modelBuilder.Entity<DocumentLocalizationEntity>().ToTable("DocumentLocalizations");
        modelBuilder.Entity<DocumentAuditEntity>().ToTable("DocumentAudits");
        modelBuilder.Entity<DocumentExportEntity>().ToTable("DocumentExports");

        modelBuilder.Entity<OrderByEntity>().ToTable("OrderByLists");
        modelBuilder.Entity<ShipmentTypeEntity>().ToTable("ShipmentTypeLists");

        modelBuilder.Entity<LoanTypeEntity>().ToTable("LoanTypes");
        modelBuilder.Entity<LoanTypeLocalization>().ToTable("LoanTypeLocalizations");
        modelBuilder.Entity<LoanTypeAudit>().ToTable("LoanTypeAudits");
        modelBuilder.Entity<LoanTypeExport>().ToTable("LoanTypeExports");

       

        // Branch Dropdowns
        modelBuilder.Entity<CompanyListEntity>().ToTable("CompanyLists");
        modelBuilder.Entity<CurrencyListEntity>().ToTable("CurrencyLists");
        
        modelBuilder.Entity<BankListEntity>().ToTable("BankLists");
        modelBuilder.Entity<InvoiceFormatListEntity>().ToTable("InvoiceFormats");

        // Primary Keys

        modelBuilder.Entity<BranchEntity>().HasKey(b => b.Id);
        modelBuilder.Entity<BranchLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<BranchAuditEntity>().HasKey(a => a.Id);
        modelBuilder.Entity<BranchExport>().HasKey(e => e.Id);

        modelBuilder.Entity<CompanyListEntity>().HasKey(c => c.Id);
        modelBuilder.Entity<CurrencyListEntity>().HasKey(c => c.Id);
        modelBuilder.Entity<BankListEntity>().HasKey(b => b.Id);
        modelBuilder.Entity<InvoiceFormatListEntity>().HasKey(i => i.Id);

        modelBuilder.Entity<LoanEntity>().HasKey(l => l.Id);
        modelBuilder.Entity<LoanLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<LoanAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<LoanExport>().HasKey(e => e.Id);
        modelBuilder.Entity<AuthorityEntity>().HasKey(a => a.Id);
       


        modelBuilder.Entity<ProjectContractTypeEntity>().HasKey(p => p.Id);
        modelBuilder.Entity<ProjectContractTypeLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<ProjectContractTypeAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<ProjectContractTypeExport>().HasKey(e => e.Id);


        modelBuilder.Entity<Division>().HasKey(d => d.Id);
        modelBuilder.Entity<DivisionLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<DivisionAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<DivisionExport>().HasKey(e => e.Id);

        modelBuilder.Entity<ShiftType>().HasKey(s => s.Id);
        modelBuilder.Entity<ShiftTypeLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<ShiftTypeAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<ShiftTypeExport>().HasKey(e => e.Id);

        modelBuilder.Entity<CandidateEntity>().HasKey(c => c.Id);
        modelBuilder.Entity<CandidateLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<CandidateAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<CandidateExport>().HasKey(e => e.Id);
        modelBuilder.Entity<Position>().HasKey(p => p.Id);
        modelBuilder.Entity<Team>().HasKey(t => t.Id);

        modelBuilder.Entity<RAP.Administrator.Domain.Models.Divisions.ActionType>().HasKey(at => at.Id);
        modelBuilder.Entity<EmployeeContractEntity>().HasKey(e => e.Id);
        modelBuilder.Entity<EmployeeContractAudit>().HasKey(e => e.Id);
        modelBuilder.Entity<ContactTypeEntity>().HasKey(c => c.Id);
        modelBuilder.Entity<ContactTypeAuditEntity>().HasKey(c => c.Id);

        //  Key configurations
        modelBuilder.Entity<EmployeeEntity>().HasKey(e => e.Id);
        modelBuilder.Entity<InsuranceEntity>().HasKey(i => i.Id);
        modelBuilder.Entity<InsuranceAuditEntity>().HasKey(a => a.Id);
        modelBuilder.Entity<InsuranceLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<ExportInsuranceEntity>().HasKey(e => e.Id);

        modelBuilder.Entity<TransferEntity>().HasKey(t => t.Id);
        modelBuilder.Entity<TransferLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<TransferAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<TransferExport>().HasKey(e => e.Id);

        modelBuilder.Entity<TransferFromLocationEntity>().HasKey(f => f.Id);
        modelBuilder.Entity<TransferToLocationEntity>().HasKey(t => t.Id);
        modelBuilder.Entity<TransferBranchEntity>().HasKey(b => b.Id);
        modelBuilder.Entity<TransferIqamaEntity>().HasKey(i => i.Id);

        modelBuilder.Entity<RetirementEntity>().HasKey(r => r.Id);

        modelBuilder.Entity<RetirementLocalization>().HasKey(l => l.Id);

        modelBuilder.Entity<RetirementAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<RetirementExport>().HasNoKey();

        modelBuilder.Entity<CandidateListEntity>().HasKey(c => c.Id);
        modelBuilder.Entity<CandidateListLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<CandidateListAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<CandidateListExport>().HasKey(e => e.Id);
        //modelBuilder.Entity<CountryListEntity>().HasKey(c => c.Id);

        // JobLocation Keys
        modelBuilder.Entity<RAP.Administrator.Domain.Models.JobLocation.JobLocationEntity>().HasKey(j => j.Id);
        modelBuilder.Entity<RAP.Administrator.Domain.Models.JobLocation.JobLocationLocalizationEntity>().HasKey(l => l.Id);
        modelBuilder.Entity<RAP.Administrator.Domain.Models.JobLocation.JobLocationAuditEntity>().HasKey(a => a.Id);
        modelBuilder.Entity<RAP.Administrator.Domain.Models.JobLocation.JobLocationExportEntity>().HasKey(e => e.Id);
        //SalaryAdvance
        modelBuilder.Entity<SalaryAdvanceEntity>().HasKey(s => s.Id);
        modelBuilder.Entity<SalaryAdvanceLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<SalaryAdvanceAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<SalaryAdvanceExport>().HasKey(e => e.Id);

        modelBuilder.Entity<IqmaListEntity>().HasKey(i => i.Id);
        modelBuilder.Entity<PaymentModeListEntity>().HasKey(p => p.Id);
        modelBuilder.Entity<BranchListEntity>().HasKey(b => b.Id);
        //Contact Type
        modelBuilder.Entity<ContactTypeEntity>().HasKey(c => c.Id);
        modelBuilder.Entity<ContactTypeLocalizationEntity>().HasKey(l => l.Id);
        modelBuilder.Entity<ContactTypeAuditEntity>().HasKey(a => a.Id);
        modelBuilder.Entity<ContactTypeExportEntity>().HasKey(e => e.Id);


        //DocumentType

        modelBuilder.Entity<DocumentTypeEntity>().HasKey(d => d.Id);
        modelBuilder.Entity<DocumentTypeLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<DocumentTypeAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<DocumentTypeExport>().HasKey(e => e.Id);
        modelBuilder.Entity<DocumentCodeTemplate>().HasKey(t => t.Id);

        // Document Keys
        modelBuilder.Entity<DocumentEntity>().HasKey(d => d.Id);
        modelBuilder.Entity<DocumentLocalizationEntity>().HasKey(l => l.Id);
        modelBuilder.Entity<DocumentAuditEntity>().HasKey(a => a.Id);
        modelBuilder.Entity<DocumentExportEntity>().HasKey(e => e.Id);

        // Dropdown Keys
        modelBuilder.Entity<OrderByEntity>().HasKey(o => o.Id);
        modelBuilder.Entity<ShipmentTypeEntity>().HasKey(s => s.Id);


        // LoanType Primary Keys
        modelBuilder.Entity<LoanTypeEntity>().HasKey(l => l.Id);
        modelBuilder.Entity<LoanTypeLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<LoanTypeAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<LoanTypeExport>().HasKey(e => e.Id);

        

        // dropdown for contract-type
        modelBuilder.Entity<ContractStatus>().ToTable("ContractStatus");
        modelBuilder.Entity<ContractStatus>().HasKey(c => c.Id);
        modelBuilder.Entity<ContactTypeExportEntity>().HasKey(c => c.Id);

        modelBuilder.Entity<SalaryAllowance>().ToTable("SalaryAllowance");
        modelBuilder.Entity<SalaryAllowance>().HasKey(s => s.Id);

        modelBuilder.Entity<ProjectContractEntity>().HasKey(pc => pc.Id);
        modelBuilder.Entity<ProjectContractAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<ProjectContractLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<ProjectContractExport>().HasKey(e => e.Id);
        modelBuilder.Entity<ProjectContractEntity.ContractTypeList>().HasKey(ct => ct.Id);

        modelBuilder.Entity<SafetyMaterialsEntity>().HasKey(s => s.Id);
        modelBuilder.Entity<SafetyMaterialsLocalizationEntity>().HasKey(l => l.Id);
        modelBuilder.Entity<SafetyMaterialsAuditEntity>().HasKey(a => a.Id);
        modelBuilder.Entity<RAP.Administrator.Domain.Models.SafetyMaterials.SafetyMaterialsExportEntity>().HasKey(e => e.Id);
        modelBuilder.Entity<DurationEntity>().HasKey(d => d.Id);

       

        modelBuilder.Entity<TaxEntity>()
            .Property(t => t.OpeningBalance)
            .HasColumnType("decimal(18,4)"); 

            modelBuilder.Entity<TaxAuditEntity>()
                .Property(t => t.Latitude)
                .HasColumnType("decimal(18,8)");

            modelBuilder.Entity<TaxAuditEntity>()
                .Property(t => t.Longitude)
                .HasColumnType("decimal(18,8)");

        // Relations: Division
        modelBuilder.Entity<Division>()
            .HasMany(d => d.Localizations)
            .WithOne(l => l.Division)
            .HasForeignKey(l => l.DivisionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Division>()
            .HasMany(d => d.Audits)
            .WithOne(a => a.Division)
            .HasForeignKey(a => a.DivisionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Division>()
            .HasMany(d => d.Exports)
            .WithOne(e => e.Division)
            .HasForeignKey(e => e.DivisionId)
            .OnDelete(DeleteBehavior.Cascade);

        //  ShiftType
        modelBuilder.Entity<ShiftType>()
            .HasMany(s => s.Localizations)
            .WithOne(l => l.ShiftType)
            .HasForeignKey(l => l.ShiftTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ShiftType>()
            .HasMany(s => s.Audits)
            .WithOne(a => a.ShiftType)
            .HasForeignKey(a => a.ShiftTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ShiftType>()
            .HasMany(s => s.Exports)
            .WithOne(e => e.ShiftType)
            .HasForeignKey(e => e.ShiftTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CandidateEntity>()
 .HasMany(c => c.Localizations)
 .WithOne(l => l.Candidate)
 .HasForeignKey(l => l.CandidateId)
 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CandidateEntity>()
            .HasMany(c => c.Audits)
            .WithOne(a => a.Candidate)
            .HasForeignKey(a => a.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CandidateEntity>()
            .HasMany(c => c.Exports)
            .WithOne(e => e.Candidate)
            .HasForeignKey(e => e.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<CandidateAudit>()
            .HasOne(a => a.ActionType)
            .WithMany(at => at.CandidateAudits)
            .HasForeignKey(a => a.ActionTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        //  Employee Insurance (One-to-Many)
        modelBuilder.Entity<InsuranceEntity>()
            .HasOne(i => i.Employee)
            .WithMany(e => e.Insurances)
            .HasForeignKey(i => i.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        //  Insuranc InsuranceAudit (One-to-Many)
        modelBuilder.Entity<InsuranceAuditEntity>()
            .HasOne(a => a.Insurance)
            .WithMany(i => i.Audits)
            .HasForeignKey(a => a.InsuranceId)
            .OnDelete(DeleteBehavior.Cascade);

        // Insurance InsuranceLocalization (One-to-Many)
        modelBuilder.Entity<InsuranceLocalization>()
            .HasOne(l => l.Insurance)
            .WithMany(i => i.Localizations)
            .HasForeignKey(l => l.InsuranceId)
            .OnDelete(DeleteBehavior.Cascade);

        //  Insurance  ExportInsurance (One-to-Many)
        modelBuilder.Entity<ExportInsuranceEntity>()
            .HasOne(e => e.Insurance)
            .WithMany(i => i.ExportInsurances)
            .HasForeignKey(e => e.InsuranceId)
            .OnDelete(DeleteBehavior.Cascade);

        // Transfer
        modelBuilder.Entity<TransferEntity>()
        .HasMany(t => t.Localizations)
        .WithOne(l => l.Transfer)
        .HasForeignKey(l => l.TransferId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TransferEntity>()
            .HasMany(t => t.Audits)
            .WithOne(a => a.Transfer)
            .HasForeignKey(a => a.TransferId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TransferEntity>()
            .HasMany(t => t.Exports)
            .WithOne(e => e.Transfer)
            .HasForeignKey(e => e.TransferId)
            .OnDelete(DeleteBehavior.Cascade);

        // Retirement Localizations (One-to-Many)
        modelBuilder.Entity<RetirementEntity>()
            .HasMany(r => r.Localizations)
            .WithOne(l => l.Retirement)
            .HasForeignKey(l => l.RetirementId)
            .OnDelete(DeleteBehavior.Cascade);

       // Retirement Audits (One-to-Many)
        modelBuilder.Entity<RetirementEntity>()
            .HasMany(r => r.Audits)
            .WithOne(a => a.Retirement)
            .HasForeignKey(a => a.RetirementId)
            .OnDelete(DeleteBehavior.Cascade);

        // Employee Retirement (One-to-Many)
        modelBuilder.Entity<RetirementEntity>()
            .HasOne<EmployeeEntity>() 
            .WithMany(e => e.Retirement)
            .HasForeignKey("EmployeeId") 
            .OnDelete(DeleteBehavior.Restrict);

        // CandidateList 
        modelBuilder.Entity<CandidateListEntity>()
            .HasMany(c => c.Localizations)
            .WithOne(l => l.Candidate)
            .HasForeignKey(l => l.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<CandidateListEntity>()
            .HasMany(c => c.Audits)
            .WithOne(a => a.Candidate)
            .HasForeignKey(a => a.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<CandidateListEntity>()
            .HasOne<RAP.Administrator.Domain.Models.CandidateList.CountryListEntity>()
            .WithMany()
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        // JobLocation Relationships
        modelBuilder.Entity<RAP.Administrator.Domain.Models.JobLocation.JobLocationEntity>()
            .HasMany(j => j.Localizations)
            .WithOne(l => l.JobLocation)
            .HasForeignKey(l => l.JobLocationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RAP.Administrator.Domain.Models.JobLocation.JobLocationEntity>()
            .HasMany(j => j.Audits)
            .WithOne(a => a.JobLocation)
            .HasForeignKey(a => a.JobLocationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<JobLocationEntity>()

              .HasOne(j => j.Country)
              .WithMany()
              .HasForeignKey(j => j.CountryId)
              .OnDelete(DeleteBehavior.Restrict); // keeps nullable safe



        // SalaryAdvance - Localizations 
        modelBuilder.Entity<SalaryAdvanceEntity>()
            .HasMany(s => s.Localizations)
            .WithOne(l => l.SalaryAdvance)
            .HasForeignKey(l => l.SalaryAdvanceId)
            .OnDelete(DeleteBehavior.Cascade);

        // SalaryAdvance - Audits 
        modelBuilder.Entity<SalaryAdvanceEntity>()
            .HasMany(s => s.Audits)
            .WithOne(a => a.SalaryAdvance)
            .HasForeignKey(a => a.SalaryAdvanceId)
            .OnDelete(DeleteBehavior.Cascade);

        // SalaryAdvance - Exports 
        modelBuilder.Entity<SalaryAdvanceEntity>()
            .HasMany<SalaryAdvanceExport>()
            .WithOne(e => e.SalaryAdvance)
            .HasForeignKey(e => e.SalaryAdvanceId)
            .OnDelete(DeleteBehavior.Cascade);

        // SalaryAdvance -Iqma 
        modelBuilder.Entity<SalaryAdvanceEntity>()
            .HasOne(s => s.Iqma)
            .WithMany()
            .HasForeignKey(s => s.IqmaId)
            .OnDelete(DeleteBehavior.Restrict);

        // SalaryAdvance - PaymentMode 
        modelBuilder.Entity<SalaryAdvanceEntity>()
            .HasOne(s => s.PaymentMode)
            .WithMany()
            .HasForeignKey(s => s.PaymentModeId)
            .OnDelete(DeleteBehavior.Restrict);

        // SalaryAdvance- Branch 
        modelBuilder.Entity<SalaryAdvanceEntity>()
            .HasOne(s => s.Branches)
            .WithMany()
            .HasForeignKey(s => s.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
        //contactType
        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeEntity>()
    .HasMany(c => c.Localizations)
    .WithOne(l => l.ContactType)
    .HasForeignKey(l => l.ContactTypeId)
    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeEntity>()
            .HasMany(c => c.Audits)
            .WithOne()
            .HasForeignKey(a => a.ContactTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeAuditEntity>()
            .Property(a => a.Latitude)
            .HasColumnType("decimal(18,8)");

        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeAuditEntity>()
            .Property(a => a.Longitude)
            .HasColumnType("decimal(18,8)");

        //Dcument Type
        // Relationships
        modelBuilder.Entity<DocumentTypeEntity>()
            .HasMany(d => d.Localizations)
            .WithOne(l => l.DocumentType)
            .HasForeignKey(l => l.DocumentTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DocumentTypeEntity>()
            .HasMany(d => d.Audits)
            .WithOne(a => a.DocumentType)
            .HasForeignKey(a => a.DocumentTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DocumentTypeEntity>()
            .HasMany(d => d.Exports)
            .WithOne(e => e.DocumentType)
            .HasForeignKey(e => e.DocumentTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Decimal precision for audits
        modelBuilder.Entity<DocumentTypeAudit>()
            .Property(a => a.Latitude)
            .HasColumnType("decimal(18,8)");

        modelBuilder.Entity<DocumentTypeAudit>()
            .Property(a => a.Longitude)
            .HasColumnType("decimal(18,8)");

        // Document Localization 
        modelBuilder.Entity<DocumentEntity>()
            .HasMany(d => d.Localizations)
            .WithOne(l => l.Document)
            .HasForeignKey(l => l.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Document Audit 
        modelBuilder.Entity<DocumentEntity>()
            .HasMany(d => d.Audits)
            .WithOne(a => a.Document)
            .HasForeignKey(a => a.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Document Export 
        modelBuilder.Entity<DocumentEntity>()
            .HasMany(d => d.Exports)
            .WithOne(e => e.Document)
            .HasForeignKey(e => e.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);
        // Loan Type
        modelBuilder.Entity<LoanTypeEntity>()
        .HasMany(l => l.Localizations)
        .WithOne(l => l.LoanType)
        .HasForeignKey(l => l.LoanTypeId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LoanTypeEntity>()
            .HasMany(l => l.Audits)
            .WithOne(a => a.LoanType)
            .HasForeignKey(a => a.LoanTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LoanTypeEntity>()
            .HasMany(l => l.Exports)
            .WithOne(e => e.LoanType)
            .HasForeignKey(e => e.LoanTypeId)
            .OnDelete(DeleteBehavior.Cascade);

       
        // EmployeeContract 
      
        modelBuilder.Entity<EmployeeContractEntity>()
            .HasOne(ec => ec.ContactType)
            .WithMany()
            .HasForeignKey(ec => ec.ContactTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EmployeeContractEntity>()
            .HasOne(ec => ec.Status)
            .WithMany()
            .HasForeignKey(ec => ec.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EmployeeContractEntity>()
            .HasOne(ec => ec.SalaryAllowance)
            .WithMany()
            .HasForeignKey(ec => ec.SalaryAllowanceId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EmployeeContractEntity>()
            .HasOne(ec => ec.Staff)
            .WithMany()
            .HasForeignKey(ec => ec.StaffId)
            .OnDelete(DeleteBehavior.Restrict);

        // ProjectContractType
        modelBuilder.Entity<ProjectContractTypeEntity>()
            .HasMany(p => p.Localizations)
            .WithOne(l => l.ProjectContractType)
            .HasForeignKey(l => l.ProjectContractTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<ProjectContractTypeEntity>()
            .HasMany(p => p.Audits)
            .WithOne(a => a.ProjectContractType)
            .HasForeignKey(a => a.ProjectContractTypeId)
            .OnDelete(DeleteBehavior.Cascade);

      
        modelBuilder.Entity<ProjectContractTypeEntity>()
            .HasMany(p => p.Exports)
            .WithOne(e => e.ProjectContractType)
            .HasForeignKey(e => e.LoanTypeId) 
            .OnDelete(DeleteBehavior.Cascade);


       // ProjectContractEntity 
           modelBuilder.Entity<ProjectContractEntity>()
                .HasOne(pc => pc.ContractType)
                .WithMany(ct => ct.ProjectContracts)
                .HasForeignKey(pc => pc.ContractTypeId)
                .OnDelete(DeleteBehavior.Restrict);

       
        modelBuilder.Entity<ProjectContractEntity>()
            .HasMany(pc => pc.Audits)
            .WithOne(a => a.ProjectContract)
            .HasForeignKey(a => a.ProjectContractId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<ProjectContractEntity>()
            .HasMany(pc => pc.Localizations)
            .WithOne(l => l.ProjectContract)
            .HasForeignKey(l => l.ProjectContractId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<ProjectContractEntity>()
            .HasMany(pc => pc.Exports)
            .WithOne(e => e.ProjectContract)
            .HasForeignKey(e => e.ProjectContractId)
            .OnDelete(DeleteBehavior.Cascade);

        // Loan 
        modelBuilder.Entity<LoanEntity>()
            .HasMany(l => l.Localizations)
            .WithOne(loc => loc.Loan)
            .HasForeignKey(loc => loc.LoanId)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<LoanEntity>()
            .HasMany(l => l.Audits)
            .WithOne(a => a.Loan)
            .HasForeignKey(a => a.LoanId)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<LoanEntity>()
            .HasMany(l => l.Exports)
            .WithOne(e => e.Loan)
            .HasForeignKey(e => e.LoanId)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<LoanEntity>()
            .HasOne(l => l.Authority)
            .WithMany(a => a.Loans)
            .HasForeignKey(l => l.PermittedById)
            .OnDelete(DeleteBehavior.Restrict);
        // SafetyMaterials 
        modelBuilder.Entity<SafetyMaterialsEntity>()
            .HasMany(s => s.Localizations)
            .WithOne(l => l.SafetyMaterials)
            .HasForeignKey(l => l.SafetyMaterialsId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<SafetyMaterialsEntity>()
            .HasMany(s => s.Audits)
            .WithOne(a => a.SafetyMaterials)
            .HasForeignKey(a => a.SafetyMaterialsId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<SafetyMaterialsEntity>()
            .HasMany(s => s.Exports)
            .WithOne(e => e.SafetyMaterials)
            .HasForeignKey(e => e.SafetyMaterialsId)
            .OnDelete(DeleteBehavior.Cascade);

      
        modelBuilder.Entity<SafetyMaterialsEntity>()
            .HasOne(s => s.Employee)
            .WithMany(e => e.SafetyMaterials)
            .HasForeignKey(s => s.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

       
        modelBuilder.Entity<SafetyMaterialsEntity>()
            .HasOne(s => s.Duration)
            .WithMany(d => d.SafetyMaterials)
            .HasForeignKey(s => s.DurationId)
            .OnDelete(DeleteBehavior.Restrict);

       
        modelBuilder.Entity<DurationEntity>()
            .HasMany(d => d.SafetyMaterials)
            .WithOne(s => s.Duration)
            .HasForeignKey(s => s.DurationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<LoanEntity>()
            .HasOne<TransferIqamaEntity>()   
            .WithMany()
            .HasForeignKey(l => l.IqmaId)
            .OnDelete(DeleteBehavior.Restrict);
        // Branch -> Children
        // ======================
        modelBuilder.Entity<BranchEntity>()
            .HasMany(b => b.Localizations)
            .WithOne(l => l.Branch)   // single navigation in child
            .HasForeignKey(l => l.BranchId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BranchEntity>()
            .HasMany(b => b.Audits)
            .WithOne(a => a.Branch)
            .HasForeignKey(a => a.BranchId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BranchEntity>()
            .HasMany(b => b.Exports)
            .WithOne(e => e.Branch)
            .HasForeignKey(e => e.BranchId)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<BranchEntity>()
            .HasOne(b => b.Company)
            .WithMany()
            .HasForeignKey(b => b.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BranchEntity>()
            .HasOne(b => b.Currency)
            .WithMany()
            .HasForeignKey(b => b.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BranchEntity>()
            .HasOne(b => b.Country)
            .WithMany()
            .HasForeignKey(b => b.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BranchEntity>()
            .HasOne(b => b.Bank)
            .WithMany()
            .HasForeignKey(b => b.BankId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BranchEntity>()
            .HasOne(b => b.Invoice)
            .WithMany()
            .HasForeignKey(b => b.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);


        base.OnModelCreating(modelBuilder);
    }
}
