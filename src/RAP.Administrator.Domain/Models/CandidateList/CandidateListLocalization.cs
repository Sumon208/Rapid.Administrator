using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.CandidateList
{
    public class CandidateListLocalization
    {
        public int? Id { get; set; }
        public int? CandidateId { get; set; }
        public int? LanguageId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }


        [ForeignKey(nameof(CandidateId))]
        public CandidateListEntity? Candidate { get; set; }
    }

}
