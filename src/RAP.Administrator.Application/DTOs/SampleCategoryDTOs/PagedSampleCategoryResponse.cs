using RAP.Administrator.Domain.Models.Retirement;
using RAP.Administrator.Domain.Models.SampleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SampleCategoryDTOs
{
    public class PagedSampleCategoryResponse
    {
        public int? TotalCount { get; set; }
        public IEnumerable<SampleCategoryEntity>? Data { get; set; }
    }
}
