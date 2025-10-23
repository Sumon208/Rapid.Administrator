using RAP.Domain.Models;
using System;
using System.Collections.Generic;

namespace RAP.Administrator.Domain.Models
{
    public class TaxEntity
    {
        public int Id { get; set; }

        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string BranchName { get; set; }
        public string IBANNumber { get; set; }

        public decimal OpeningBalance { get; set; }
        public string Address { get; set; }
        public string BankDetails { get; set; }

        public bool IsDefault { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDraft { get; set; } = false;
        public bool IsDeleted { get; set; } = false;


        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DraftedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        // Navigation property: one Tax has many audits
        public ICollection<TaxAuditEntity> Audits { get; set; }
    }
}
