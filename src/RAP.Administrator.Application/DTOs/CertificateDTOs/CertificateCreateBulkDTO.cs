using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CertificateDTOs
{
    public class CertificateCreateBulkDTO
    {
        public List<CertificateCreateSingleDTO>? Certificates { get; set; }
    }
}
