using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Transfer
{
    public class TransferEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? TransferDate { get; set; }
        public string? IqamaNo { get; set; }
        public int? BranchId { get; set; }
        public int? FromLocationId { get; set; }
        public int? ToLocationId { get; set; }
        public string? Descriptions { get; set; }

        public int? CreatedById { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<TransferLocalization>? Localizations { get; set; }
        public virtual ICollection<TransferAudit>? Audits { get; set; }
        public virtual ICollection<TransferExport>? Exports { get; set; }
    }
}
