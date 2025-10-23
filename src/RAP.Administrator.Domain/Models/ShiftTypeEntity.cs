using System;
using System.Collections.Generic;

namespace RAP.Administrator.Domain.Models
{
    public class ShiftType
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

      
        public string Color { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

       
        public DateTime BreakTime { get; set; }

       
        public string Status { get; set; } = "Active";

        public bool IsDefault { get; set; }

        public ICollection<ShiftTypeLocalization>? Localizations { get; set; }
        public ICollection<ShiftTypeAudit>? Audits { get; set; }
        public ICollection<ShiftTypeExport>? Exports { get; set; }
    }

    public class ShiftTypeLocalization
    {
        public long Id { get; set; }
        public long ShiftTypeId { get; set; }
        public ShiftType ShiftType { get; set; } = null!;

        public long LanguageId { get; set; }
        public long CountryId { get; set; }

        public string LocalizedName { get; set; } = string.Empty;
        public string? LocalizedDescription { get; set; }

        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedBy { get; set; }
    }

    public class ShiftTypeAudit
    {
        public long Id { get; set; }
        public long ShiftTypeId { get; set; }
        public ShiftType ShiftType { get; set; } = null!;

        public string ActionTypeName { get; set; } = null!;
        public long ActionUserId { get; set; }
        public DateTime ActionAt { get; set; }

      
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BreakTime { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
    }

    public class ShiftTypeExport
    {
        public long Id { get; set; }
        public long ShiftTypeId { get; set; }
        public ShiftType ShiftType { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedBy { get; set; }
    }
}
