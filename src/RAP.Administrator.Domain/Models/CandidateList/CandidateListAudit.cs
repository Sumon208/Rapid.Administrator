using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.CandidateList
{
    public class CandidateListAudit
    {
        public int? Id { get; set; }
        public int? CandidateId { get; set; }

        public string? Name { get; set; }
        public bool? IsDefault { get; set; }
        public string? Status { get; set; }
        public int? ActionTypeId { get; set; }
        public int? ActionUserId { get; set; }
        public DateTime? ActionUserAt { get; set; }


        [ForeignKey(nameof(CandidateId))]
        public CandidateListEntity? Candidate { get; set; }
    }

}
