using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DocumentTypeDTOs
{
    public class DocumentTypeDto
    {
        public int Id { get; set; }
        public int? TemplateId { get; set; }
        public string? TemplateCode { get; set; }
        public string? TemplateName { get; set; }
        public string? Name { get; set; }
        public bool? IsDefault { get; set; }
        public bool? StatusId { get; set; }

        public ICollection<DocumentTypeLocalizationDto>? Localizations { get; set; }
        public ICollection<DocumentTypeAuditDto>? Audits { get; set; }
    }
}
