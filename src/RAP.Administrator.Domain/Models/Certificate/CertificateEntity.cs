using RAP.Administrator.Domain.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Certificate
{
    public class CertificateEntity
    {
        public int Id { get; set; }
        public string? CertificateNumber { get; set; }
        public int? CertificateTypeId { get; set; }
        public int? EmployeeId { get; set; }
        public string? LabManager { get; set; }
        public string? GeneralManager { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }

        //common
        public string?ActionTypeName { get; set; }
       
        public CertificateTypeListEntity? CertificateType { get; set; }
        public EmployeeEntity? Employee { get; set; }
        public ICollection<CertificateAuditEntity>? Audits { get; set; }
        public ICollection<CertificateLocalizationEntity>? Localizations { get; set; }
        public ICollection<CertificateExportEntity>? Exports { get; set; }
    }
    public class CertificateTypeListEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
     
        public ICollection<CertificateEntity>? Certificates { get; set; }
    }
}
