using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SafetyMaterialsDTOs
{
    public class SafetyMaterialsExportDto
    {
        public int? Id { get; set; }
        public int? SafetyMaterialsId { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public DateTime? ExportedAt { get; set; }
        public int? ExportedBy { get; set; }
    }
}
