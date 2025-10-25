using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.CandidateSelection
{
    public class CandidateExport
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public DateTime? ExportedAt { get; set; }
        public int? ExportedByUserId { get; set; }

        // Navigation property
        public CandidateEntity? Candidate { get; set; }
    }
}
