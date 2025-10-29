using RAP.Administrator.Domain.Models.Divisions;
using RAP.Administrator.Domain.Models.EmployeeContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.EmployeeContractDTOs
{
    public class PagedEmployeeContractResponse
    {
        public IEnumerable<EmployeeContractEntity> Data { get; set; } = new List<EmployeeContractEntity>();
        public int TotalCount { get; set; }
    }
}
