using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Insurance
{
    public class EmployeeEntity
    {
        public int Id { get; set; }        
        public string Name { get; set; } = null!;

     
        public ICollection<InsuranceEntity> Insurances { get; set; } = new List<InsuranceEntity>();
    }
}
