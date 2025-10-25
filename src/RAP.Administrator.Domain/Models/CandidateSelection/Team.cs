using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.CandidateSelection
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public ICollection<CandidateEntity> CandidateSelections { get; set; } = new List<CandidateEntity>();
    }

}
