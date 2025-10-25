using RAP.Administrator.Application.DTOs.CandidateDTOs;
using System.Collections.Generic;

namespace RAP.Administrator.Application.DTOs.CandidateDTOs
{
    public class CandidateBulkCreateDto
    {
        public List<CandidateCreateDto>? Candidates { get; set; }
    }
}
