using RAP.Administrator.Domain.Models.Insurance;
using RAP.Administrator.Domain.Models.ProjectContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ProjectContractDTOs
{
    public class PagedProjectContractResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<ProjectContractEntity> Data { get; set; } = new List<ProjectContractEntity>();
    }
}
