using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SafetyMaterialsDTOs
{
    public class SafetyMaterialsUpdateDto
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? EmployeeId { get; set; }
        public string? Category { get; set; }
        public decimal? Amount { get; set; }
        public int? DurationId { get; set; }
        public DateTime? NextDate { get; set; }
        public string? Note { get; set; }

        //  Localization updates handled from frontend
        public ICollection<SafetyMaterialsLocalizationDto>? Localizations { get; set; }
    }
}
