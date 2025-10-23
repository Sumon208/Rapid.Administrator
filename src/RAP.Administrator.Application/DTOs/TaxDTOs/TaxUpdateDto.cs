namespace RAP.Administrator.Application.DTOs
{
    public class TaxUpdateDto
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
        public int UpdatedBy { get; set; } // userId for auditing
    }
}
