using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DocumentTypeDTOs
{
    public class DocumentTypeCreateUpdateDto
    {
        [Required]
        public int? TemplateId { get; set; }  

        [StringLength(100)]
        public string? Name { get; set; }     

        public bool? IsDefault { get; set; }
        public bool? StatusId { get; set; }

        public ICollection<DocumentTypeLocalizationDto>? Localizations { get; set; }
        public ICollection<DocumentTypeAuditDto>? Audits { get; set; }

    }
}
