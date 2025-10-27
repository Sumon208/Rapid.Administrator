using RAP.Administrator.Domain.Models.Divisions;
using RAP.Administrator.Domain.Models.SalaryAdvance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SalaryAdvanceDTOs
{
    public class PagedSalaryAdvanceResponse
    {
        public IEnumerable<SalaryAdvanceEntity> Data { get; set; } = new List<SalaryAdvanceEntity>();
        public int TotalCount { get; set; }
    }
}
