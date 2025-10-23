using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ShiftTypeDTOs
{
    public class ShiftTypeUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? Color { get; set; }
        public int? R { get; set; }
        public int? G { get; set; }
        public int? B { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BreakTime { get; set; }

        public string Status { get; set; } = "Active";
        public bool IsDefault { get; set; }

        public ICollection<UpdateShiftTypeLocalizationDTO>? Localizations { get; set; }
    }
}
