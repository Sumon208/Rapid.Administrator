using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Insurance
{
    public class InsuranceEntity
    {
        public int Id { get; set; }

        public string? InsuranceName { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public bool IsDefault { get; set; }
        public bool IsDraft { get; set; }

        public int? EmployeeId { get; set; }
        public string? Branch { get; set; }

        // Navigation Properties
        public EmployeeEntity Employee { get; set; } = null!;


        public ICollection<InsuranceLocalization> Localizations { get; set; } = new List<InsuranceLocalization>();
        public ICollection<InsuranceAuditEntity> Audits { get; set; } = new List<InsuranceAuditEntity>();
        public ICollection<ExportInsuranceEntity> ExportInsurances { get; set; } = new List<ExportInsuranceEntity>();
    }
}
