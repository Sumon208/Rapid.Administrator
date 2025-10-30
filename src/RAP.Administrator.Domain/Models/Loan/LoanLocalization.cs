using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Loan
{
    public class LoanLocalization
    {
        [Key]
        public int Id { get; set; }

        public int? LoanId { get; set; }
        public virtual LoanEntity? Loan { get; set; }

        public int? LanguageId { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        public ICollection<LoanEntity> Loans { get; set; } = new List<LoanEntity>();
    }
}
