using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.BranchesDTOs
{
    public class BranchDto
    {
        public int Id { get; set; }

        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }

        public int? CurrencyId { get; set; }
        public string? CurrencyCode { get; set; }

        public int? CountryId { get; set; }
        public string? CountryName { get; set; }

        public int? BankId { get; set; }
        public string? BankName { get; set; }

        public int? InvoiceId { get; set; }
        public string? InvoiceName { get; set; }

        // Branch info
        public string? BranchName { get; set; }
        public string? BranchArabic { get; set; }
        public string? VATNumber { get; set; }
        public string? Website { get; set; }
        public string? Phone { get; set; }
        public string? CurrencySymbol { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostCode { get; set; }
        public string? PrintFormat { get; set; }

        // Navigation
        public List<BranchLocalizationDto>? Localizations { get; set; }
        public List<BranchAuditDto>? Audits { get; set; }
    }

}
