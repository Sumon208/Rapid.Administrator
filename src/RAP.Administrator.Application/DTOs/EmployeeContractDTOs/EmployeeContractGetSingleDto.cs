using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.EmployeeContractDTOs
{
    public class EmployeeContractGetSingleDto : EmployeeContractBaseDto
    {
        public string? StaffName { get; set; }
        public string? ContactTypeName { get; set; }
        public string? StatusName { get; set; }
        public string? SalaryAllowanceName { get; set; }

      
    }
}
