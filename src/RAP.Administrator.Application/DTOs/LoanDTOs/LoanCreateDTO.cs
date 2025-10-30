using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.LoanDTOs
{
    public class LoanCreateDTO
    {
        public DateTime? Date { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? RepaymentFrom { get; set; }

        public int? IqmaId { get; set; }
        public string? Branch { get; set; }

        public int? PermittedById { get; set; }

        public decimal? Amount { get; set; }
        public decimal? InterestPercentage { get; set; }
        public int? InstallmentPeriod { get; set; }
        public decimal? RepaymentAmount { get; set; }
        public decimal? Installment { get; set; }

        public string? LoanDetails { get; set; }
        public string? LoanStatus { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsDraft { get; set; }

        // Localization
        public List<LoanLocalizationDTO>? Localizations { get; set; }
        public List<LoanExportDTO>? Exports { get; set; }
    }


}
