using RAP.Domain.Models;
using System;

namespace RAP.Administrator.Application.DTOs
{
    public class TaxResponseDto
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
        public bool IsActive { get; set; }
        public bool IsDraft { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DraftedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public List<TaxAuditEntity> Audits { get; set; } = new();
    }
}
