using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.ProjectContract
{
    public class ProjectContractAudit
    {
        [Key]
        public int Id { get; set; }                       

        public int? ProjectContractId { get; set; }


        public int? ActionTypeId { get; set; }
        public int? ActionUserId { get; set; }
        public DateTime? ActionUserAt { get; set; }

        [MaxLength(100)]
        public string? LoanTypeText { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public bool? IsDefault { get; set; }
        public bool? Draft { get; set; }

        [MaxLength(100)]
        public string? Browser { get; set; }

        [MaxLength(15)]
        public string? IP { get; set; }

        [MaxLength(100)]
        public string? MapURL { get; set; }
        public virtual ProjectContractEntity? ProjectContract { get; set; }

    }

}
