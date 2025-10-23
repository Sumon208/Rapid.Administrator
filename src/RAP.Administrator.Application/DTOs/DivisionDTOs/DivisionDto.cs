using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DivisionDTOs
{
    public class DivisionDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string DivisionName { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? Description { get; set; }
        public short? StatusTypeId { get; set; }
        public bool IsDefault { get; set; }

        public List<DivisionLocalizationDto>? Localizations { get; set; }
        public List<DivisionAuditDto>? Audits { get; set; }
    }
}
