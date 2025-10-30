using RAP.Administrator.Domain.Models.Divisions;
using RAP.Administrator.Domain.Models.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.LoanDTOs
{
    public class PagedLoansResponse
    {
        public IEnumerable<LoanEntity> Data { get; set; } = new List<LoanEntity>();
        public int TotalCount { get; set; }
    }
}
