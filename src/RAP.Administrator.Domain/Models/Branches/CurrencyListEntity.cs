using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Branches
{
    public class CurrencyListEntity
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string? Currency { get; set; }

      
        public ICollection<BranchEntity>? Branches { get; set; }
    }

}
