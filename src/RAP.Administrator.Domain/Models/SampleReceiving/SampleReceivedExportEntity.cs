using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SampleReceiving
{
    public class SampleReceivedExportEntity
    {
        [Key]
        public int Id { get; set; }

        public int? ReceivedId { get; set; }

        [MaxLength(250)]
        public string? FileName { get; set; }

        [MaxLength(1000)]
        public string? FilePath { get; set; }

        public DateTime? ExportedAt { get; set; }

      
        public virtual SampleReceivingEntity? SampleReceivings { get; set; }
    }
}
