using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Loan
{
    public class LoanAudit
    {
        [Key]
        public int Id { get; set; }

        public int? LoanId { get; set; }
        public virtual LoanEntity? Loan { get; set; }

        [StringLength(3)]
        public string? Code { get; set; }

        [StringLength(5)]
        public string? Dail { get; set; }

        [StringLength(40)]
        public string? Name { get; set; }

        public bool? IsDefault { get; set; }
        public bool? StatusId { get; set; }

        [StringLength(15)] public string? Browser { get; set; }
        [StringLength(3)] public string? Location { get; set; }
        [StringLength(15)] public string? IP { get; set; }
        [StringLength(15)] public string? OS { get; set; }
        [StringLength(100)] public string? MapURL { get; set; }

        [Column(TypeName = "decimal(10,7)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(10,7)")]
        public decimal? Longitude { get; set; }

        public int? ActionTypeId { get; set; }
        public int? ActionUserId { get; set; }
        public DateTime? ActionUserAt { get; set; }
        public ICollection<LoanEntity> Loans { get; set; } = new List<LoanEntity>();
    }
}
