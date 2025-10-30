using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Branches
{
    public class BranchExport
    {
        public int Id { get; set; }

        public int? BranchId { get; set; }
        public BranchEntity? Branch { get; set; }


        [MaxLength(200)]
        public string? FileName { get; set; }

        [MaxLength(50)]
        public string? FileType { get; set; }

        public long? FileSizeBytes { get; set; }

        public DateTime? ExportedAt { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }
       
    }
}
