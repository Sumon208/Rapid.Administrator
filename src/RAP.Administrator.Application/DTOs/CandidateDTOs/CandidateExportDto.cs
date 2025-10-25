using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CandidateDTOs
{
    public class CandidateExportDto
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public DateTime ExportedAt { get; set; }
        public int ExportedByUserId { get; set; }
        public string ExportedByUserName { get; set; }
    }
}
