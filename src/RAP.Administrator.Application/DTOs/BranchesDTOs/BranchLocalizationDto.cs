using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.BranchesDTOs
{
    public class BranchLocalizationDto
    {
        public int Id { get; set; }
        public int? BranchId { get; set; }
        public int? LanguageId { get; set; }
        public string? Name { get; set; }
        public string? AddressLocalized { get; set; }
    }

}
