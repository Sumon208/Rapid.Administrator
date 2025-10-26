using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CandidateListDTOs
{
    public class CountryListDTO
    {
        public int? Id { get; set; }
        public int? CountryId { get; set; }
        public string? Name { get; set; }
        public int? LanguageId { get; set; }
    }
}
