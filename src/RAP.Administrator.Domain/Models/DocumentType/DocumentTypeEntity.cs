using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.DocumentType
{
    public class DocumentTypeEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Template")]
        public int? TemplateId { get; set; }

        public virtual DocumentCodeTemplate? Template { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        public bool? IsDefault { get; set; }

        public bool? StatusId { get; set; }   
        
        public virtual ICollection<DocumentTypeLocalization>? Localizations { get; set; }
        public virtual ICollection<DocumentTypeAudit>? Audits { get; set; }
        public virtual ICollection<DocumentTypeExport>? Exports { get; set; }

    }
}
