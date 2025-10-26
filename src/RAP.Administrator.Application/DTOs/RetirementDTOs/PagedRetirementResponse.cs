using RAP.Administrator.Domain.Models.Retirement;
using System.Collections.Generic;

namespace RAP.Administrator.Application.DTOs.RetirementDTOs
{
    public class PagedRetirementResponse
    {
        public int? TotalCount { get; set; }
        public IEnumerable<RetirementEntity>? Data { get; set; }
    }
}
