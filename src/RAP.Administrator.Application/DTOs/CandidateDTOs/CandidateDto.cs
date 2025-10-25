using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CandidateDTOs
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public bool IsDefault { get; set; }
        public int StatusId { get; set; }

        public List<CandidateLocalizationDto> Localizations { get; set; }
        public List<CandidateAuditDto>? Audits { get; set; }
    }
}
