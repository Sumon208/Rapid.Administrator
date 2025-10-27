using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SalaryAdvanceDTOs
{
    public class SalaryAdvanceTemplateDataDto
    {
        public List<IqmaListDto>? Iqmas { get; set; }
        public List<BranchListDto>? Branches { get; set; }
        public List<PaymentModeListDto>? PaymentModes { get; set; }
    }
}
