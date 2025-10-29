using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ProjectContractDTOs
{
    public class ProjectContractListResponseDto
    {
        public IEnumerable<ProjectContractDto>? Records { get; set; }
        public int? TotalCount { get; set; }           
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
