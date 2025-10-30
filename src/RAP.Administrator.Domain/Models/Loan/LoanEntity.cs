using RAP.Administrator.Domain.Models.SalaryAdvance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Loan
{
    public class LoanEntity
    {
        [Key]
        public int Id { get; set; } 

        public DateTime? Date { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? RepaymentFrom { get; set; }

      
        public int? IqmaId { get; set; }
        public virtual IqmaListEntity? Iqma { get; set; }

   
        public string? Branch {  get; set; }

        // Dropdown: Permitted By (Authority)
        public int? PermittedById { get; set; }
        public virtual AuthorityEntity? Authority { get; set; }

        public decimal? Amount { get; set; }
        public decimal? InterestPercentage { get; set; }
        public int? InstallmentPeriod { get; set; }
        public decimal? RepaymentAmount { get; set; }
        public decimal? Installment { get; set; }

        [StringLength(500)]
        public string? LoanDetails { get; set; }

        [StringLength(20)]
        public string? LoanStatus { get; set; }

        public bool? IsDefault { get; set; }
        public bool? IsDraft { get; set; }

        // Navigation
        public virtual ICollection<LoanLocalization>? Localizations { get; set; }
        public virtual ICollection<LoanExport>? Exports { get; set; }
        
        public virtual ICollection<LoanAudit>? Audits { get; set; }
    }
    public class AuthorityEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

      
        public virtual ICollection<LoanEntity> Loans { get; set; }

       
    }

}
