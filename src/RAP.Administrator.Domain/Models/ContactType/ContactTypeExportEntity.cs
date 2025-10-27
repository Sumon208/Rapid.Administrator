using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.ContactType
{
    public class ContactTypeExportEntity
    {
        public int Id { get; set; }               
        public string? Name { get; set; }
        public string? Description { get; set; }
       public string? ExportedBy { get; set; }
        public DateTime? ExportedAt { get; set; }
    }

}
