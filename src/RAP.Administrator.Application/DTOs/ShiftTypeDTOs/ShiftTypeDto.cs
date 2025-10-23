using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ShiftTypeDTOs
{
    public class ShiftTypeDto 
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string ShiftTypeName { get; set; }
        public string Description { get; set; }
        public int StatusTypeId { get; set; }
        public bool IsDefault { get; set; }
        public List<ShiftTypeLocalizationDto>? Localizations { get; set; }
        public List<ShiftTypeAuditDto>? Audits { get; set; }
    }

    public class ShiftTypeLocalizationDto
    {
        public long ShiftTypeId { get; set; }
        public int LanguageId { get; set; }
        public int CountryId { get; set; }
        public string LocalizedName { get; set; }
        public string LocalizedDescription { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
    }

    public class ShiftTypeAuditDto
    {
        public long ShiftTypeId { get; set; }
        public string ActionTypeName { get; set; }
        public int? ActionUserId { get; set; }
        public DateTime ActionAt { get; set; }
        public bool IsDefault { get; set; }
        public int StatusTypeId { get; set; }
    }
}
