using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.RetirementDTOs
{
    public class EmployeeCreateDto
    {
        public string? Name { get; set; }

        public ICollection<RetirementCreateDto>? Retirements { get; set; }

       
      
    }

}
