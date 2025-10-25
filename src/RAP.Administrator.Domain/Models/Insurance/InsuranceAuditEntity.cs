using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Insurance
{
    public class InsuranceAuditEntity
    {
        public int Id { get; set; }

        public int InsuranceId { get; set; }
        public string InsuranceName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsDefault { get; set; }
        public bool IsDraft { get; set; }

        public int? EmployeeId { get; set; }
        public int? BranchId { get; set; }

        public int StatusId { get; set; }
        public int ActionTypeId { get; set; }
        public int ActionUserId { get; set; }
        public DateTime ActionUserAt { get; set; }

        // Navigation
        public InsuranceEntity Insurance { get; set; } = null!;
        
    }
}
