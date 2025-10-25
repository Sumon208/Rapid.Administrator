using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.CandidateSelection
{
    public class Position
    {
        public int Id { get; set; }
        public string? PositionName { get; set; } = string.Empty;
 

        public ICollection<CandidateEntity>? CandidateSelections { get; set; } = new List<CandidateEntity>();
    }

}
