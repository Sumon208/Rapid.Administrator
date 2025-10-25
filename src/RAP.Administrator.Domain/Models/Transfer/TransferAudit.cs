using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Transfer
{
    public class TransferAudit
    {
        [Key]
        public int Id { get; set; }

        public int? TransferId { get; set; }
        public string? IqamaNo { get; set; }
        public int? BranchId { get; set; }
        public int? FromLocationId { get; set; }
        public int? ToLocationId { get; set; }
        public DateTime? TransferDate { get; set; }

        public string? OldValuesJson { get; set; }
        public string? NewValuesJson { get; set; }

        public int? ActionTypeId { get; set; }
        public int? ActionUserId { get; set; }
        public DateTime? ActionAt { get; set; }

        [ForeignKey("TransferId")]
        public virtual TransferEntity? Transfer { get; set; }
    }
}
