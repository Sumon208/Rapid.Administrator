using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SalaryAdvanceDTOs
{
    public class SalaryAdvanceLocalizationDto
    {
        public int? Id { get; set; }
        public int? SalaryAdvanceId { get; set; }
        public int? LanguageId { get; set; }
        public string? Name { get; set; }
    }
}
