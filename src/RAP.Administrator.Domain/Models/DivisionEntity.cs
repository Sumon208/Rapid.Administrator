using System;
using System.Collections.Generic;

namespace RAP.Administrator.Domain.Models
{
    public class Division
    {
        public long Id { get; set; } 

        public string Code { get; set; } = string.Empty;
        public string DivisionName { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? Description { get; set; }

        public short? StatusTypeId { get; set; }
        public bool IsDefault { get; set; }

        public ICollection<DivisionLocalization>? Localizations { get; set; }
        public ICollection<DivisionAudit>? Audits { get; set; }
        public ICollection<DivisionExport>? Exports { get; set; } 
    }

    public class DivisionLocalization
    {
        public long Id { get; set; } 
        public long DivisionId { get; set; }
        public Division Division { get; set; } = null!;

        public long LanguageId { get; set; }
        public long CountryId { get; set; }

        public string LocalizedName { get; set; } = string.Empty;
        public string? LocalizedDescription { get; set; }

        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedBy { get; set; }
    }

    public class DivisionAudit
    {
        public long Id { get; set; }
        public long DivisionId { get; set; }
        public Division Division { get; set; } = null!;

       

        public string ActionTypeName { get; set; } = null!;

        public long ActionUserId { get; set; }
        public DateTime ActionAt { get; set; }

        public bool IsDefault { get; set; }
        public short? StatusTypeId { get; set; }
    }



    public class ActionType
    {
        public long Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class DivisionExport
    {
        public long Id { get; set; } 
        public long DivisionId { get; set; }
        public Division Division { get; set; } = null!;

        public string Description { get; set; } = string.Empty;
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedBy { get; set; }
    }
}
