using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.CandidateSelection
{
    public class CandidateEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
        public int TeamId { get; set; }
        public bool IsDefault { get; set; }
        public int StatusId { get; set; }

        public Position Position { get; set; }   
       
        public Team Team { get; set; }

      
        public ICollection<CandidateLocalization> Localizations { get; set; }
        public ICollection<CandidateAudit> Audits { get; set; }
        public ICollection<CandidateExport> Exports { get; set; }
    }
}


