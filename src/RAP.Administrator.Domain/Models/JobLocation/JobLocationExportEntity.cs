using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.JobLocation
{
    public class JobLocationExportEntity
    {
        [Key]
        public int Id { get; set; }

      
        public string? JobLocation { get; set; }

        public string? CountryName { get; set; }

        
        public string? Descriptions { get; set; }

        public bool? IsDefault { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string? CreatedByName { get; set; }
    }
}
