using RAP.Administrator.Domain.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SafetyMaterials
{
    public class SafetyMaterialsEntity
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? EmployeeId { get; set; }
        public string? Category { get; set; }
        public decimal? Amount { get; set; }
        public int? DurationId { get; set; }
        public DateTime? NextDate { get; set; }
        public string? Note { get; set; }

        // 🔹 Navigation Properties
        public virtual EmployeeEntity? Employee { get; set; }
        public virtual DurationEntity? Duration { get; set; }
        public virtual ICollection<SafetyMaterialsAuditEntity>? Audits { get; set; }
        public virtual ICollection<SafetyMaterialsLocalizationEntity>? Localizations { get; set; }
        public virtual ICollection<SafetyMaterialsExportEntity>? Exports { get; set; }
    }
    public class DurationEntity
    {
        public int Id { get; set; }
        public string? Duration { get; set; }

        // 🔹 Navigation Property
        public virtual ICollection<SafetyMaterialsEntity>? SafetyMaterials { get; set; }
    }
}
