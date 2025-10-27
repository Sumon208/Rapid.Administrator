using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SalaryAdvance
{
    public class SalaryAdvanceEntity
    {
        public int Id { get; set; }
        public int? IqmaId { get; set; }            
        public int? BranchId { get; set; }          
        public decimal? AdvanceAmount { get; set; }
        public string? Description { get; set; }
        public int? PaymentModeId { get; set; }     
        public DateTime? Date { get; set; }

        // Navigation Properties
        public virtual IqmaListEntity? Iqma { get; set; }
        public virtual PaymentModeListEntity? PaymentMode { get; set; }
        public virtual BranchListEntity? Branches { get; set; }
        public virtual ICollection<SalaryAdvanceLocalization>? Localizations { get; set; }
        public virtual ICollection<SalaryAdvanceAudit>? Audits { get; set; }
    }

}
