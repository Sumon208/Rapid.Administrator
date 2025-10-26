using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Retirement
{
    public class RetirementAudit
    {
        public int? Id { get; set; }
        public int? RetirementId { get; set; }
        public string? ActionType { get; set; } 
        public int? ActionUserId { get; set; }
        public DateTime? ActionDate { get; set; }

       
        public string? EmployeeName { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }

        
        public RetirementEntity? Retirement { get; set; }
    }

}
