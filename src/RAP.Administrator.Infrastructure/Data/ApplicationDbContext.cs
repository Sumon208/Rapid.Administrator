using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RAP.Administrator.Domain.Models.CandidateList;
using RAP.Administrator.Domain.Models.CandidateSelection;
using RAP.Administrator.Domain.Models.Divisions;
using RAP.Administrator.Domain.Models.Document;
using RAP.Administrator.Domain.Models.DocumentType;
using RAP.Administrator.Domain.Models.Insurance;
using RAP.Administrator.Domain.Models.LoanType;
using RAP.Administrator.Domain.Models.Retirement;
using RAP.Administrator.Domain.Models.SalaryAdvance;
using RAP.Administrator.Domain.Models.ShiftType;
using RAP.Administrator.Domain.Models.Tax;
using RAP.Administrator.Domain.Models.Transfer;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

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

    public DbSet<CountryListEntity> CountryLists { get; set; }
   
    
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Table mappings
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
        modelBuilder.Entity<CountryListEntity>().ToTable("CountryLists");

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
        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeEntity>().ToTable("ContactTypes");
        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeLocalizationEntity>().ToTable("ContactTypeLocalizations");
        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeAuditEntity>().ToTable("ContactTypeAudits");
        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeExportEntity>().ToTable("ContactTypeExports");

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
        // Primary Keys
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
        modelBuilder.Entity<CountryListEntity>().HasKey(c => c.Id);

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
        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeEntity>().HasKey(c => c.Id);
        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeLocalizationEntity>().HasKey(l => l.Id);
        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeAuditEntity>().HasKey(a => a.Id);
        modelBuilder.Entity<RAP.Administrator.Domain.Models.ContactType.ContactTypeExportEntity>().HasKey(e => e.Id);


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
            .HasOne<CountryListEntity>()
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

           modelBuilder.Entity<RAP.Administrator.Domain.Models.JobLocation.JobLocationEntity>()
            .HasOne(j => j.Country)
            .WithMany()
            .HasForeignKey(j => j.CountryId)
            .OnDelete(DeleteBehavior.Restrict);


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

        // Document ↔ Localization (One-to-Many)
        modelBuilder.Entity<DocumentEntity>()
            .HasMany(d => d.Localizations)
            .WithOne(l => l.Document)
            .HasForeignKey(l => l.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Document ↔ Audit (One-to-Many)
        modelBuilder.Entity<DocumentEntity>()
            .HasMany(d => d.Audits)
            .WithOne(a => a.Document)
            .HasForeignKey(a => a.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Document ↔ Export (One-to-Many)
        modelBuilder.Entity<DocumentEntity>()
            .HasMany(d => d.Exports)
            .WithOne(e => e.Document)
            .HasForeignKey(e => e.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);

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

        base.OnModelCreating(modelBuilder);
    }
}
