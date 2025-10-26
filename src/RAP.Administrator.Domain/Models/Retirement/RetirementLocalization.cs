using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Retirement
{
    public class RetirementLocalization
    {
        public int Id { get; set; }
        public int? RetirementId { get; set; }
        public int? LanguageId { get; set; }
        public string? Description { get; set; }

        
        public RetirementEntity? Retirement { get; set; }
    }

}
