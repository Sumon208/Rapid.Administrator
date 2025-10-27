using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SalaryAdvance
{
    public class IqmaListEntity
    {
        public int Id { get; set; }
        public string? IqmaNo { get; set; }

      
        public virtual ICollection<SalaryAdvanceEntity>? SalaryAdvances { get; set; }
    }
}
