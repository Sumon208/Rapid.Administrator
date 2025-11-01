using RAP.Administrator.Application.DTOs.InsuranceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CertificateDTOs
{
    public class CertificateTemplateDataDTO
    {
        public List<CertificateTypeListDTO>? CertificateTypes { get; set; }
       // public List<EmployeeDTO>? Employees { get; set; }
    }
}
