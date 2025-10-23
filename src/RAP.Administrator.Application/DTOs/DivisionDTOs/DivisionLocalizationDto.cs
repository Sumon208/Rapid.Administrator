using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DivisionDTOs
{
    public class DivisionLocalizationDto
    {
        public long DivisionId { get; set; }
        public long LanguageId { get; set; }
        public long CountryId { get; set; }

        public string LocalizedName { get; set; } = string.Empty;
        public string? LocalizedDescription { get; set; }

        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedBy { get; set; }
    }
}
