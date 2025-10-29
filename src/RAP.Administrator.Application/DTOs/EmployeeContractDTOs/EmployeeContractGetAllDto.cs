using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.EmployeeContractDTOs
{
    public class EmployeeContractGetAllDto : EmployeeContractBaseDto
    {
        public string? StaffName { get; set; }
        public string? ContactTypeName { get; set; }
        public string? StatusName { get; set; }
        public string? SalaryAllowanceName { get; set; }

        public List<EmployeeContractLocalizationDto>? Localizations { get; set; }
        public List<EmployeeContractAuditDto>? Audits { get; set; }


    }
}
