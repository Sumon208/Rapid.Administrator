using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.CandidateListDTOs
{
    public class CandidateListCreateDTO
    {
        public int? Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? SSN { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? ZipCode { get; set; }
        public int? CountryId { get; set; }

        
        public List<CandidateListLocalizationDTO>? Localizations { get; set; }
        public List<CandidateListAuditDTO>?Audits { get; set; }
    }
}
