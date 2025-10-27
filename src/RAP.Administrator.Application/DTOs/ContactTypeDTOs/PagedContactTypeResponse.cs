using RAP.Administrator.Domain.Models.ContactType;
using RAP.Administrator.Domain.Models.Divisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ContactTypeDTOs
{
    public class PagedContactTypeResponse
    {
        public IEnumerable<ContactTypeEntity> Data { get; set; } = new List<ContactTypeEntity>();
        public int TotalCount { get; set; }
    }
}

