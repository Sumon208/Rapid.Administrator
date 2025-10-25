using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.InsuranceDTOs
{
    public class InsuranceDto
    {

        public int Id { get; set; }
        public string? InsuranceName { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public bool? IsDefault { get; set; }
        public bool? IsDraft { get; set; }

        public int? StatusTypeId { get; set; }

        public int? EmployeeId { get; set; }
        public string? Branch { get; set; } = null!;

        // Navigation DTOs
       
        public ICollection<InsuranceLocalizationDto>? Localizations { get; set; }
        public ICollection<InsuranceAuditDto>? Audits { get; set; }
     //   public ICollection<ExportInsuranceDto>? ExportInsurances { get; set; }
    }
}
