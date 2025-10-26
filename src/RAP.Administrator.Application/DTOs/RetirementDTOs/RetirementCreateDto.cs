using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.RetirementDTOs
{
    public class RetirementCreateDto
    {

        public int? RetirementId { get; set; }
        public string? Retirement {  get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public bool? IsDefault { get; set; }
        public bool? Draft { get; set; }
        public string? Branch { get; set; }

        public ICollection<RetirementLocalizationDto>? Localizations { get; set; }
        public ICollection<RetirementAuditDto>? Audits { get; set; }
    }

}
