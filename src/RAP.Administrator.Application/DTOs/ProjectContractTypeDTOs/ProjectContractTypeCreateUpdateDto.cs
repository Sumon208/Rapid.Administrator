using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ProjectContractTypeDTOs
{
    public class ProjectContractTypeCreateUpdateDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsDefault { get; set; }

        public List<ProjectContractTypeLocalizationDto>? Localizations { get; set; }
        
    }
}
