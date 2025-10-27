using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.JobLocationDTOs
{
    public class JobLocationCreateDTO
    {
        public int? Id { get; set; }   
        public string? JobLocation { get; set; }
        public int? CountryId { get; set; }
        public string? Descriptions { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public IEnumerable<JobLocationLocalizationDTO>? Localizations { get; set; }
        public IEnumerable<JobLocationAuditDTO>? Audits { get; set; }
    }
}
