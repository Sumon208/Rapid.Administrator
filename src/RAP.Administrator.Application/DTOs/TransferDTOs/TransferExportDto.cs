using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.TransferDTOs
{
    public class TransferExportDto
    {
        public int Id { get; set; }
        public int TransferId { get; set; }
        public string? ExportedBy { get; set; }
        public DateTime? ExportedDate { get; set; }
        public string? FilePath { get; set; }
    }
}
