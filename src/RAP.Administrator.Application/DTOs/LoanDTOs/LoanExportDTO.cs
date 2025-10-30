using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.LoanDTOs
{
    public class LoanExportDTO
    {
        public int? Id { get; set; }
        public int? LoanId { get; set; }
        public string? FileType { get; set; } 
        public string? FilePath { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
