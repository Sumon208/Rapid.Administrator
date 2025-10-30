using RAP.Administrator.Domain.Models.Branches;
using RAP.Administrator.Domain.Models.CandidateSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.BranchesDTOs
{
    public class PagedBranchResponse
    {
        public IEnumerable<BranchEntity> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
