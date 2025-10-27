using RAP.Administrator.Domain.Models.CandidateList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.JobLocation
{
    public class JobLocationEntity
    {
        [Key]
        public int Id { get; set; }

     
        public string? JobLocation { get; set; }

        [ForeignKey(nameof(Country))]
        public int? CountryId { get; set; }
        public CountryListEntity? Country { get; set; }

       
        public string? Descriptions { get; set; }

        public bool? IsDefault { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        
        public ICollection<JobLocationAuditEntity>? Audits { get; set; }
        public ICollection<JobLocationLocalizationEntity>? Localizations { get; set; }
    }
}
