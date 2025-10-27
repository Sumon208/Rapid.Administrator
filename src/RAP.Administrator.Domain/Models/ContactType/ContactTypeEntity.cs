using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.ContactType
{
    public class ContactTypeEntity
    {
        
            public int Id { get; set; }
             public string? ContactType { get; set; }
            public string? Description { get; set; }

            public ICollection<ContactTypeLocalizationEntity>? Localizations { get; set; }
            public ICollection<ContactTypeAuditEntity>? Audits { get; set; }
      
    }
}
