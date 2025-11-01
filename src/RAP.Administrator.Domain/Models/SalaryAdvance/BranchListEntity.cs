using RAP.Administrator.Domain.Models.SampleReceiving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SalaryAdvance
{
    public class BranchListEntity
    {
        public int Id { get; set; }
        public string? Branch { get; set; }
        public virtual ICollection<SalaryAdvanceEntity>? SalaryAdvances { get; set; }
        public virtual ICollection<SampleReceivingEntity>? SampleReceivings { get; set; }

    }
}
