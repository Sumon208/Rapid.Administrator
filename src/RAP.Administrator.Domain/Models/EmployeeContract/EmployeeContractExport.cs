using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.EmployeeContract
{
   
    public class EmployeeContractExport
    {
        [Key]
        public int Id { get; set; }

        public int? EmployeeContractId { get; set; }
        public string? ExportedField { get; set; }   
        public string? ExportFormat { get; set; }   
        public DateTime? ExportedAt { get; set; }
        public int? ExportedBy { get; set; }
    }

}
