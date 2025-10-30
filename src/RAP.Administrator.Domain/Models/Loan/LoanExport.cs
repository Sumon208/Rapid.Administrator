using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Loan
{
    public class LoanExport
    {
        [Key]
        public int Id { get; set; }

        public int? LoanId { get; set; }
        public virtual LoanEntity? Loan { get; set; }

        [StringLength(200)] public string? FileName { get; set; }
        [StringLength(20)] public string? FileType { get; set; }  
        [StringLength(500)] public string? FileUrl { get; set; }

        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

        public ICollection<LoanEntity> Loans { get; set; } = new List<LoanEntity>();
    }
}
