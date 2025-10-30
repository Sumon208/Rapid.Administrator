using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SafetyMaterialsDTOs
{
    public class SafetyMaterialsLocalizationDto
    {
        public int Id { get; set; }
        public int? LanguageId { get; set; }
        public int? SafetyMaterialsId { get; set; }
        public string? Name { get; set; }
    }
}
