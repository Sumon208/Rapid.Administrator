using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.EmployeeContractDTOs
{
    public class EmployeeContractTemplateDataDto
    {
        public List<DropdownItemDto>? StaffList { get; set; }
        public List<DropdownItemDto>? ContactTypeList { get; set; }
        public List<DropdownItemDto>? StatusList { get; set; }
        public List<DropdownItemDto>? SalaryAllowanceList { get; set; }
    }
    public class DropdownItemDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
