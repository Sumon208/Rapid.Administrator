using System.Collections.Generic;

namespace RAP.Administrator.Application.DTOs.CandidateDTOs
{
    public class CandidateTemplateDto
    {
        public List<DropdownDto>? Positions { get; set; }
        public List<DropdownDto>? Teams { get; set; }
        public List<DropdownDto>? StatusTypes { get; set; }
        public List<DropdownDto>? Languages { get; set; }
    }

    public class DropdownDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
