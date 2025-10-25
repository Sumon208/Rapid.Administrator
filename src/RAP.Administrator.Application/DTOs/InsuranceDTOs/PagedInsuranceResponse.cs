using RAP.Administrator.Domain.Models;
using RAP.Administrator.Domain.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.InsuranceDTOs
{
    public class PagedInsuranceResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<InsuranceEntity> Data { get; set; } = new List<InsuranceEntity>();
      

    }
}
