using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.ProjectContract
{
    public class ProjectContractEntity
    {
        [Key]
        public int Id { get; set; }                       

       
        public int? ContractTypeId { get; set; }

        [ForeignKey(nameof(ContractTypeId))]
        public virtual ContractTypeList? ContractType { get; set; }

        
        [MaxLength(500)]
        public string? Subject { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Customer { get; set; }

        public decimal? ContractValue { get; set; }

        public bool? IsDefault { get; set; }
        public bool? Draft { get; set; }

      
        public int? CreatedById { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }

       
        public virtual ICollection<ProjectContractAudit>? Audits { get; set; }
        public virtual ICollection<ProjectContractLocalization>? Localizations { get; set; }
        public virtual ICollection<ProjectContractExport>? Exports { get; set; }

        
       
        public class ContractTypeList
        {
            [Key]
            public int Id { get; set; }                 

            [MaxLength(200)]
            public string? Name { get; set; }

           
            public virtual ICollection<ProjectContractEntity>? ProjectContracts { get; set; }
        }
    }
}
