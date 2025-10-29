using RAP.Administrator.Domain.Models.JobLocation;
using RAP.Administrator.Domain.Models.ProjectContractType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ProjectContractTypeDTOs
{
    public class PagedProjectContractTypeResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<ProjectContractTypeEntity> Data { get; set; } = new List<ProjectContractTypeEntity>();
    }
}
