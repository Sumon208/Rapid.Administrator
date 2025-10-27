using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ContactTypeDTOs
{
    public class ContactTypeListDto
    {
        public int Id { get; set; }
        public string? ContactType { get; set; }
        public string? Description { get; set; }

        public List<ContactTypeLocalizationDto>? Localizations { get; set; }
        public List<ContactTypeAuditDto>? Audits { get; set; }

        public int? TotalRecords { get; set; }
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
    }
}
