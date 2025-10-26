using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CandidateListDTOs
{
    public class CandidateListAuditDTO
    {
        public int? Id { get; set; }
        public int? CandidateId { get; set; }
        public string? Code { get; set; }
        public string? Daily { get; set; }
        public string? Name { get; set; }
        public bool? IsDefault { get; set; }
        public string? Status { get; set; }
        public int? ActionTypeId { get; set; }
        public int? ActionUserId { get; set; }
        public DateTime? ActionUserAt { get; set; }
    }
}
