using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ProjectContractDTOs
{
    public class ProjectContractBulkCreateDto
    {
        public ICollection<ProjectContractCreateDto>? Contracts { get; set; }
    }
}
