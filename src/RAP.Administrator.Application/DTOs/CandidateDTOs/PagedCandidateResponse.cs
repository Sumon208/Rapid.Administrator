using RAP.Administrator.Domain.Models.CandidateSelection;
using RAP.Administrator.Domain.Models.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CandidateDTOs
{
    public class PagedCandidateResponse
    {

        
            public IEnumerable<CandidateEntity> Data { get; set; }
            public int TotalCount { get; set; }
       

    }
}
