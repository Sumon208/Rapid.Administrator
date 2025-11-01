using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CertificateDTOs
{
    public class CertificateGetSingleDTO : CertificateBaseDTO
    {
        public string? CertificateTypeName { get; set; }
        public string? EmployeeName { get; set; }

      
    }
}
