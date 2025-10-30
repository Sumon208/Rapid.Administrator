using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Branches
{
    public class BranchLocalization
    {
        public int Id { get; set; }

     
        public int? BranchId { get; set; }
        public BranchEntity? Branch { get; set; }


        public int? LanguageId { get; set; } 

        [MaxLength(200)]
        public string? Name { get; set; }

        
        [MaxLength(500)]
        public string? AddressLocalized { get; set; }
      

    }
}
