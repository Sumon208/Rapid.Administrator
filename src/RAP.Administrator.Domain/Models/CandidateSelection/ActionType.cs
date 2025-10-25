using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.CandidateSelection
{
    public class ActionType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;        
        public string DisplayName { get; set; } = string.Empty; 
        public bool IsActive { get; set; } = true;

      
        public ICollection<CandidateAudit> CandidateAudits { get; set; } = new List<CandidateAudit>();
    }

}
