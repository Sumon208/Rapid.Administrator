using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Document
{
    public class ShipmentTypeEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        
        public ICollection<DocumentEntity>? Documents { get; set; }
    }
}
