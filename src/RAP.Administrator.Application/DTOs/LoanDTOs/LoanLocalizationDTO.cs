using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.LoanDTOs
{
    public class LoanLocalizationDTO
    {
        public int? Id { get; set; }
        public int? LoanId { get; set; }
        public int? LanguageId { get; set; }
        public string? Name { get; set; }
    }

}
