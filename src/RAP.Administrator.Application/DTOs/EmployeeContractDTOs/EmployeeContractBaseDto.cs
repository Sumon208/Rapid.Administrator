using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.EmployeeContractDTOs
{
    public class EmployeeContractBaseDto
    {
        public int Id { get; set; }
        public int? StaffId { get; set; }
        public int? ContactTypeId { get; set; }
        public int? StatusId { get; set; }
        public int? SalaryAllowanceId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
