using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.JobLocation
{
    public class JobLocationAuditEntity
    {
        [Key]
        public int Id { get; set; }

       
        public int? JobLocationId { get; set; }
        public JobLocationEntity? JobLocation { get; set; }

        public int? ActionTypeId { get; set; }  
        public int? ActionUserId { get; set; }
        public DateTime? ActionUserAt { get; set; }

        public bool? IsDefault { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsActive { get; set; }
    }
}
