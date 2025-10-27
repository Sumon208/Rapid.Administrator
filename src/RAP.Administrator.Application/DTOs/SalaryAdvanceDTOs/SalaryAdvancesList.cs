using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SalaryAdvanceDTOs
{
    public class IqmaListDto
    {
        public int? Id { get; set; }
        public string? IqmaNo { get; set; }
    }

    public class PaymentModeListDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }

    public class BranchListDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }

}
