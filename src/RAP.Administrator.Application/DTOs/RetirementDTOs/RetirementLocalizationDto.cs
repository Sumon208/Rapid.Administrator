using RAP.Administrator.Domain.Models.Retirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.RetirementDTOs
{
    public class RetirementLocalizationDto
    {
        public int? RetirementId { get; set; }
        public int? LanguageId { get; set; }
        public string? Description { get; set; }
    }
}
