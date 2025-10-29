using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ProjectContractDTOs
{
    public class ProjectContractUpdateDto
    {
        public int Id { get; set; }

        public string? Subject { get; set; }
        public int? ContractTypeId { get; set; }
        public string? Customer { get; set; }
        public decimal? ContractValue { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }

        public bool? IsDefault { get; set; }
        public bool? Draft { get; set; }

        
        public ICollection<ProjectContractLocalizationDto>? Localizations { get; set; }
    }
}
