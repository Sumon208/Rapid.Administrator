using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.LoanType
{
    public class LoanTypeLocalization
    {

        [Key]
        public int Id { get; set; }

        public int? LoanTypeId { get; set; }
    
        public int? LanguageId { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }
        public LoanTypeEntity LoanType { get; set; }
    }
}
