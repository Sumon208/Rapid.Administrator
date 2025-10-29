using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.EmployeeContractDTOs
{
    public class EmployeeContractBulkCreateDto
    {
        public List<EmployeeContractCreateDto>? Contracts { get; set; }
    }
}
