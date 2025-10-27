using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SalaryAdvance
{
    public class PaymentModeListEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

     
        public virtual ICollection<SalaryAdvanceEntity>? SalaryAdvances { get; set; }
    }

}
