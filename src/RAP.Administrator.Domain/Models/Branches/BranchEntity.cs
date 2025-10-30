using RAP.Administrator.Domain.Models.CandidateList;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RAP.Administrator.Domain.Models.Branches
{
    public class BranchEntity
    {
        public int Id { get; set; }

        // Dropdowns / FKs
        public int? CompanyId { get; set; }
        public CompanyListEntity? Company { get; set; }

        public int? CurrencyId { get; set; }
        public CurrencyListEntity? Currency { get; set; }

        public int? CountryId { get; set; }
        public CountryListEntity? Country { get; set; }

        public int? BankId { get; set; }
        public BankListEntity? Bank { get; set; }

        public int? InvoiceId { get; set; }
        public InvoiceFormatListEntity? Invoice { get; set; }

        // Branch info
        [MaxLength(50)]
        public string? BranchName { get; set; }

        [MaxLength(100)]
        public string? BranchArabic { get; set; }

        [MaxLength(100)]
        public string? VATNumber { get; set; }

        [MaxLength(200)]
        public string? Website { get; set; }

        [MaxLength(50)]
        public string? Phone { get; set; }

        [MaxLength(50)]
        public string? CurrencySymbol { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? State { get; set; }

        [MaxLength(20)]
        public string? PostCode { get; set; }

        [MaxLength(100)]
        public string? PrintFormat { get; set; }

        // Navigation collections
        public ICollection<BranchLocalization>? Localizations { get; set; }
        public ICollection<BranchAuditEntity>? Audits { get; set; }
        public ICollection<BranchExport>? Exports { get; set; }
    }
}
