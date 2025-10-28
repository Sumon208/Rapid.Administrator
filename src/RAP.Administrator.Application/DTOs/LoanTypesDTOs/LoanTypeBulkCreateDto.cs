using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.LoanTypesDTOs
{
    public class LoanTypeBulkCreateDto
    {
        public List<LoanTypeCreateDto>? LoanTypes { get; set; }
    }
}
