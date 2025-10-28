using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.DocumentType
{
    public class DocumentTypeAudit
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DocumentType")]
        public int? DocumentTypeId { get; set; }

        [StringLength(10)]
        public string? Code { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        public bool? IsDefault { get; set; }

        public bool? StatusId { get; set; }

        [StringLength(15)]
        public string? Browser { get; set; }

        [StringLength(50)]
        public string? Location { get; set; }

        [StringLength(20)]
        public string? IP { get; set; }

        [StringLength(30)]
        public string? OS { get; set; }

        [StringLength(100)]
        public string? MapURL { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public int? ActionTypeId { get; set; }
        public int? ActionUserId { get; set; }
        public DateTime? ActionUserAt { get; set; }

        public virtual DocumentTypeEntity? DocumentType { get; set; }
    }
}
