using RAP.Administrator.Domain.Models.Divisions;
using RAP.Administrator.Domain.Models.LoanType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.LoanTypesDTOs
{
    public class PagedLoanTypeResponse
    {

        public IEnumerable<LoanTypeEntity> Data { get; set; } = new List<LoanTypeEntity>();
        public int TotalCount { get; set; }
    }
}
