using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DocumentDTOs
{
    public class DocumentCreateDTO
    {
        public int Id { get; set; }
        public string? DocumentNo { get; set; }
        public string? PINo { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? PIDate { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string? MobileNo { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsDraft { get; set; }
        public int? OrderById { get; set; }
        public int? ShipmentTypeId { get; set; }

        public ICollection<DocumentLocalizationDTO>? Localizations { get; set; }
        public ICollection<DocumentAuditDTO>? Audits { get; set; }
    }
}
