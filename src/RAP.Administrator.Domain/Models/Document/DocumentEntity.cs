using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Document
{
    public class DocumentEntity
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

        // Foreign Keys
        public int? OrderById { get; set; }
        public int? ShipmentTypeId { get; set; }

        // Navigation Properties
        public OrderByEntity? OrderBy { get; set; }
        public ShipmentTypeEntity? ShipmentType { get; set; }

        // Related Collections
        public ICollection<DocumentLocalizationEntity>? Localizations { get; set; }
        public ICollection<DocumentAuditEntity>? Audits { get; set; }
        public ICollection<DocumentExportEntity>? Exports { get; set; }
    }
}
