using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Certificate
{
    public class CertificateExportEntity
    {
        public int Id { get; set; }
        public int? CertificateId { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public DateTime? ExportedAt { get; set; }
        public int? ExportedBy { get; set; }

        // Navigation
        public CertificateEntity? Certificate { get; set; }
    }
}
