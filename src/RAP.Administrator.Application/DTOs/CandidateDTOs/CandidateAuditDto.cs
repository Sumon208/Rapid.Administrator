using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CandidateDTOs
{
    public class CandidateAuditDto
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string? CandidateName { get; set; }
        public int? ActionTypeId { get; set; }
        public string? ActionTypeName { get; set; }
        public int? ActionUserId { get; set; }
        public string? ActionUserName { get; set; }
        public DateTime ActionUserAt { get; set; }
        public List<CandidateAuditDto>? Audits { get; set; }
    }
}
