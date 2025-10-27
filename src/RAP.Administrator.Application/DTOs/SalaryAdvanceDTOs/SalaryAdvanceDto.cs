using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SalaryAdvanceDTOs
{
    public class SalaryAdvanceDto
    {
        public int? Id { get; set; }
        public int? IqmaId { get; set; }
        public int? BranchId { get; set; }
        public decimal? AdvanceAmount { get; set; }
        public string? Description { get; set; }
        public int? PaymentModeId { get; set; }
        public DateTime? Date { get; set; }

        // Navigation Properties
        public IqmaListDto? Iqma { get; set; }
        public PaymentModeListDto? PaymentMode { get; set; }
        public BranchListDto? Branch { get; set; }

        public List<SalaryAdvanceLocalizationDto>? Localizations { get; set; }
        public List<SalaryAdvanceAuditDto>? Audits { get; set; }
    }

}
