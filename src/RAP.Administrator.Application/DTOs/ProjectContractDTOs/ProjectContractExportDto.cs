using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ProjectContractDTOs
{
    public class ProjectContractExportDto
    {
        public int Id { get; set; }
        public int? ProjectContractId { get; set; }

        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? FileUrl { get; set; }

        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public string? Metadata { get; set; }
    }
}
