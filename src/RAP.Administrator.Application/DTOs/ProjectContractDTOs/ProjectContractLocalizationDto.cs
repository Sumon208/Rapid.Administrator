using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ProjectContractDTOs
{
    public class ProjectContractLocalizationDto
    {
        public int Id { get; set; }
        public int? ProjectContractId { get; set; }
        public int? LanguageId { get; set; }
        public string? Name { get; set; }
    }
}
