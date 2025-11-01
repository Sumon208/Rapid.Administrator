using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Certificate
{
    public class CertificateLocalizationEntity
    {
        public int Id { get; set; }
        public int? CertificateId { get; set; }
        public int? LanguageId { get; set; }
        public string? Name { get; set; }

        // Navigation
        public CertificateEntity? Certificate { get; set; }
    }
}
