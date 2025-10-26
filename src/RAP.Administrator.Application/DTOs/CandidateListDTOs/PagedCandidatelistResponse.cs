using RAP.Administrator.Domain.Models.CandidateList;
using RAP.Administrator.Domain.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CandidateListDTOs
{
    public class PagedCandidatelistResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<CandidateListEntity> Data { get; set; } = new List<CandidateListEntity>();
    }
}
