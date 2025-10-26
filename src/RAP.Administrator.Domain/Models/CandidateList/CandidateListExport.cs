using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.CandidateList
{
    public class CandidateListExport
    {
        public int? Id { get; set; }
        public string? FileName { get; set; }
        public string? ExportType { get; set; }  
        public DateTime? ExportedAt { get; set; }
        public int? ExportedBy { get; set; }
        public string? ExportData { get; set; }  
    }

}
