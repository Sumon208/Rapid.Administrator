using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.CandidateSelection
{
    public class CandidateLocalization
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int LanguageId { get; set; }
        public string LocalizedName { get; set; }
        public string LocalizedDescription { get; set; }

     
        public CandidateEntity Candidate { get; set; }
    }
}


