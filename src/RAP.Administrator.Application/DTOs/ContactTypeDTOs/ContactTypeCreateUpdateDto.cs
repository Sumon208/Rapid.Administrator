using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ContactTypeDTOs
{
    public class ContactTypeCreateUpdateDto
    {
        public int? Id { get; set; }                     
        public string? ContactType { get; set; }
        public string? Description { get; set; }

       
        public List<ContactTypeLocalizationDto>? Localizations { get; set; }
        public List<ContactTypeAuditDto>? Audits { get; set; }
    }
}
