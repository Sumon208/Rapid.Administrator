using RAP.Administrator.Domain.Models.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SampleCategory
{
    public class SampleCategoryEntity
    {
        [Key]
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public int? ActionTypeId { get; set; }
        public int? StatusTypeId { get; set; }

        public ICollection<SampleCategoryLocalization>? Localizations { get; set; }
        public ICollection<SampleCategoryAudit>? Audits { get; set; }
        public ICollection<SampleCategoryExport>? Exports { get; set; }
    }
}
