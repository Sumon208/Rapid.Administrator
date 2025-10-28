using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.DocumentType
{
    public class DocumentTypeExport
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DocumentType")]
        public int? DocumentTypeId { get; set; }

        [StringLength(100)]
        public string? ExportFileName { get; set; }

        public DateTime? ExportedAt { get; set; }

        public int? ExportedBy { get; set; }

        [StringLength(250)]
        public string? FilePath { get; set; }

        public virtual DocumentTypeEntity? DocumentType { get; set; }
    }
}
