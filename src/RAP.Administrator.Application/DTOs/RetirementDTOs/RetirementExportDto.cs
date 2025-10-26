using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.RetirementDTOs
{
    public class RetirementExportDto
    {
        public int? Id { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? BranchName { get; set; }
    }

}
