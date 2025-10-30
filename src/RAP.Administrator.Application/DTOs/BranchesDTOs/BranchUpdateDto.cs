using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.BranchesDTOs
{
    public class BranchUpdateDto
    {
        public int Id { get; set; }

        public int? CompanyId { get; set; }
        public int? CurrencyId { get; set; }
        public int? CountryId { get; set; }
        public int? BankId { get; set; }
        public int? InvoiceId { get; set; }

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

        public List<BranchLocalizationDto>? Localizations { get; set; }
    }

}
