using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.JobLocationDTOs
{
    public class JobLocationLocalizationDTO
    {
        public int? Id { get; set; }
        public int? JobLocationId { get; set; }
      
        public string? Descriptions { get; set; }
        public int? LanguageId { get; set; }
    }
}
