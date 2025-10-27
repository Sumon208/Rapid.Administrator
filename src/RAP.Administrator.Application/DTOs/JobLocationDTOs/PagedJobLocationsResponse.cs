using RAP.Administrator.Domain.Models.Insurance;
using RAP.Administrator.Domain.Models.JobLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.JobLocationDTOs
{
    public class PagedJobLocationsResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<JobLocationEntity> Data { get; set; } = new List<JobLocationEntity>();
    }
}
