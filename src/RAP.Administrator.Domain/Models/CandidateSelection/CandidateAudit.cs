using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.CandidateSelection
{
    public class CandidateAudit
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int ActionTypeId { get; set; }
        public int ActionUserId { get; set; }
        public DateTime ActionUserAt { get; set; }

        // Navigation properties
        public CandidateEntity Candidate { get; set; } // <-- Missing before
        public ActionType ActionType { get; set; }
    }

}
