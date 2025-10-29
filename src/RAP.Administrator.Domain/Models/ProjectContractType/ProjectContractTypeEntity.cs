using RAP.Administrator.Domain.Models.LoanType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.ProjectContractType
{
    public class ProjectContractTypeEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public bool? IsDraft { get; set; }

        public bool? IsDefault { get; set; }

        public ICollection<ProjectContractTypeAudit>? Audits { get; set; }
        public ICollection<ProjectContractTypeLocalization>? Localizations { get; set; }
        public ICollection<ProjectContractTypeExport>? Exports { get; set; }


    }
}
