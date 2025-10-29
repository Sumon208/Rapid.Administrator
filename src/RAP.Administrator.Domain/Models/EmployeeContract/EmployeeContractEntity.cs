using RAP.Administrator.Domain.Models.Insurance;

using System;
using System.Collections.Generic;

namespace RAP.Administrator.Domain.Models.EmployeeContract
{
    public class EmployeeContractEntity
    {  
        public int Id { get; set; }

        public int? StaffId { get; set; }
        public int? ContactTypeId { get; set; }
        public int? StatusId { get; set; }
        public int? SalaryAllowanceId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
         
       

        public ContactType? ContactType { get; set; }
        public ContractStatus? Status { get; set; }
        public SalaryAllowance? SalaryAllowance { get; set; }

 
        public EmployeeEntity? Staff { get; set; }

     
        public ICollection<EmployeeContractLocalization>? Localizations { get; set; }
        public ICollection<EmployeeContractAudit>? Audits { get; set; }
    }
}
