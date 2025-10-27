using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SalaryAdvance
{
    public class SalaryAdvanceExport
    {
        public int Id { get; set; }
        public int? SalaryAdvanceId { get; set; }     
        public DateTime? ExportedAt { get; set; }
        public string? ExportedBy { get; set; }
        public string? FileName { get; set; }

        public virtual SalaryAdvanceEntity? SalaryAdvance { get; set; }
    }

}
