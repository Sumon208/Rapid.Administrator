using System;

namespace RAP.Administrator.Application.DTOs
{
    public class TaxListDto
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string BranchName { get; set; }
        public decimal OpeningBalance { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
 