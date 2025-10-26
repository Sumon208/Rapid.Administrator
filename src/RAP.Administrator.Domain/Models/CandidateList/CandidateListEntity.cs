using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RAP.Administrator.Domain.Models.CandidateList
{
    public class CandidateListEntity
    {
        [Key]
        public int Id { get; set; }

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

        // Common metadata
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

       
        public virtual ICollection<CandidateListLocalization>? Localizations { get; set; }
        public virtual ICollection<CandidateListAudit>? Audits { get; set; }
    }
}
