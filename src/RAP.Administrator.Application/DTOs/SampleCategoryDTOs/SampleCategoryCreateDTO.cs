using RAP.Administrator.Application.DTOs.RetirementDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SampleCategoryDTOs
{
    public class SampleCategoryCreateDTO
    {
        [Key]
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public int? ActionTypeId { get; set; }
        public int? StatusTypeId { get; set; }

        public ICollection<SampleCategoryLocalizationDTO>? Localizations { get; set; }
        public ICollection<SampleCategoryAuditDTO>? Audits { get; set; }

    }
}
