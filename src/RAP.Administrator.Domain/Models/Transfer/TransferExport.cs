using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Transfer
{
    public class TransferExport
    {
        [Key]
        public int Id { get; set; }

        public int? TransferId { get; set; }
        public int? ExportedById { get; set; }
        public DateTime? ExportedAt { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? FileUrl { get; set; }

        [ForeignKey("TransferId")]
        public virtual TransferEntity? Transfer { get; set; }
    }
}
