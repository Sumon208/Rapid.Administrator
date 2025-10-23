using RAP.Administrator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DivisionDTOs
{
    public class PagedDivisionResponse
    {
        public IEnumerable<Division> Data { get; set; } = new List<Division>();
        public int TotalCount { get; set; }
    }
}
