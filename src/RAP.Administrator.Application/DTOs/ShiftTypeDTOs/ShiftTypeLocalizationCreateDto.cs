using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ShiftTypeDTOs
{
    public class CreateShiftTypeLocalizationDTO
    {
        public int ShiftTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int LanguageId { get; set; }
    }

    public class UpdateShiftTypeLocalizationDTO
    {
        public int Id { get; set; }
        public int ShiftTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int LanguageId { get; set; }
    }

}
