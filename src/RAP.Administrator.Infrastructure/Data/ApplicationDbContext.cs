using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Domain.Models;
using RAP.Domain.Models;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       // Division and  Tax Mapping
        modelBuilder.Entity<TaxEntity>().ToTable("Taxes");
        modelBuilder.Entity<TaxAuditEntity>().ToTable("TaxAudits");

        modelBuilder.Entity<Division>().ToTable("Divisions");
        modelBuilder.Entity<DivisionLocalization>().ToTable("DivisionLocalizations");
        modelBuilder.Entity<DivisionAudit>().ToTable("DivisionAudits");
        modelBuilder.Entity<DivisionExport>().ToTable("DivisionExports");

        modelBuilder.Entity<Division>().HasKey(d => d.Id);
        modelBuilder.Entity<DivisionLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<DivisionAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<DivisionExport>().HasKey(e => e.Id);

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

        //  ShiftType Mapping
        modelBuilder.Entity<ShiftType>().ToTable("ShiftTypes");
        modelBuilder.Entity<ShiftTypeLocalization>().ToTable("ShiftTypeLocalizations");
        modelBuilder.Entity<ShiftTypeAudit>().ToTable("ShiftTypeAudits");
        modelBuilder.Entity<ShiftTypeExport>().ToTable("ShiftTypeExports");

        modelBuilder.Entity<ShiftType>().HasKey(s => s.Id);
        modelBuilder.Entity<ShiftTypeLocalization>().HasKey(l => l.Id);
        modelBuilder.Entity<ShiftTypeAudit>().HasKey(a => a.Id);
        modelBuilder.Entity<ShiftTypeExport>().HasKey(e => e.Id);

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

        base.OnModelCreating(modelBuilder);
    }
}
