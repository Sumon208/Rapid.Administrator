using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CertificateDTOs
{
    public class CertificateCreateSingleDTO
    {
        public string? CertificateNumber { get; set; }
        public int? CertificateTypeId { get; set; }
        public int? EmployeeId { get; set; }
        public string? LabManager { get; set; }
        public string? GeneralManager { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }

    
        public List<CertificateLocalizationDTO>? Localizations { get; set; }
    }
}
