using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Branches
{
    public class CompanyListEntity
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string? CompanyName { get; set; }

        
        public ICollection<BranchEntity>? Branches { get; set; }
    }
}
