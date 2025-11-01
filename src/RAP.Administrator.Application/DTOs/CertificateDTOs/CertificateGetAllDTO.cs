using RAP.Administrator.Domain.Models.Branches;
using RAP.Administrator.Domain.Models.Certificate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CertificateDTOs
{
    public class CertificateGetAllDTO : CertificateBaseDTO
    {
        public string? CertificateTypeName { get; set; }
        public string? EmployeeName { get; set; }

        // Localization list
        public List<CertificateLocalizationDTO>? Localizations { get; set; }

   
        
    }
    public class PagedCertificateResponse
    {
        public IEnumerable<CertificateEntity> Data { get; set; }
        public int TotalCount { get; set; }

    }
}
