using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ProjectContractTypeDTOs
{
    public class ProjectContractTypeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsDefault { get; set; }

        // Child collections
        public List<ProjectContractTypeLocalizationDto>? Localizations { get; set; }
        public List<ProjectContractTypeExportDto>? Exports { get; set; }
        public List<ProjectContractTypeAuditDto>? Audits { get; set; }
    }
}

