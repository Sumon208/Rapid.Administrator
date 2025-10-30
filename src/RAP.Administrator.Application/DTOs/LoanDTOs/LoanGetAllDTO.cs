using RAP.Administrator.Domain.Models.SalaryAdvance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.LoanDTOs
{
    public class LoanGetAllDTO
    {
        public int Id { get; set; }


         public int? IqmaId { get; set; }

        public string? IqmaNo { get; set; }
        public string? Branch { get; set; }

        public int? PermittedById { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? RepaymentFrom { get; set; }
        public string? PermittedByName { get; set; }
        public decimal? Amount { get; set; }
        public string? LoanStatus { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsDraft { get; set; }
        public string? Language { get; set; }

        public List<LoanLocalizationDTO>? Localizations { get; set; }
        public List<LoanAuditDTO>? Audits { get; set; }
        

    }

}
