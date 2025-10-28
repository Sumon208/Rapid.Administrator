using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.LoanType
{
    public class LoanTypeEntity
    {
        [Key]
        public int Id { get; set; }               

        [MaxLength(100)]
        public string? LoanTypeText { get; set; } 

        [MaxLength(1000)]
        public string? Description { get; set; }   

        public bool? IsDefault { get; set; }      

        public bool? Draft { get; set; }          

        // navigation
        public ICollection<LoanTypeAudit>? Audits { get; set; }
        public ICollection<LoanTypeLocalization>? Localizations { get; set; }
        public ICollection<LoanTypeExport>? Exports { get; set; }
    }
}
