using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Domain.Models.CandidateSelection;
using RAP.Administrator.Domain.Models.Divisions;
using RAP.Administrator.Domain.Models.Insurance;
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

        base.OnModelCreating(modelBuilder);
    }
}
