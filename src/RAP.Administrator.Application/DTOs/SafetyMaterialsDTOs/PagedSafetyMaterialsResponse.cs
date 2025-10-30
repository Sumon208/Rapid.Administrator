using RAP.Administrator.Domain.Models.Divisions;
using RAP.Administrator.Domain.Models.SafetyMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SafetyMaterialsDTOs
{
    public class PagedSafetyMaterialsResponse
    {
       
            public IEnumerable<SafetyMaterialsEntity> Data { get; set; } = new List<SafetyMaterialsEntity>();
            public int TotalCount { get; set; }
       
    }
}
