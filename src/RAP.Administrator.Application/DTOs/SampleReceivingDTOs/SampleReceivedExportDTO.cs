using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SampleReceivingDTOs
{
    public class SampleReceivedExportDTO
    {
        public int Id { get; set; }
        public int? ReceivedId { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public DateTime? ExportedAt { get; set; }
    }
}
