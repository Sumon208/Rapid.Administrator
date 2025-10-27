using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SalaryAdvance
{
    public class SalaryAdvanceLocalization
    {
        public int Id { get; set; }
        public int? SalaryAdvanceId { get; set; }     
       
        public int? LanguageId { get; set; }
        public string? Name { get; set; }

        // Navigation Property
        public virtual SalaryAdvanceEntity? SalaryAdvance { get; set; }
    }

}
