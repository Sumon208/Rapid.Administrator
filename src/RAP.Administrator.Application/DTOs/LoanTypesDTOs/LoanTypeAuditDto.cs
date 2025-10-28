using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.LoanTypesDTOs
{
    public class LoanTypeAuditDto
    {
        public int Id { get; set; }
        public int? LoanTypeId { get; set; }
        public int? ActionTypeId { get; set; }
        public int? ActionUserId { get; set; }
        public DateTime? ActionUserAt { get; set; }
        public string? LoanTypeText { get; set; }
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
        public bool? Draft { get; set; }
        public string? Browser { get; set; }
        public string? IP { get; set; }
        public string? MapURL { get; set; }
    }

}
