using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Insurance
{
    public class ExportInsuranceEntity
    {
        public int Id { get; set; }

        public int? InsuranceId { get; set; }
        public DateTime? ExportedAt { get; set; }
        public int? ExportedByUserId { get; set; }

        public string? ExportFormat { get; set; } = "Excel"; 

       
        public InsuranceEntity Insurance { get; set; } = null!;
     
    }
}
