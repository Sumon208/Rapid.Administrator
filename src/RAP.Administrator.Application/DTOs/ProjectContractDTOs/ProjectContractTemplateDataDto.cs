using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ProjectContractDTOs
{
    public class ProjectContractTemplateDataDto
    {
        public IEnumerable<ContractTypeListDto>? ContractTypes { get; set; }
        public IEnumerable<string>? Languages { get; set; } 
    }
}
