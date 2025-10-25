using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CandidateDTOs
{
    public class CandidateLocalizationDto
    {
        public int LanguageId { get; set; }
        public string LocalizedName { get; set; }
        public string LocalizedDescription { get; set; }
    }
}
