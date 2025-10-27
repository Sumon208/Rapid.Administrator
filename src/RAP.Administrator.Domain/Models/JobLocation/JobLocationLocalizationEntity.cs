using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.JobLocation
{
    public class JobLocationLocalizationEntity
    {
        [Key]
        public int Id { get; set; }

        public int JobLocationId { get; set; }
        
  
        public string? Descriptions { get; set; }

        public int? LanguageId { get; set; }

        public JobLocationEntity? JobLocation { get; set; }
    }
}
