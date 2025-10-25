using RAP.Administrator.Domain.Models.ShiftType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ShiftTypeDTOs
{
    public class PagedShiftTypeResponse
    {
        public IEnumerable<ShiftType> Data { get; set; } = new List<ShiftType>();
        public int TotalCount { get; set; }
    }
}
