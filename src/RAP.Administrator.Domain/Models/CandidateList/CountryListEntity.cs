using RAP.Administrator.Domain.Models.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.CandidateList
{
    public class CountryListEntity
    {
        public int? Id { get; set; }
        public int? CountryId { get; set; }
        public string? Name { get; set; }
        public ICollection<BranchEntity>? Branches { get; set; }


    }

}
