using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.ProjectContractType
{
    public class ProjectContractTypeExport
    {
        [Key]
        public int Id { get; set; }

        public int? LoanTypeId { get; set; }

        [MaxLength(200)]
        public string? FileName { get; set; }

        [MaxLength(50)]
        public string? FileType { get; set; }

        public long? SizeBytes { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public ProjectContractTypeEntity? ProjectContractType { get; set; }
    }
}
