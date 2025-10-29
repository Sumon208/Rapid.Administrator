using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.EmployeeContractDTOs
{
    public class EmployeeContractCreateDto
    {
        public int? StaffId { get; set; }
        public int? ContactTypeId { get; set; }
        public int? StatusId { get; set; }
        public int? SalaryAllowanceId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public int? CreatedBy { get; set; }
        public List<EmployeeContractLocalizationDto>? Localizations { get; set; }
        public List<EmployeeContractAuditDto>? Audits { get; set; }
    }
}
