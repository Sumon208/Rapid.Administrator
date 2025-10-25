using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CandidateDTOs
{
    using System.Collections.Generic;

    namespace RAP.Administrator.Application.DTOs.CandidateDTOs
    {
        public class CandidateUpdateDto
        {
            public int Id { get; set; }
            public string? Code { get; set; }
            public string? Name { get; set; }
            public int? PositionId { get; set; }
            public int? TeamId { get; set; }
            public bool IsDefault { get; set; }
            public int? StatusId { get; set; }
            public int? UpdatedByUserId { get; set; }

            public List<CandidateLocalizationDto>? Localizations { get; set; }
        }
    }

}
